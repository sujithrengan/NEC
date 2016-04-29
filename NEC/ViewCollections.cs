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
    public partial class ViewCollections : Form
    {
        int total = 0;
        DataSet ds,ds2;
        public ViewCollections()
        {
            InitializeComponent();

            if (MainScreen.m_dbConnection.State == ConnectionState.Closed)
                MainScreen.m_dbConnection.Open();
            string sql = "select sum(Amount) as sum from Collections";
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //MessageBox.Show(reader["sum"].ToString());
                label5.Text = reader["sum"].ToString();
            }


            label3.Text = "";
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            //Add column header
            listView1.Columns.Add("Salesman", 100);
            listView1.Columns.Add("Route", 100);
            listView1.Columns.Add("Customer", 100);
            listView1.Columns.Add("Type", 60);
            listView1.Columns.Add("Date", 110);
            listView1.Columns.Add("Amount", 100);
            listView1.Columns.Add("Remarks", 100);

            string[] arr = new string[7];
            ListViewItem itm;


            sql = "select * from Collections";
            command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["Salesman"].ToString();
                arr[1] = reader["Route"].ToString();
                arr[2] = reader["Customer_name"].ToString();
                arr[3]=reader["Type"].ToString();
                if (arr[3] == "1") arr[3] = "Bill";
                else arr[3] = "Slip";
                arr[4] = reader["Date"].ToString();
                arr[5] = reader["Amount"].ToString();
                arr[6] = reader["Remarks"].ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }

            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter();
            ds = new DataSet();
            ds2=new DataSet();
            sql = "select ID,Name from Salesmen";
            command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            adapter.SelectCommand = command;

            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();

            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = -1;
            dr["Name"] = "All";
            ds.Tables[0].Rows.Add(dr);
            comboBox1.DataSource = ds.Tables[0];

            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndex = ds.Tables[0].Rows.Count - 1;

            SQLiteCommand command2;
            sql = "select ID,Name from Routes";
            command2 = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            adapter2.SelectCommand = command2;

            adapter2.Fill(ds2);
            adapter2.Dispose();
            command2.Dispose();

            DataRow dr2 = ds2.Tables[0].NewRow();
            dr2["ID"] = -1;
            dr2["Name"] = "All";
            ds2.Tables[0].Rows.Add(dr2);
            comboBox2.DataSource = ds2.Tables[0];

            comboBox2.ValueMember = "ID";
            comboBox2.DisplayMember = "Name";
            comboBox2.SelectedIndex = ds2.Tables[0].Rows.Count - 1;
            
        }

        private void sales_changed(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string[] arr = new string[7];
            ListViewItem itm;
            string sql;
            //MessageBox.Show(comboBox1.SelectedItem.ToString());
            if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] != "All")
                sql = "select * from Collections where " + "Salesman='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "'" + " and Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else
                sql = "select * from Collections where " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            total= 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["Salesman"].ToString();
                arr[1] = reader["Route"].ToString();
                arr[2] = reader["Customer_name"].ToString();
                arr[3] = reader["Type"].ToString();
                if (arr[3] == "1") arr[3] = "Bill";
                else arr[3] = "Slip";
                arr[4] = reader["Date"].ToString();
                arr[5] = reader["Amount"].ToString();
                arr[6] = reader["Remarks"].ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
                total += Int32.Parse(arr[5]);
            }
            label5.Text = total.ToString();
            
        }

        private void route_changed(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string[] arr = new string[7];
            ListViewItem itm;
            string sql="";
            //MessageBox.Show(comboBox1.SelectedItem.ToString());
            if (ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] != "All"&&ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] != "All")
                sql = "select * from Collections where " +"Salesman='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "' and "+ "Route='" + ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] + "'" + " and Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] != "All"&&ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] == "All")
                sql = "select * from Collections where " +"Salesman='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "' and "+ "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else if(ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] == "All"&&ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] == "All")
                sql = "select * from Collections where " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] == "All" && ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] != "All")
                sql = "select * from Collections where " + "Route='" + ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] + "' and " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            

            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            total = 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["Salesman"].ToString();
                arr[1] = reader["Route"].ToString();
                arr[2] = reader["Customer_name"].ToString();
                arr[3] = reader["Type"].ToString();
                if (arr[3] == "1") arr[3] = "Bill";
                else arr[3] = "Slip";
                arr[4] = reader["Date"].ToString();
                arr[5] = reader["Amount"].ToString();
                arr[6] = reader["Remarks"].ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
                total += Int32.Parse(arr[5]);
            }
            label5.Text = total.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string[] arr = new string[7];
            ListViewItem itm;
            string sql = "";
            //MessageBox.Show(comboBox1.SelectedItem.ToString());
            if (ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] != "All" && ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] != "All")
                sql = "select * from Collections where " + "Salesman='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "' and " + "Route='" + ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] + "'" + " and Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] != "All" && ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] == "All")
                sql = "select * from Collections where " + "Salesman='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "' and " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else if (ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] == "All" && ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] == "All")
                sql = "select * from Collections where " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] == "All" && ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] != "All")
                sql = "select * from Collections where " + "Route='" + ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] + "' and " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";


            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            total = 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["Salesman"].ToString();
                arr[1] = reader["Route"].ToString();
                arr[2] = reader["Customer_name"].ToString();
                arr[3] = reader["Type"].ToString();
                if (arr[3] == "1") arr[3] = "Bill";
                else arr[3] = "Slip";
                arr[4] = reader["Date"].ToString();
                arr[5] = reader["Amount"].ToString();
                arr[6] = reader["Remarks"].ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
                total += Int32.Parse(arr[5]);
            }
            label5.Text = total.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string[] arr = new string[7];
            ListViewItem itm;
            string sql = "";
            //MessageBox.Show(comboBox1.SelectedItem.ToString());
            if (ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] != "All" && ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] != "All")
                sql = "select * from Collections where " + "Salesman='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "' and " + "Route='" + ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] + "'" + " and Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] != "All" && ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] == "All")
                sql = "select * from Collections where " + "Salesman='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "' and " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else if (ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] == "All" && ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] == "All")
                sql = "select * from Collections where " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] == "All" && ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] != "All")
                sql = "select * from Collections where " + "Route='" + ds2.Tables[0].Rows[comboBox2.SelectedIndex]["Name"] + "' and " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";


            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            total = 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["Salesman"].ToString();
                arr[1] = reader["Route"].ToString();
                arr[2] = reader["Customer_name"].ToString();
                arr[3] = reader["Type"].ToString();
                if (arr[3] == "1") arr[3] = "Bill";
                else arr[3] = "Slip";
                arr[4] = reader["Date"].ToString();
                arr[5] = reader["Amount"].ToString();
                arr[6] = reader["Remarks"].ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
                total += Int32.Parse(arr[5]);
            }
            label5.Text = total.ToString();
        }
    }
}
