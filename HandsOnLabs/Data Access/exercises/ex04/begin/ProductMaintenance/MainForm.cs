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
using System.Linq;



namespace ProductMaintenance
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        #region Uninteresting Windows Stuff
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGrid dgProducts;
        private Label label2;
        private Button btnClear;
        private NumericUpDown numTax;
        private Button btnCalculate;
        private Label label1;
        private ComboBox cmbCategory;
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.numTax = new System.Windows.Forms.NumericUpDown();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dgProducts = new System.Windows.Forms.DataGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.numTax);
            this.panel1.Controls.Add(this.btnCalculate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 48);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(414, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tax";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(604, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // numTax
            // 
            this.numTax.Location = new System.Drawing.Point(448, 12);
            this.numTax.Name = "numTax";
            this.numTax.Size = new System.Drawing.Size(69, 20);
            this.numTax.TabIndex = 10;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(523, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.DropDownWidth = 350;
            this.cmbCategory.Location = new System.Drawing.Point(65, 12);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(325, 21);
            this.cmbCategory.TabIndex = 7;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // dgProducts
            // 
            this.dgProducts.DataMember = "";
            this.dgProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProducts.Location = new System.Drawing.Point(0, 48);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(690, 220);
            this.dgProducts.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(690, 268);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Produce Maintenance";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        // TODO: Create private fields for Data accessors

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            // TODO: Create the accessors

            this.cmbCategory.DisplayMember = "Name";
            this.cmbCategory.ValueMember = "ID";

            // TODO: Use a Data Accessor to retrieve Categories

            if (this.cmbCategory.Items.Count > 0)
                this.cmbCategory.SelectedIndex = 0;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // TODO: Retrieve Products by Category
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // TODO: Retrieve Products by Category
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.dgProducts.DataSource = null;
            this.numTax.Value = 0;
        }

        private void InitializeAccessors()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            // TODO: Create category accessor

            // TODO: Create product accessor
        }

        private decimal ApplyTax(IDataRecord record)
        {
            var unitPrice = (decimal)record["UnitPrice"];
            if (numTax.Value > 0)
            {
                unitPrice += unitPrice * numTax.Value / 100;
            }
            return unitPrice;
        }

    }
}
