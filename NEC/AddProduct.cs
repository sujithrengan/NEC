using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace NEC
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string sql = "insert into Products (Name) values ('" + textBox1.Text.ToString() + "')";
                SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                command.ExecuteNonQuery();
                this.Close();
            }

            else
            {
                MessageBox.Show("Enter valid product", "Warning", MessageBoxButtons.OK);
            }
        }
    }
}
