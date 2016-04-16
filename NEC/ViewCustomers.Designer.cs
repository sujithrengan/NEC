namespace NEC
{
    partial class ViewTransactions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_customers = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView_customers
            // 
            this.listView_customers.Location = new System.Drawing.Point(12, 12);
            this.listView_customers.Name = "listView_customers";
            this.listView_customers.Size = new System.Drawing.Size(310, 363);
            this.listView_customers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_customers.TabIndex = 0;
            this.listView_customers.UseCompatibleStateImageBehavior = false;
            this.listView_customers.View = System.Windows.Forms.View.Details;
            this.listView_customers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_customers_ColumnClick_1);
            this.listView_customers.DoubleClick += new System.EventHandler(this.onclick);
            // 
            // ViewTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 387);
            this.Controls.Add(this.listView_customers);
            this.Name = "ViewTransactions";
            this.Text = "ViewCustomers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_customers;
    }
}