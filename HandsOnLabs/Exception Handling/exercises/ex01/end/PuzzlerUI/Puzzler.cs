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
using System.Collections.Generic;
using System.Diagnostics;


// TODO: Use Enterpise Library Exception Handling
namespace PuzzlerUI
{
    /// <summary>
    /// Summary description for Puzzler.
    /// </summary>
    public class Puzzler : System.Windows.Forms.Form
    {
        #region Uninteresting Stuff
        internal System.Windows.Forms.Panel pnlPuzzle;
        internal System.Windows.Forms.Button btnMakeWords;
        internal System.Windows.Forms.Label lblResults;
        internal System.Windows.Forms.TextBox txtRequired;
        internal System.Windows.Forms.Label lblMustInclude;
        internal System.Windows.Forms.TextBox txtLetters;
        internal System.Windows.Forms.Label lblMakeWords;
        internal System.Windows.Forms.ListBox lbxWordList;
        internal System.Windows.Forms.Panel pnlSpellCheck;
        internal System.Windows.Forms.Label lblDictionaryInfo;
        internal System.Windows.Forms.TextBox txtWordToCheck;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Puzzler()
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Puzzler));
            this.pnlPuzzle = new System.Windows.Forms.Panel();
            this.btnMakeWords = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.txtRequired = new System.Windows.Forms.TextBox();
            this.lblMustInclude = new System.Windows.Forms.Label();
            this.txtLetters = new System.Windows.Forms.TextBox();
            this.lblMakeWords = new System.Windows.Forms.Label();
            this.lbxWordList = new System.Windows.Forms.ListBox();
            this.pnlSpellCheck = new System.Windows.Forms.Panel();
            this.lblDictionaryInfo = new System.Windows.Forms.Label();
            this.txtWordToCheck = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.pnlPuzzle.SuspendLayout();
            this.pnlSpellCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPuzzle
            // 
            this.pnlPuzzle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPuzzle.Controls.Add(this.btnMakeWords);
            this.pnlPuzzle.Controls.Add(this.lblResults);
            this.pnlPuzzle.Controls.Add(this.txtRequired);
            this.pnlPuzzle.Controls.Add(this.lblMustInclude);
            this.pnlPuzzle.Controls.Add(this.txtLetters);
            this.pnlPuzzle.Controls.Add(this.lblMakeWords);
            this.pnlPuzzle.Controls.Add(this.lbxWordList);
            this.pnlPuzzle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPuzzle.Location = new System.Drawing.Point(0, 96);
            this.pnlPuzzle.Name = "pnlPuzzle";
            this.pnlPuzzle.Size = new System.Drawing.Size(292, 170);
            this.pnlPuzzle.TabIndex = 10;
            // 
            // btnMakeWords
            // 
            this.btnMakeWords.Location = new System.Drawing.Point(200, 32);
            this.btnMakeWords.Name = "btnMakeWords";
            this.btnMakeWords.Size = new System.Drawing.Size(80, 20);
            this.btnMakeWords.TabIndex = 6;
            this.btnMakeWords.Text = "Make Words";
            this.btnMakeWords.Click += new System.EventHandler(this.btnMakeWords_Click);
            // 
            // lblResults
            // 
            this.lblResults.Location = new System.Drawing.Point(8, 64);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(120, 23);
            this.lblResults.TabIndex = 4;
            this.lblResults.Text = "Results:";
            this.lblResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRequired
            // 
            this.txtRequired.Location = new System.Drawing.Point(152, 32);
            this.txtRequired.MaxLength = 1;
            this.txtRequired.Name = "txtRequired";
            this.txtRequired.Size = new System.Drawing.Size(24, 20);
            this.txtRequired.TabIndex = 3;
            this.txtRequired.Text = "";
            // 
            // lblMustInclude
            // 
            this.lblMustInclude.Location = new System.Drawing.Point(8, 32);
            this.lblMustInclude.Name = "lblMustInclude";
            this.lblMustInclude.Size = new System.Drawing.Size(120, 23);
            this.lblMustInclude.TabIndex = 2;
            this.lblMustInclude.Text = "Must include the letter:";
            this.lblMustInclude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLetters
            // 
            this.txtLetters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLetters.Location = new System.Drawing.Point(152, 8);
            this.txtLetters.Name = "txtLetters";
            this.txtLetters.Size = new System.Drawing.Size(128, 20);
            this.txtLetters.TabIndex = 1;
            this.txtLetters.Text = "";
            // 
            // lblMakeWords
            // 
            this.lblMakeWords.Location = new System.Drawing.Point(8, 8);
            this.lblMakeWords.Name = "lblMakeWords";
            this.lblMakeWords.Size = new System.Drawing.Size(152, 23);
            this.lblMakeWords.TabIndex = 0;
            this.lblMakeWords.Text = "Make words from the letters:";
            this.lblMakeWords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbxWordList
            // 
            this.lbxWordList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxWordList.Location = new System.Drawing.Point(152, 56);
            this.lbxWordList.Name = "lbxWordList";
            this.lbxWordList.Size = new System.Drawing.Size(128, 95);
            this.lbxWordList.TabIndex = 5;
            // 
            // pnlSpellCheck
            // 
            this.pnlSpellCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSpellCheck.Controls.Add(this.lblDictionaryInfo);
            this.pnlSpellCheck.Controls.Add(this.txtWordToCheck);
            this.pnlSpellCheck.Controls.Add(this.Label1);
            this.pnlSpellCheck.Controls.Add(this.btnAddWord);
            this.pnlSpellCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpellCheck.Location = new System.Drawing.Point(0, 0);
            this.pnlSpellCheck.Name = "pnlSpellCheck";
            this.pnlSpellCheck.Size = new System.Drawing.Size(292, 96);
            this.pnlSpellCheck.TabIndex = 9;
            // 
            // lblDictionaryInfo
            // 
            this.lblDictionaryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDictionaryInfo.Location = new System.Drawing.Point(8, 8);
            this.lblDictionaryInfo.Name = "lblDictionaryInfo";
            this.lblDictionaryInfo.Size = new System.Drawing.Size(264, 32);
            this.lblDictionaryInfo.TabIndex = 0;
            this.lblDictionaryInfo.Text = "lblDictionaryInfo";
            // 
            // txtWordToCheck
            // 
            this.txtWordToCheck.Location = new System.Drawing.Point(96, 56);
            this.txtWordToCheck.Name = "txtWordToCheck";
            this.txtWordToCheck.Size = new System.Drawing.Size(88, 20);
            this.txtWordToCheck.TabIndex = 2;
            this.txtWordToCheck.Text = "";
            this.txtWordToCheck.TextChanged += new System.EventHandler(this.txtWordToCheck_TextChanged);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 56);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(88, 20);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Word To check:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(200, 56);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(75, 20);
            this.btnAddWord.TabIndex = 3;
            this.btnAddWord.Text = "Add Word";
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Puzzler
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.pnlPuzzle);
            this.Controls.Add(this.pnlSpellCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Puzzler";
            this.Text = "Puzzler";
            this.Load += new System.EventHandler(this.Puzzler_Load);
            this.pnlPuzzle.ResumeLayout(false);
            this.pnlSpellCheck.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        private void Puzzler_Load(object sender, System.EventArgs e)
        {
            lblDictionaryInfo.Text = PuzzlerService.Dictionary.GetDictionaryInfo();
        }

        private void txtWordToCheck_TextChanged(object sender, System.EventArgs e)
        {
            // Now ask the Dictionary if it is a recognised word
            if (PuzzlerService.Dictionary.CheckSpelling(txtWordToCheck.Text))
            {
                errorProvider1.SetError(txtWordToCheck, "");
            }
            else
            {
                errorProvider1.SetError(txtWordToCheck, "Word not found");
            }
        }

        private void btnAddWord_Click(object sender, System.EventArgs e)
        {
            PuzzlerService.Dictionary.AddWord(txtWordToCheck.Text);
            errorProvider1.SetError(txtWordToCheck, "");
        }

        private void btnMakeWords_Click(object sender, System.EventArgs e)
        {
            lbxWordList.DataSource = PuzzlerService.WordGenerator.GenerateWords(
                txtLetters.Text, txtRequired.Text);
        }

        
    }
}
