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
    public partial class AddSalesman : Form
    {
        public AddSalesman()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string sql = "insert into Salesmen (Name) values ('" + textBox1.Text.ToString() + "')";
                SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                command.ExecuteNonQuery();
                this.Close();
            }

            else
            {
                MessageBox.Show("Enter valid name", "Warning", MessageBoxButtons.OK);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
