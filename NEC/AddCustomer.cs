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
    public partial class AddCustomer : Form
    {
        String name="", address="Address", contact="Contact";
        int total=0;
        bool insert = true;
        public AddCustomer()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(MainScreen.m_dbConnection.State==ConnectionState.Closed)
                MainScreen.m_dbConnection.Open();

            if (textBox_name.Text != "")
            {
                insert = true;
                name = textBox_name.Text;

            }
            else
            {
                DialogResult result = MessageBox.Show("Name field empty, are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    insert = true;
                }
                else if (result == DialogResult.No)
                {
                    insert = false;
                }
            }
            if(textBox_addr.Text!="")address=textBox_addr.Text;
            if(textBox_contact.Text!="")contact=textBox_contact.Text;

            if (textBox_amt.Text != "")
            {
                insert = true;
                total = Int32.Parse(textBox_amt.Text);

            }
            else
            {
                DialogResult result = MessageBox.Show("Net Amount field empty, are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    insert = true;
                }
                else if (result == DialogResult.No)
                {
                    insert = false;
                }
            }
            if (insert == true)
            {
                string sql = "insert into Customers (Name, Address,Contact,Total) values ('" + name + "','" + address + "','" + contact + "'," + total + ")";
                SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                command.ExecuteNonQuery();
                this.Close();
            }
        }
    }
}
