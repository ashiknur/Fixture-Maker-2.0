# 🏆 Fixture Maker 2.0

A **Windows desktop application** built with C# and Windows Forms that generates professional sports match fixture cards. Designed for tournament organizers and sports clubs, it pulls team data from a local SQL Server database to produce ready-to-share match announcement images — complete with team logos, venue, date, and league branding.

---

## ✨ Features

- **Auto Mode** — Fetch team logos, names, and stadium info directly from the local database with one click
- **Manual Mode** — Enter team and venue details by hand for quick, one-off fixture cards
- **Batch Auto-Save** — Paste a full fixture list and generate all match cards in bulk automatically
- **Team Database Manager** — Full CRUD interface to add, update, and delete teams with logo and stadium info
- **Image Export** — Save each fixture card as `.PNG` or `.JPG` to any directory on your machine
- **Custom League Branding** — Display a league/tournament logo alongside both team logos on every card

---

## 🖥️ Tech Stack

| Technology | Purpose |
|---|---|
| C# (.NET Framework) | Core application language |
| Windows Forms (WinForms) | Desktop GUI framework |
| SQL Server LocalDB (MSSQLLocalDB) | Local team database |
| ADO.NET (SqlConnection / SqlCommand) | Database access layer |
| GDI+ (System.Drawing) | Fixture card rendering & image export |

---

## 🗂️ Application Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                        Form3 — Main Menu                    │
│                  [ Make Fixture ]  [ Manage Teams ]         │
└────────────┬───────────────────────────────────┬────────────┘
             │                                   │
             ▼                                   ▼
┌────────────────────────┐          ┌────────────────────────┐
│  Form1 — Fixture Card  │          │  Form2 — Team Database │
│  Maker                 │          │  Manager               │
│                        │          │                        │
│  ┌──────────────────┐  │          │  • Insert team         │
│  │  Auto Mode       │──┼──────────│  • Update team logo    │
│  │  (Pull from DB)  │  │  reads   │  • Delete team         │
│  └──────────────────┘  │          │  • View all teams      │
│  ┌──────────────────┐  │          └───────────┬────────────┘
│  │  Manual Mode     │  │                      │
│  │  (Type details)  │  │           ┌──────────▼──────────┐
│  └──────────────────┘  │           │  SQL Server LocalDB  │
│  ┌──────────────────┐  │           │  Table: Teams        │
│  │  Batch Auto-Save │  │           │  • TName (string)    │
│  │  (Fixture list)  │  │           │  • TLogo (binary)    │
│  └──────────────────┘  │           │  • TStedium (string) │
│                        │           └─────────────────────┘
│  Exports → .PNG / .JPG │
└────────────────────────┘
```

### Fixture Card Generation Flow

```
Input (Team Names + Date + Venue)
            │
            ▼
  ┌─────────────────────┐
  │ Auto Mode?          │
  │  Yes → Query DB for │──► Fetch Logo + Stadium from SQL Server
  │  team logo & stadium│
  │  No  → Use manual   │──► Use typed values directly
  │  input values       │
  └─────────┬───────────┘
            │
            ▼
  Render fixture card panel
  (team logos + names + venue + date + league logo)
            │
            ▼
  DrawToBitmap() → Save as image file
  (.png / .jpg) to selected output path
```

---

## ⚙️ Installation & Setup

### Prerequisites

- **Windows OS** (Windows 10 or later recommended)
- [Visual Studio 2019 or later](https://visualstudio.microsoft.com/) with **.NET Desktop Development** workload
- **SQL Server LocalDB** — included with Visual Studio by default
  - Verify installation by running in a terminal:
    ```bash
    sqllocaldb info
    ```
  - If not installed, download from [Microsoft SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

---

### Step 1 — Clone the Repository

```bash
git clone https://github.com/ashiknur/Fixture-Maker-2.0.git
cd Fixture-Maker-2.0
```

---

### Step 2 — Open the Solution

Open `Fixture Maker 2.0.sln` in Visual Studio.

---

### Step 3 — Fix the Database Connection String

The connection string in `Form1.cs` and `Form2.cs` currently points to a hardcoded local path:

```csharp
// Current (hardcoded — needs to be updated)
AttachDbFilename="E:\Fixture Maker 2.0\Fixture Maker 2.0\Database.mdf"
```

Update both files to point to the `.mdf` file in your cloned project directory:

```csharp
// In Form1.cs and Form2.cs — replace the connection string with:
SqlConnection con = new SqlConnection(
    @"Data Source=(LocalDB)\MSSQLLocalDB;" +
    @"AttachDbFilename=|DataDirectory|\Database.mdf;" +
    @"Integrated Security=True;Connect Timeout=30"
);
```

Or set `|DataDirectory|` in `Program.cs`:

```csharp
static void Main()
{
    AppDomain.CurrentDomain.SetData(
        "DataDirectory",
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory)
    );
    Application.Run(new Form3());
}
```

---

### Step 4 — Build & Run

1. In Visual Studio, set the build configuration to **Debug**
2. Press **F5** or click **Start** to build and launch the application
3. The app opens to the **Main Menu (Form3)**

---

## 🚀 Usage

### Adding Teams to the Database

1. From the **Main Menu**, click **Manage Teams**
2. Enter the team name, upload a logo image, and enter the stadium/venue name
3. Click **Insert** to save the team

### Generating a Single Fixture Card

1. From the **Main Menu**, click **Make Fixture**
2. Enter the **First Team**, **Second Team**, **League**, **Date**, and **Venue**
3. Toggle **Manual** if you want to type details without using the database
4. Click **Update Image** to preview the fixture card
5. Set a **File Name**, choose a **Save Path**, and click **Save**

### Batch Generating Fixture Cards

1. On the Fixture Maker screen, paste your full fixture list into the **Fixture List** text box
   - Expected format per line: `MatchNo: Team1 HH:MM Team2 LeagueName DD/MM`
2. Enter the **Year**
3. Click **Auto Save** — all fixture cards are generated and saved automatically

---

## 📁 Project Structure

```
Fixture-Maker-2.0/
├── Fixture Maker 2.0.sln          # Visual Studio solution file
└── Fixture Maker 2.0/
    ├── Form1.cs                   # Fixture card maker (main feature)
    ├── Form2.cs                   # Team database manager
    ├── Form3.cs                   # Main menu / navigation hub
    ├── Database.mdf               # SQL Server LocalDB file
    ├── DatabaseDataSet.xsd        # Typed dataset schema
    ├── App.config                 # Application configuration
    └── Images and Icons/          # App icons and fonts
```

---

## 🤝 Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request for bug fixes, improvements, or new features.

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m "Add your feature"`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Open a Pull Request
