using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Sql_Database_import_and_export
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();

            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Please attached the SQL file", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string con = "datasource=localhost;port=3306;username=root;password=''";
                    string Query = richTextBox1.Text;
                    MySqlConnection MyConn2 = new MySqlConnection(con);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                    MessageBox.Show("The database addition was successful.", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("This database has already been added.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Stream st;
            OpenFileDialog dr = new OpenFileDialog();
            dr.Filter = "SQL files (*.sql)|*.sql";
            if (dr.ShowDialog() == DialogResult.OK)
            {
                string file = dr.FileName;
                if ((st = dr.OpenFile()) != null && Path.GetExtension(file).Equals(".sql", StringComparison.OrdinalIgnoreCase))
                {
                    string str = File.ReadAllText(file);
                    richTextBox1.Text = str;
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string con = "datasource=localhost;port=3306;username=root;password=''";
                MySqlConnection MyConn2 = new MySqlConnection(con);
                MyConn2.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Please start the MySQL server. Please restart this application if you are running the server", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                btn1.Enabled = false;
                btn2.Enabled = false;
                btnClear.Enabled = false;
                richTextBox1.Enabled = false;
            }


        }
    }
}
