using POSUNO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace POSUNO.Dialogs
{
    public sealed partial class CustomerDialog : ContentDialog
    {
        public CustomerDialog(Customer customer)
        {
            this.InitializeComponent();
            Customer = customer;
            if (Customer.IsEdit)
            {
                TitleTextBlock.Text = $"Editar el Cliente: {Customer.FullName}";
            }
            else {
                TitleTextBlock.Text = "Nuevo Cliente";
            }
        }

        public Customer Customer { get; set; }

        private  void CloseImage_Tapped(object sender, TappedRoutedEventArgs e) {
            Hide();        
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private  void SaveButton_Click(object sender, RoutedEventArgs e) {
            Hide();
        }
    }
}
