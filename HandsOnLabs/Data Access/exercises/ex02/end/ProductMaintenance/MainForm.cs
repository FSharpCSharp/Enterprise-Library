//===============================================================================
// Microsoft patterns & practices
// Enterprise Library 6 and Unity 3 Hands-on Labs
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
// TODO: Use Enterprise Library Data Block
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;

namespace ProductMaintenance
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        #region Uninteresting Windows Stuff
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DataGrid dgProducts;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private ProductMaintenance.ProductsDataSet dsProducts;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dgProducts = new System.Windows.Forms.DataGrid();
            this.dsProducts = new ProductMaintenance.ProductsDataSet();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 48);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(304, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.Location = new System.Drawing.Point(120, 14);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(176, 21);
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // dgProducts
            // 
            this.dgProducts.DataMember = "Products";
            this.dgProducts.DataSource = this.dsProducts;
            this.dgProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProducts.Location = new System.Drawing.Point(0, 48);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(384, 223);
            this.dgProducts.TabIndex = 1;
            // 
            // dsProducts
            // 
            this.dsProducts.DataSetName = "ProductsDataSet";
            this.dsProducts.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(384, 271);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Produce Maintenance";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProducts)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        private static DatabaseProviderFactory factory = new DatabaseProviderFactory();
        private Database _db = factory.Create("QuickStarts Instance");

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            this.cmbCategory.Items.Clear();

            using (IDataReader dataReader = _db.ExecuteReader("GetCategories"))
            {
                // Processing code 
                while (dataReader.Read())
                {
                    Category item = new Category(
                        dataReader.GetInt32(0),
                        dataReader.GetString(1),
                        dataReader.GetString(2));

                    this.cmbCategory.Items.Add(item);
                }
            }

            if (this.cmbCategory.Items.Count > 0)
                this.cmbCategory.SelectedIndex = 0;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.dsProducts.Clear();

            Category selectedCategory = (Category)this.cmbCategory.SelectedItem;
            if (selectedCategory == null)
                return;

            _db.LoadDataSet(
                "GetProductsByCategory",
                this.dsProducts,
                new string[] { "Products" },
                selectedCategory.CategoryId);
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            DbCommand insertCommand = null;
            insertCommand = _db.GetStoredProcCommand("HOLAddProduct");
            _db.AddInParameter(insertCommand, "ProductName",
                DbType.String, "ProductName", DataRowVersion.Current);
            _db.AddInParameter(insertCommand, "CategoryID",
                DbType.Int32, "CategoryID", DataRowVersion.Current);
            _db.AddInParameter(insertCommand, "UnitPrice",
                DbType.Currency, "UnitPrice", DataRowVersion.Current);

            DbCommand deleteCommand = null;
            deleteCommand = _db.GetStoredProcCommand("HOLDeleteProduct");
            _db.AddInParameter(deleteCommand, "ProductID",
                DbType.Int32, "ProductID", DataRowVersion.Current);
            _db.AddInParameter(deleteCommand, "LastUpdate",
                DbType.DateTime, "LastUpdate", DataRowVersion.Original);

            DbCommand updateCommand = null;
            updateCommand = _db.GetStoredProcCommand("HOLUpdateProduct");
            _db.AddInParameter(updateCommand, "ProductID",
                DbType.Int32, "ProductID", DataRowVersion.Current);
            _db.AddInParameter(updateCommand, "ProductName",
                DbType.String, "ProductName", DataRowVersion.Current);
            _db.AddInParameter(updateCommand, "CategoryID",
                DbType.Int32, "CategoryID", DataRowVersion.Current);
            _db.AddInParameter(updateCommand, "UnitPrice",
                DbType.Currency, "UnitPrice", DataRowVersion.Current);
            _db.AddInParameter(updateCommand, "LastUpdate",
                DbType.DateTime, "LastUpdate", DataRowVersion.Current);

            int rowsAffected = _db.UpdateDataSet(
                this.dsProducts,
                "Products",
                insertCommand,
                updateCommand,
                deleteCommand,
                UpdateBehavior.Standard);
        }
    }
}
