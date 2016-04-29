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
    public partial class AddCollection : Form
    {
        DataSet ds, ds2,ds3;
        public AddCollection()
        {
            InitializeComponent();


            SQLiteCommand command, command2,command3;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter();
            SQLiteDataAdapter adapter3 = new SQLiteDataAdapter();
            ds = new DataSet();
            ds2 = new DataSet();
            ds3 = new DataSet();
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

            sql = "select ID,Name from Salesmen";
            command2 = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            adapter2.SelectCommand = command2;
            adapter2.Fill(ds2);
            adapter2.Dispose();
            command2.Dispose();
            comboBox4.DataSource = ds2.Tables[0];

            comboBox4.ValueMember = "ID";
            comboBox4.DisplayMember = "Name";

            sql = "select ID,Name from Routes";
            command3 = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            adapter3.SelectCommand = command3;
            adapter3.Fill(ds3);
            adapter3.Dispose();
            command3.Dispose();
            comboBox3.DataSource = ds3.Tables[0];

            comboBox3.ValueMember = "ID";
            comboBox3.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {


            int amt = 0;
            int type = 1;//1 for bill ; 2 for slip
            bool c = checkBox1.Checked;

            string date = "", remarks = "";
            string cust_name = ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"].ToString();
            string sales_name = ds2.Tables[0].Rows[comboBox4.SelectedIndex]["Name"].ToString();
            string route = ds3.Tables[0].Rows[comboBox3.SelectedIndex]["Name"].ToString();
            int cust_id = Int32.Parse(ds.Tables[0].Rows[comboBox1.SelectedIndex]["ID"].ToString());
            if (textBox2.Text.ToString() != "")
                amt = Int32.Parse(textBox2.Text.ToString());
            if (c==true)
                type = 2;
            else
                type = 1;
            
            date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            amt = (amt);
            remarks = textBox3.Text;

            string sql;
            SQLiteCommand command;
            try
            {
                sql = "insert into Collections(Salesman,Route,Amount,Type,Date,Customer_id,Customer_name,Remarks) values ('" + sales_name + "','" + route + "'," + (amt) + "," + type + ",'"+date+"'," + cust_id  + ",'"+cust_name+"','" + remarks + "')";
                //MessageBox.Show(sql);
                command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                command.ExecuteNonQuery();

                if (c == true)
                {
                    sql = "insert into Transactions values (0,'" + cust_name + "'," + (-1 * amt) + ",-1," + cust_id + ",'" + date + "',' ','SlipCollection')";
                    command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                    command.ExecuteNonQuery();




                    sql = "select Total from Customers where ID=" + cust_id + "";
                    command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    reader.Read();
                    int total = Int32.Parse(reader["Total"].ToString());

                    amt = -1 * amt;
                    total += amt;

                    sql = "update Customers set Total=" + total + " where ID=" + cust_id + "";
                    command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                    command.ExecuteNonQuery();

                }

                textBox3.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
                comboBox1.SelectedIndex = 0;
                
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
