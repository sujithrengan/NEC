using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Collections;

namespace NEC
{
    public partial class CustomerTransaction : Form
    {
        public int cid;
        public string cname;
        public int total=0;
        public ViewTransactions vForm;

        public void setData()
        {

            listView_customers.Items.Clear();
            string[] arr = new string[6];
            ListViewItem itm;

            if (MainScreen.m_dbConnection.State == ConnectionState.Closed)
                MainScreen.m_dbConnection.Open();
            string sql = "select * from Transactions where Customer_id=" + cid + "";
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            total = 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["ID"].ToString();
                //refid = Int32.Parse(arr[0]);
                arr[1] = reader["Type"].ToString();
                //type = Int32.Parse(arr[1]);
                if (arr[1] == "1") arr[1] = "Credit";
                else arr[1] = "Debit";
                arr[3] = reader["Date"].ToString();
                arr[4] = reader["Amount"].ToString();
                total += Int32.Parse(arr[4]);
                arr[2] = reader["Product"].ToString();
                arr[5] = reader["Remarks"].ToString();
                itm = new ListViewItem(arr);
                listView_customers.Items.Add(itm);
                //amt = Int32.Parse(arr[4]);

                //product = arr[2];
                //date = arr[3];
            }

            label3.Text = total.ToString();
        }
        public CustomerTransaction(ViewTransactions vForm,int Cust_ID,string name,int total)
        {
            this.total=total;
            this.cname=name;
            this.vForm = vForm;
            cid = Cust_ID;
            InitializeComponent();

            
            listView_customers.View = View.Details;
            listView_customers.GridLines = true;
            listView_customers.FullRowSelect = true;
            label1.Text = cname;
            label3.Text = total.ToString();
            //Add column header
            listView_customers.Columns.Add("Ref. No", 80);
            listView_customers.Columns.Add("Type", 60);
            listView_customers.Columns.Add("Product", 150);
            listView_customers.Columns.Add("Date", 140);
            listView_customers.Columns.Add("Amount", 160);
            listView_customers.Columns.Add("Remarks", 200);
            setData();
           

        }

        private void onclick(object sender, EventArgs e)
        {
            //MessageBox.Show(listView_customers.SelectedItems[0].SubItems[2].Text);
            int type;
            if (listView_customers.SelectedItems[0].SubItems[1].Text == "Credit") type = 1;
            else
                type = -1;
            new EditTransaction(this, vForm, Int32.Parse(listView_customers.SelectedItems[0].SubItems[0].Text), Int32.Parse(listView_customers.SelectedItems[0].SubItems[4].Text), type, listView_customers.SelectedItems[0].SubItems[3].Text, listView_customers.SelectedItems[0].SubItems[2].Text, listView_customers.SelectedItems[0].SubItems[5].Text).Show();        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            listView_customers.Items.Clear();
            string[] arr = new string[6];
            ListViewItem itm;
            string sql = "select * from Transactions where Customer_id=" + cid + " and Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd")+"'"+" and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd")+"'" ;
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            total = 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["ID"].ToString();
                arr[1] = reader["Type"].ToString();
                if (arr[1] == "1") arr[1] = "Credit";
                else arr[1] = "Debit";
                arr[3] = reader["Date"].ToString();
                arr[4] = reader["Amount"].ToString();
                arr[2] = reader["Product"].ToString();
                arr[5] = reader["Remarks"].ToString();
                total += Int32.Parse(arr[4]);
                itm = new ListViewItem(arr);
                listView_customers.Items.Add(itm);
            }
            label3.Text = total.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            listView_customers.Items.Clear();
            string[] arr = new string[6];
            ListViewItem itm;
            string sql = "select * from Transactions where Customer_id=" + cid + " and Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " and Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            total = 0;
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["ID"].ToString();
                arr[1] = reader["Type"].ToString();
                if (arr[1] == "1") arr[1] = "Credit";
                else arr[1] = "Debit";
                arr[3] = reader["Date"].ToString();
                arr[4] = reader["Amount"].ToString();
                arr[2] = reader["Product"].ToString();
                arr[5] = reader["Remarks"].ToString();
                total += Int32.Parse(arr[4]);
                itm = new ListViewItem(arr);
                listView_customers.Items.Add(itm);
            }
            label3.Text = total.ToString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //listView_customers is nothing but the listview control name
                string[] st = new string[listView_customers.Columns.Count];
                DirectoryInfo di = new DirectoryInfo(@"C:\NEC\Exports\");
                if (di.Exists == false)
                    di.Create();
                StreamWriter sw = new StreamWriter(@"C:\NEC\Exports\" + "export_" + cname + ".xls", false);
                sw.AutoFlush = true;
                for (int col = 0; col < listView_customers.Columns.Count; col++)
                {
                    sw.Write(listView_customers.Columns[col].Text.ToString()+"\t");
                }

                int rowIndex = 1;
                int row = 0;
                string st1 = "";
                for (row = 0; row < listView_customers.Items.Count; row++)
                {
                    if (rowIndex <= listView_customers.Items.Count)
                        rowIndex++;
                    st1 = "";
                    if (row == 0)
                        st1 += "\n";
                    for (int col = 0; col < listView_customers.Columns.Count; col++)
                    {
                        
                        st1 = st1+ listView_customers.Items[row].SubItems[col].Text.ToString()+"\t";
                        
                    }
                    sw.WriteLine(st1);
                }
                sw.Close();
                FileInfo fil = new FileInfo(@"C:\NEC\Exports\" + "export_"+cname+".xls");
                if (fil.Exists == true)
                    MessageBox.Show("Process Completed", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, close excel sheet if opened");
            }

        }


        private int lastSortColumn = 0;
        private SortOrder lastSortOrder = SortOrder.Ascending;

        private void Rebuild()
        {
            this.listView_customers.ListViewItemSorter = new ColumnComparer(this.lastSortColumn, this.lastSortOrder);
        }

        private void listView_customers_ColumnClick_1(object sender, ColumnClickEventArgs e)
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

       

    }
}
