using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutomaticPharmacyInformationSystem
{
    public partial class MainWindowAdmin
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
            TBoxSearch.MaxLength = 55;
            
            DataGridEditOrder.ItemsSource = PharmacySystemEntities.GetContext().indent.ToList();
            var currentPreparation = PharmacySystemEntities.GetContext().preparation.ToList();
            LViewPreparation.ItemsSource = currentPreparation;
            var currentStatus = PharmacySystemEntities.GetContext().status_indent.ToList();
            EditStatus.ItemsSource = currentStatus;
        }
        
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) ==
                MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
            }
        }

        private void UpdateInformation()
        {
            var currentPreparation = PharmacySystemEntities.GetContext().preparation.ToList();
            currentPreparation = currentPreparation
                .Where(p => p.drug_name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            LViewPreparation.ItemsSource = currentPreparation;
        }
        
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateInformation();
        }
        
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PharmacySystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewPreparation.ItemsSource = PharmacySystemEntities.GetContext().preparation.ToList();
            }
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти к авторизации?", "Внимание!", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Login Login = new Login();
                Login.Show();
                Close();
            }
        }
        
        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            SignupAdmin AddAdmin = new SignupAdmin();
            AddAdmin.Show();
            Close();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти к авторизации?", "Внимание!", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Login Login = new Login();
                Login.Show();
                Close();
            }
        }

        private void Preparation_Click(object sender, RoutedEventArgs e)
        {
            LViewPreparation.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Visible;
            DataGridEditOrder.Visibility = Visibility.Hidden;
            EditStatus.Visibility = Visibility.Hidden;
            selectedIndentPreview.Visibility = Visibility.Hidden;
            previewText.Visibility = Visibility.Hidden;
        }
        
        private void DeletePreparaation_Click(object sender, RoutedEventArgs e)
        {
            var deletePreparation = LViewPreparation.SelectedItems.Cast<preparation>();

            if (LViewPreparation.SelectedItem != null)
            {
                if (MessageBox.Show("Вы хотите удалить препарат безвозвратно?", "Внимание!", MessageBoxButton.YesNo,
                        MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        PharmacySystemEntities.GetContext().preparation.RemoveRange(deletePreparation);
                        PharmacySystemEntities.GetContext().SaveChanges();
                        LViewPreparation.ItemsSource = PharmacySystemEntities.GetContext().preparation.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                LViewPreparation.SelectedIndex = -1;
            }
        }

        private void AddPreparation_Click(object sender, RoutedEventArgs e)
        {
            AddPreparation add = new AddPreparation(null);
            add.Show();
            Close();
        }

        private void LViewPreparation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentPreparation = LViewPreparation.SelectedItem as preparation;
            if (LViewPreparation.SelectedItem != null)
            {
                AddPreparation edit = new AddPreparation(currentPreparation);
                edit.Show();
                Close();
                LViewPreparation.SelectedIndex = -1;
            }
        }
        
        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            Search.Visibility = Visibility.Hidden;
            LViewPreparation.Visibility = Visibility.Hidden;
            DataGridEditOrder.Visibility = Visibility.Visible;
            EditStatus.Visibility = Visibility.Visible;
            selectedIndentPreview.Visibility = Visibility.Visible;
            previewText.Visibility = Visibility.Visible;
        }

        private void EditStatus_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = DataGridEditOrder.SelectedItem as indent;
            var selectedItemComboBox = EditStatus.SelectedItem as status_indent;

            if (selectedItemComboBox == null && selectedItem == null)
            {
                MessageBox.Show("Выберите номер заказа!");
            }
            selectedItem.id_status_indent = selectedItemComboBox.id_status_indent;
                switch (selectedItem.id_status_indent)
                {
                    case 1:
                    case 2:
                        selectedItem.data_delivery = null;
                        break;
                    case 3:
                    {
                        DateTime dateNow = DateTime.Now;
                        selectedItem.data_delivery = dateNow;
                        break;
                    }
                }
                PharmacySystemEntities.GetContext().SaveChanges();
                DataGridEditOrder.ItemsSource = PharmacySystemEntities.GetContext().indent.ToList();
        }

        private void DataGridEditOrder_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(DataGridEditOrder.SelectedItem is indent selectedItem)) return;
            EditStatus.IsEnabled = true;
            selectedIndentPreview.Content = selectedItem.id_indent.ToString();
            var selectIndexStatus = int.Parse(selectedItem.id_status_indent.ToString());
            if (selectIndexStatus == 1)
                selectIndexStatus = 0;
            if (selectIndexStatus == 2)
                selectIndexStatus = 1;
            if (selectIndexStatus == 3)
                selectIndexStatus = 2;
            EditStatus.SelectedIndex = selectIndexStatus;


        }
    }
}