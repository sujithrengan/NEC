using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace NEC
{
    public partial class Add_Transaction : Form
    {
        bool isprod = true;
        DataSet ds,ds2;
        public Add_Transaction()
        {
            InitializeComponent();

            SQLiteCommand command,command2;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter();
            ds = new DataSet();
            ds2 = new DataSet();
            int i = 0;
            string sql = null;
            //connetionString = "Data Source=ServerName;Initial Catalog=databasename;User ID=userid;Password=yourpassword";
            sql = "select ID,Name from Customers";
            command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();
            comboBox1.DataSource = ds.Tables[0];
            
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Name";

            comboBox2.SelectedIndex = 0;

            sql = "select ID,Name from Products";
            command2 = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            adapter2.SelectCommand = command2;
            adapter2.Fill(ds2);
            adapter2.Dispose();
            command2.Dispose();
            comboBox3.DataSource = ds2.Tables[0];

            comboBox3.ValueMember = "ID";
            comboBox3.DisplayMember = "Name";

            comboBox2.SelectedIndex = 0;
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                comboBox3.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("Please add atleast one product", "Warning", MessageBoxButtons.OK);
                isprod = false;
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int amt = 0;
            int id = 0; 
            int type=1;
            bool c = checkBox1.Checked;
            
            string date="",remarks="";
            string cust_name = ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"].ToString();
            int cust_id=Int32.Parse(ds.Tables[0].Rows[comboBox1.SelectedIndex]["ID"].ToString());
            if(textBox2.Text.ToString()!="")
            amt = Int32.Parse(textBox2.Text.ToString());
            if (comboBox2.SelectedIndex == 0)
                type = 1;
            else
                type=-1;
            if(textBox1.Text.ToString()!="")
            id= Int32.Parse(textBox1.Text.ToString());

            date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            amt = (amt * type);
            remarks = textBox3.Text;

            string sql;
            SQLiteCommand command;
            //if (id != 0)
            //{
                try
                {
                    sql = "insert into Transactions values (" + id + ",'" + cust_name + "'," + (amt) + "," + type + "," + cust_id + ",'" + date + "','" + ds2.Tables[0].Rows[comboBox3.SelectedIndex]["Name"].ToString() + "','"+remarks+"')";
                    command= new SQLiteCommand(sql, MainScreen.m_dbConnection);
                    command.ExecuteNonQuery();

                    if (c == true && type == 1)
                    {
                        sql = "insert into Transactions values (0,'" + cust_name + "'," + (-1 * amt) + ",-1," + cust_id + ",'" + date + "','" + ds2.Tables[0].Rows[comboBox3.SelectedIndex]["Name"].ToString() + "','CashTransaction')";
                        command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                        command.ExecuteNonQuery();

                    }

                    else if(c==false)
                    {
                        sql = "select Total from Customers where ID=" + cust_id + "";
                        command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                        SQLiteDataReader reader = command.ExecuteReader();

                        reader.Read();
                        int total = Int32.Parse(reader["Total"].ToString());

                        total += amt;

                        sql = "update Customers set Total=" + total + " where ID=" + cust_id + "";
                        command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                        command.ExecuteNonQuery();

                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ID ALready Exists");
                }
            //}
            /*else
            {
                sql = "insert into Transactions(Customer_name,Amount,Type,Customer_id,Date,Product) values ('" + cust_name + "'," + (amt) + "," + type + "," + cust_id + ",'" + date + "','" + ds2.Tables[0].Rows[comboBox3.SelectedIndex]["Name"].ToString() + "')";
               command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                command.ExecuteNonQuery();

            }*/

           
        }

        private void load(object sender, EventArgs e)
        {
            if(!isprod)
            this.Close();
        }
    }
}
