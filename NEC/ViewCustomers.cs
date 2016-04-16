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

namespace NEC
{
    public partial class ViewTransactions : Form
    {
        public ViewTransactions()
        {
            InitializeComponent();
            listView_customers.View = View.Details;
            listView_customers.GridLines = true;
            listView_customers.FullRowSelect = true;

            //Add column header
            listView_customers.Columns.Add("Customer Name", 250);
            listView_customers.Columns.Add("Amount", 60);

            string[] arr = new string[3];
            ListViewItem itm;

            if (MainScreen.m_dbConnection.State == ConnectionState.Closed)
                MainScreen.m_dbConnection.Open();
            string sql = "select * from Customers";
            SQLiteCommand command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //MessageBox.Show("Name:" + reader["Name"] + "\tContact: " + reader["Contact"], "List", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
                arr[0] = reader["Name"].ToString();
                arr[1] = reader["Total"].ToString();
                arr[2] = reader["ID"].ToString();
                itm = new ListViewItem(arr);
                listView_customers.Items.Add(itm);
            }

        }

        private void onclick(object sender, EventArgs e)
        {
            //MessageBox.Show(listView_customers.SelectedItems[0].SubItems[2].Text);
            CustomerTransaction ct = new CustomerTransaction(Int32.Parse(listView_customers.SelectedItems[0].SubItems[2].Text), listView_customers.SelectedItems[0].SubItems[0].Text, Int32.Parse(listView_customers.SelectedItems[0].SubItems[1].Text));
            ct.Show();
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
