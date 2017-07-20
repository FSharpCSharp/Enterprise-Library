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
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ValidationHOL.BusinessLogic;

namespace ValidationHOL.Wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            grd.DataContext = new Customer();
        }

        private void validate(object sender, TextChangedEventArgs e)
        {
            var items = new List<object>();

            foreach (var ctrl in grd.Children.OfType<TextBox>())
            {
                foreach (var item in Validation.GetErrors((DependencyObject)ctrl))
                {
                    items.Add(item.ErrorContent);
                }
            }

            if (items.Count == 0)
            {
                items.Add("Validation OK");
            }

            lstErrors.ItemsSource = items;
        }
    }
}
