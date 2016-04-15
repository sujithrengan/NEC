using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;
using System.IO;

namespace NEC
{
    public partial class TranscationsView : Form
    {
        DataSet ds;
        int total = 0;
        public TranscationsView()
        {
            InitializeComponent();
            if (MainScreen.m_dbConnection.State == ConnectionState.Closed)
                MainScreen.m_dbConnection.Open();
            string sql = "select sum(Total) as sum from Customers";
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //MessageBox.Show(reader["sum"].ToString());
                label3.Text = reader["sum"].ToString();
            }

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            //Add column header
            listView1.Columns.Add("Ref. No", 80);
            listView1.Columns.Add("Customer", 120);
            listView1.Columns.Add("Type", 60);
            listView1.Columns.Add("Product", 150);
            listView1.Columns.Add("Date", 140);
            listView1.Columns.Add("Amount", 160);

            string[] arr = new string[6];
            ListViewItem itm;

            
            sql = "select * from Transactions";
            command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["ID"].ToString();
                arr[1] = reader["Customer_name"].ToString();
                arr[2] = reader["Type"].ToString();
                if (arr[2] == "1") arr[2] = "Credit";
                else arr[2] = "Debit";
                arr[4] = reader["Date"].ToString();
                arr[5] = reader["Amount"].ToString();
                arr[3] = reader["Product"].ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }

            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            ds = new DataSet();
            sql = "select ID,Name from Products";
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
        }

        

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("2");
            listView1.Items.Clear();
            string[] arr = new string[6];
            ListViewItem itm;
            string sql;
            //sql = "select * from Transactions where "+ "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] != "All")
                sql = "select * from Transactions where " + "Product='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "'" + " and Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else
                sql = "select * from Transactions where " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            total = 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["ID"].ToString();
                arr[1] = reader["Customer_name"].ToString();
                arr[2] = reader["Type"].ToString();
                if (arr[2] == "1") arr[2] = "Credit";
                else arr[2] = "Debit";
                arr[4] = reader["Date"].ToString();
                arr[5] = reader["Amount"].ToString();
                arr[3] = reader["Product"].ToString();
                total += Int32.Parse(arr[5]);
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
            label3.Text = total.ToString();
        }

        
       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string[] arr = new string[6];
            ListViewItem itm;
            string sql;
            // sql = "select * from Transactions where " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] != "All")
                sql = "select * from Transactions where " + "Product='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "'" + " and Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else
                sql = "select * from Transactions where " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            total = 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["ID"].ToString();
                arr[1] = reader["Customer_name"].ToString();
                arr[2] = reader["Type"].ToString();
                if (arr[2] == "1") arr[2] = "Credit";
                else arr[2] = "Debit";
                arr[4] = reader["Date"].ToString();
                arr[5] = reader["Amount"].ToString();
                arr[3] = reader["Product"].ToString();
                total += Int32.Parse(arr[5]);
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
            label3.Text = total.ToString();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == this.lastSortColumn)
            {
                if (this.lastSortOrder == SortOrder.Ascending)
                    this.lastSortOrder = SortOrder.Descending;
                else
                    this.lastSortOrder = SortOrder.Ascending;
            }
            else
            {
                this.lastSortOrder = SortOrder.Ascending;
                this.lastSortColumn = e.Column;
            }

            this.Rebuild();
        }
        private int lastSortColumn = 0;
        private SortOrder lastSortOrder = SortOrder.Ascending;

        private void Rebuild()
        {
                this.listView1.ListViewItemSorter = new ColumnComparer(this.lastSortColumn, this.lastSortOrder);
        }

        internal class ColumnComparer : IComparer, IComparer<ListViewItem>
        {
            public ColumnComparer(int col, SortOrder order)
            {
                this.column = col;
                this.sortOrder = order;
            }

            public int Compare(object x, object y)
            {
                return this.Compare((ListViewItem)x, (ListViewItem)y);
            }

            public int Compare(ListViewItem x, ListViewItem y)
            {
                int result = String.Compare(x.SubItems[this.column].Text, y.SubItems[this.column].Text, true);

                if (this.sortOrder == SortOrder.Descending)
                    result = 0 - result;

                return result;

            }

            private int column;
            private SortOrder sortOrder;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            listView1.Items.Clear();
            string[] arr = new string[6];
            ListViewItem itm;
            string sql;
            //MessageBox.Show(comboBox1.SelectedItem.ToString());
            if (ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"]!="All")
                sql = "select * from Transactions where " + "Product='" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + "'" + " and Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            else
                sql = "select * from Transactions where " + "Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            total = 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["ID"].ToString();
                arr[1] = reader["Customer_name"].ToString();
                arr[2] = reader["Type"].ToString();
                if (arr[2] == "1") arr[2] = "Credit";
                else arr[2] = "Debit";
                arr[4] = reader["Date"].ToString();
                arr[5] = reader["Amount"].ToString();
                arr[3] = reader["Product"].ToString();
                total += Int32.Parse(arr[5]);
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
            label3.Text = total.ToString();
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //listView1 is nothing but the listview control name
                string[] st = new string[listView1.Columns.Count];
                DirectoryInfo di = new DirectoryInfo(@"C:\NEC\Exports\");
                if (di.Exists == false)
                    di.Create();
                StreamWriter sw = new StreamWriter(@"C:\NEC\Exports\" + "export_" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + ".xls", false);
                sw.AutoFlush = true;
                for (int col = 0; col < listView1.Columns.Count; col++)
                {
                    sw.Write(listView1.Columns[col].Text.ToString() + "\t");
                }

                int rowIndex = 1;
                int row = 0;
                string st1 = "";
                for (row = 0; row < listView1.Items.Count; row++)
                {
                    if (rowIndex <= listView1.Items.Count)
                        rowIndex++;
                    st1 = "";
                    if (row == 0)
                        st1 += "\n";
                    for (int col = 0; col < listView1.Columns.Count; col++)
                    {

                        st1 = st1 + listView1.Items[row].SubItems[col].Text.ToString() + "\t";

                    }
                    sw.WriteLine(st1);
                }
                sw.Close();
                FileInfo fil = new FileInfo(@"C:\NEC\Exports\" + "export_" + ds.Tables[0].Rows[comboBox1.SelectedIndex]["Name"] + ".xls");
                if (fil.Exists == true)
                    MessageBox.Show("Process Completed", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, close excel shhet if opened.");
            }
        }

    }
}
