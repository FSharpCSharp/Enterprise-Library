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
using System.Windows.Forms;

namespace EnoughPI
{
    public class EntryPoint
    {
        private EntryPoint() {}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.ThreadException += 
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            
            Form entryForm = new MainForm();
            Application.EnableVisualStyles();
            Application.Run(entryForm);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string message;
            message = string.Format("Exception:\n\n{0}\n\nDo you want to Continue [Yes], or Quit [No]?", e.Exception);

            DialogResult dr;
            dr = MessageBox.Show(message, "Application Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No) 
                Application.Exit();
        }
    }
}
