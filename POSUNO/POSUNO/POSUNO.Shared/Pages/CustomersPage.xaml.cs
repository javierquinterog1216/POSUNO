﻿using POSUNO.Component;
using POSUNO.Dialogs;
using POSUNO.Helpers;
using POSUNO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace POSUNO.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomersPage : Page
    {
        public CustomersPage()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Customer> Customers { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadCustomersAsync();
        }

        private async void LoadCustomersAsync()
        {
            Loader loader = new Loader("por favor espere...");
            loader.Show();
            Response response = await ApiService.GetListAsync<Customer>("Customers");
            loader.Close();

            if (!response.IsSuccess)
            {
                MessageDialog dialog = new MessageDialog(response.Message, "Error");
                await dialog.ShowAsync();
                return;
            }

            List<Customer> customers = (List<Customer>)response.Result;
            Customers = new ObservableCollection<Customer>(customers);
            RefreshList();
        }

        private void RefreshList()
        {
            CustomersListView.ItemsSource = null;
            CustomersListView.Items.Clear();
            CustomersListView.ItemsSource = Customers;
        }

        private async void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            CustomerDialog customerDialog = new CustomerDialog(customer);
            await customerDialog.ShowAsync();
        }

        private async void EditImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Customer customer = Customers[CustomersListView.SelectedIndex];
            customer.IsEdit = true;
            CustomerDialog customerDialog = new CustomerDialog(customer);
            await customerDialog.ShowAsync();
        }
    }
}

