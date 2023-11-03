using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Fixture_Maker_2._0
{
    public partial class Form2 : Form
    {

        readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\Fixture Maker 2.0\Fixture Maker 2.0\Database.mdf"";Integrated Security=True;Connect Timeout=30");
        private SqlCommand cmd;
        string imgLoc = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.databaseDataSet.Table);

        }

        private void InsertData_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql = "insert into [Table](TName,TLogo,TStedium) values('" + TeamName.Text + "',@img,'" +Stedium.Text + "')";
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.Add(new SqlParameter("@img", img));
                int x = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(x.ToString() + " record(s) saved.");
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateData_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql = "UPDATE [Table] SET TLogo = @img, TStedium = '" + Stedium.Text + "' WHERE TName = '" + TeamName.Text + "'";
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.Add(new SqlParameter("@img", img));
                int x = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(x.ToString() + " record(s) changed.");
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowData_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from [Table]";
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand(sql, con);


                int x = cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                tableDataGridView.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UploadLogo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "All Files (*.*)|*.*|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    ImagePath.Text = imgLoc;
                    TeamLogo.ImageLocation = imgLoc;
                    TeamLogo.Image = new Bitmap(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();
            fm.Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DeleteData_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "DELETE FROM [Table] WHERE TName = '" + TeamName.Text + "'";
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand(sql, con);

               
                int x = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(x.ToString() + " record(s) deleted.");
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
