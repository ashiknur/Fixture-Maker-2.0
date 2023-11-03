using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fixture_Maker_2._0
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\Fixture Maker 2.0\Fixture Maker 2.0\Database.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        string path;
        public Form1()
        {
            InitializeComponent();
            
        }

        

        private void UpdateImage_Click(object sender, EventArgs e)
        {
            if (Manual.Checked == false)
            {
                try
                {
                    string sql = "select TLogo from [Table] where TName='" + FirstTeamName.Text + "'";
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] img = (byte[])(reader[0]);
                        if (img == null)
                            FirstTeamLogo.Image = null;
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            FirstTeamLogo.Image = Image.FromStream(ms);
                        }

                    }
                    else
                    {
                        MessageBox.Show("1st Team logo Do not exist");
                    }
                    sql = "select TStedium from [Table] where TName='" + FirstTeamName.Text + "'";
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd = new SqlCommand(sql, con);
                    reader.Close();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        String st = (String)(reader[0]);
                        if (st == null)
                            Stedium.Text = null;
                        else
                        {
                            Stedium.Text = st;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Stedium Do not exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
                try
                {
                    string sql = "select TLogo from [Table] where TName='" + SecondTeamName.Text + "'";
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] img = (byte[])(reader[0]);
                        if (img == null)
                            SecondTeamLogo.Image = null;
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            SecondTeamLogo.Image = Image.FromStream(ms);
                        }

                    }
                    else
                    {
                        MessageBox.Show("2nd Team logo Do not exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
                try
                {
                    string sql = "select TLogo from [Table] where TName='" + LegueLogoName.Text + "'";
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] img = (byte[])(reader[0]);
                        if (img == null)
                            LegueLogo.Image = null;
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            LegueLogo.Image = Image.FromStream(ms);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Legue logo Do not exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }

            label1.Text = FirstTeamName.Text.ToUpper();
            label2.Text = SecondTeamName.Text.ToUpper();
            if (Manual.Checked == true) Stedium.Text = StediumName.Text.ToUpper();
            label6.Text = "";
            for (int i = 0; i < DateName.Text.Length; i++)
            {
                label6.Text += DateName.Text[i];
                label6.Text += " ";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Template.Parent = Panel1;
            Stedium.Parent = Template;
            label1.BackColor = Color.Transparent;
            label1.Parent = Template;
            label2.Parent = Template;
            label6.Parent = Template;
            FirstTeamLogo.Parent = Template;
            SecondTeamLogo.Parent = Template;
            LegueLogo.Parent = Template;
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            SavingPath.Text = path.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var img = new Bitmap(Panel1.Width, Panel1.Height))
            {
                Panel1.DrawToBitmap(img, new Rectangle(0, 0, img.Width, img.Height));
                String s = "";
                for(int i=0;i<FileName.Text.Length;i++)
                {
                    if(FileName.Text[i]!=' ')
                    {
                        s += FileName.Text[i];
                    }
                    else
                    {
                        s += "-";
                    }
                }
                s = SavingPath.Text.ToString() + "/" + s + TypeName.Text;
                if(!File.Exists(s))
                {
                    img.Save(s);
                }
                else
                {
                    string message = "The File Already Exists.\nDo you want to replace the file?";
                    string title = "Save File";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        img.Save(s);
                    }
                    

                }
            }
        }

        private void FirstLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files(*.*)|*.*|JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FirstTeamLogo.Image = new Bitmap(open.FileName);
            }
        }

        private void SecondLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files(*.*)|*.*|JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                SecondTeamLogo.Image = new Bitmap(open.FileName);
            }
        }

        private void MiddleLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files(*.*)|*.*|JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                LegueLogo.Image = new Bitmap(open.FileName);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();
            fm.Show();
        }

        private void AutoSave_Click(object sender, EventArgs e)
        {
            String[] Line = FixtureList.Lines;
            Char[] ch = { ' ', ':','/',')','(' };
            for(int i=0;i<Line.Length;i++)
            {
                String[] wd = Line[i].Split(ch);
                FileName.Text = wd[0]+"-"+wd[1];
                FirstTeamName.Text = wd[3];
                int p = 4;
                try
                {
                    while (p + 3 < wd.Length)
                    {
                        if (wd[p] != "" )
                        {
                            if(wd[p][0] < '9' && wd[p][0] > '0')
                                break;
                            FirstTeamName.Text += " " + wd[p];
                        }
                        else if(wd[p]!="")
                        {
                            FirstTeamName.Text += " " + wd[p];

                        }
                        p += 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                String tm = wd[p++] + ":" + wd[p++];
                SecondTeamName.Text = wd[p++];
                
                try
                {
                    while (p + 3 < wd.Length)
                    {
                        if (wd[p] != "")
                        {
                            SecondTeamName.Text += " " + wd[p];
                        }
                        
                        p += 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LegueLogoName.Text = wd[p++];
                String t = "";
                foreach(String x in wd)
                {
                    t += x;
                    t += " ";
                }
                String[] Mon = {"", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                String[] DAY = {"", "1st","2nd","3rd","4th","5th","6th","7th","8th","9th","10th",
                                    "11th","12th","13th","14th","15th","16th","17th","18th","19th","20th",
                                    "21st", "22nd", "23rd", "24th", "25th","26th","27th","28th","29th","30th","31st" };
                String s = wd[p+1]+"/"+wd[p]+"/"+YearName.Text;
                DateTime tarikh = DateTime.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
                DateName.Text = tarikh.DayOfWeek.ToString() + " | " +DAY[tarikh.Day] + " " + Mon[tarikh.Month] + " | " + tm;
                UpdateImage.PerformClick();
                SaveButton.PerformClick();
            }
            
        }

        private void YearName_TextChanged(object sender, EventArgs e)
        {

        }

        private void FirstTeamName_TextChanged(object sender, EventArgs e)
        {

        }

        private void FirstTeamLogo_Click(object sender, EventArgs e)
        {

        }
    }   
}
