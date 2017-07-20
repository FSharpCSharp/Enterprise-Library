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
using System.Collections.Generic;
using System.Configuration;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace InterceptionHOL
{
    public partial class MainForm : Form
    {
        private BusinessLogic.BankAccount bankAccount;
        private IUnityContainer container;

        public MainForm()
        {
            InitializeComponent();
            InitializeContainer();
            PopulateUserList();
            bankAccount = container.Resolve<BusinessLogic.BankAccount>();
        }

        private void InitializeContainer()
        {
            container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<BusinessLogic.BankAccount>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<TransparentProxyInterceptor>());
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            AmountEntryForm form = new AmountEntryForm(AmountDialogType.Deposit);
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                exceptionTextBox.Text = String.Empty;
                try
                {
                    bankAccount.Deposit(form.Amount);
                }
                catch (Exception ex)
                {
                    exceptionTextBox.Text = ex.Message;
                }
            }
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            AmountEntryForm form = new AmountEntryForm(AmountDialogType.Withdraw);
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                exceptionTextBox.Text = String.Empty;
                try
                {
                    bankAccount.Withdraw(form.Amount);
                }
                catch (Exception ex)
                {
                    exceptionTextBox.Text = ex.Message;
                }
            }
        }

        private void balanceInquiryButton_Click(object sender, EventArgs e)
        {
            exceptionTextBox.Text = String.Empty;
            try
            {
                balanceTextBox.Text = bankAccount.GetCurrentBalance().ToString();
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.Message;
            }
        }

        private void PopulateUserList()
        {

            const string userPrefix = "User:";
            foreach (string setting in ConfigurationManager.AppSettings)
            {
                if (setting.StartsWith(userPrefix))
                {
                    string userName = setting.Substring(userPrefix.Length);
                    string role = ConfigurationManager.AppSettings[setting];
                    IPrincipal principal = new GenericPrincipal(
                        new GenericIdentity(userName), new string[] { role });
                    userComboBox.Items.Add(new KeyValuePair<string, IPrincipal>(userName, principal));
                }
            }
            userComboBox.SelectedIndex = 0;
        }

        private void userComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obviously, you wouldn't implement security like this in a real application. 

            // Find the principal of the selected user. 
            KeyValuePair<string, IPrincipal> pair = (KeyValuePair<string, IPrincipal>)userComboBox.SelectedItem;
            IPrincipal selectedUser = pair.Value;

            // Set the current thread principal to the selected user
            System.Threading.Thread.CurrentPrincipal = selectedUser;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            container.Dispose();
            Application.Exit();
        }
    }
}
