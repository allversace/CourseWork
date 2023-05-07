using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutomaticPharmacyInformationSystem
{
    public partial class MainWindow
    {
        public MainWindow(string loginBox)
        {
            InitializeComponent();
            PreviewLogin.Text = loginBox;
            DataGridBasket.IsReadOnly = true;
            DataGridIndent.IsReadOnly = true;
            DataGridPersonalOrderDetails.IsReadOnly = true;
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

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) ==
                MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void UpdatePreparation()
        {
            var currentSearch = PharmacySystemEntities.GetContext().preparation.ToList();
            var currentPreparationName = currentSearch;
            currentPreparationName = currentPreparationName
                .Where(p => p.drug_name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            LViewPreparation.ItemsSource = currentPreparationName;
        }
        
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PharmacySystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewPreparation.ItemsSource = PharmacySystemEntities.GetContext().preparation.ToList();
            }
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePreparation();
        }
        
        private void Client_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти к авторизации?", "Внимание!", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Login login = new Login();
                login.Show();
                Close();
            }
        }

        private void Preparation_Click(object sender, RoutedEventArgs e)
        {
            DataGridBasket.Visibility = Visibility.Hidden;
            SetBasket.Visibility = Visibility.Hidden;
            ChangeAmountAddBasket.Visibility = Visibility.Hidden;
            ChangeAmountDeleteBasket.Visibility = Visibility.Hidden;
            DeleteBasket.Visibility = Visibility.Hidden;
            Count.Visibility = Visibility.Hidden;
            LabelTotalPrice.Visibility = Visibility.Hidden;
            TotalPrice.Visibility = Visibility.Hidden;
            DataGridIndent.Visibility = Visibility.Hidden;
            DataGridInforamtionIndent.Visibility = Visibility.Hidden;
            DataGridPersonalOrderDetails.Visibility = Visibility.Hidden;
            CloseDataGridPersonalOrderDetails.Visibility = Visibility.Hidden;
            DataGridIndentPreview.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Visible;
            LViewPreparation.Visibility = Visibility.Visible;
        }
        
        private void LViewPreparation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            preparation selectedPreparation = (preparation)LViewPreparation.SelectedItem;
            order_details existedDetails =
                OrderDetailsList.Find(detail => detail.id_preparation == selectedPreparation.id_preparation);
            order_details countDetails = OrderDetailsList.Find(detail => detail.amount == selectedPreparation.amount);

            if (countDetails == null && selectedPreparation.amount != 0)
            {
                if (existedDetails != null)
                {
                    existedDetails.amount += 1;
                    return;
                }

                if (LViewPreparation.SelectedItem != null)
                {
                    order_details details = PharmacySystemEntities.GetContext().order_details.Create();
                    details.id_preparation = selectedPreparation.id_preparation;
                    details.preparation = selectedPreparation;
                    details.amount = 1;
                    OrderDetailsList.Add(details);
                    MessageBox.Show("Препарат в корзине");
                }
            }
            else
            {
                MessageBox.Show("Такого количества препарата нет.");
            }
        }
        
        private void Basket_Click(object sender, RoutedEventArgs e)
        {
            DataGridBasket.ItemsSource = OrderDetailsList.Select(detail =>
            {
                Debug.Assert(detail.amount != null);
                return new DetailClass
                {
                    id_preparation = detail.id_preparation,
                    drug_name = detail.preparation.drug_name,
                    price = detail.preparation.price,
                    amount = (int)detail.amount,
                    total_price = (int)(detail.preparation.price * detail.amount)
                };
            });

            int totalSum = OrderDetailsList.Aggregate(0, (acc, item) => acc + item.total_price);
            TotalPrice.Text = totalSum.ToString();

            LViewPreparation.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            DataGridIndent.Visibility = Visibility.Hidden;
            DataGridInforamtionIndent.Visibility = Visibility.Hidden;
            DataGridPersonalOrderDetails.Visibility = Visibility.Hidden;
            CloseDataGridPersonalOrderDetails.Visibility = Visibility.Hidden;
            DataGridIndentPreview.Visibility = Visibility.Hidden;
            Count.Visibility = Visibility.Visible;
            DeleteBasket.Visibility = Visibility.Visible;
            ChangeAmountDeleteBasket.Visibility = Visibility.Visible;
            ChangeAmountAddBasket.Visibility = Visibility.Visible;
            LabelTotalPrice.Visibility = Visibility.Visible;
            TotalPrice.Visibility = Visibility.Visible;
            SetBasket.Visibility = Visibility.Visible;
            DataGridBasket.Visibility = Visibility.Visible;
        }
        
        private void ChangeAmountAddBasket_Click(object sender, RoutedEventArgs e)
        {
            preparation selectedPreparationListView = (preparation)LViewPreparation.SelectedItem;
            var selectedPreparationDataGrid = (DetailClass)DataGridBasket.SelectedItem;

            if (DataGridBasket.SelectedItem != null)
            {
                order_details countDetails =
                    OrderDetailsList.Find(detail => detail.amount == selectedPreparationListView.amount);
                if (countDetails == null)
                {
                    order_details existedDetails = OrderDetailsList.Find(detail =>
                        detail.id_preparation == selectedPreparationDataGrid.id_preparation);
                    if (existedDetails != null &&
                        selectedPreparationListView.amount > selectedPreparationDataGrid.amount)
                    {
                        existedDetails.amount += 1;
                        DataGridBasket.ItemsSource = OrderDetailsList.Select(detail =>
                        {
                            return new DetailClass
                            {
                                id_preparation = detail.id_preparation,
                                drug_name = detail.preparation.drug_name,
                                price = detail.preparation.price,
                                amount = (int)detail.amount,
                                total_price = (int)(detail.preparation.price * detail.amount)
                            };
                        });
                    }
                }
                else
                {
                    MessageBox.Show("Такого количества препарата нет.");
                }
            }

            int totalSum = OrderDetailsList.Aggregate(0, (acc, item) => acc + item.total_price);
            TotalPrice.Text = totalSum.ToString();
        }

        private void ChangeAmountDeleteBasket_Click(object sender, RoutedEventArgs e)
        {

            var selectedPreparation = (DetailClass)DataGridBasket.SelectedItem;
            if (selectedPreparation != null)

                if (DataGridBasket.SelectedItem != null)
                {
                    order_details existedDetails = OrderDetailsList.Find(detail =>
                        detail.id_preparation == selectedPreparation.id_preparation);
                    if (existedDetails.amount > 1)
                    {
                        existedDetails.amount -= 1;
                        DataGridBasket.ItemsSource = OrderDetailsList.Select(detail =>
                        {
                            return new DetailClass
                            {
                                id_preparation = detail.id_preparation,
                                drug_name = detail.preparation.drug_name,
                                price = detail.preparation.price,
                                amount = (int)detail.amount,
                                total_price = (int)(detail.preparation.price * detail.amount)
                            };
                        });
                    }
                    else
                    {
                        OrderDetailsList = OrderDetailsList
                            .Where(p => p.id_preparation != selectedPreparation.id_preparation).ToList();
                        DataGridBasket.ItemsSource = OrderDetailsList.Select(detail => new DetailClass
                        {
                            id_preparation = detail.preparation.id_preparation,
                            drug_name = detail.preparation.drug_name,
                            price = detail.preparation.price,
                            amount = (int)detail.amount,
                            total_price = (int)(detail.preparation.price * detail.amount),
                        });
                    }
                }

            var totalSum = OrderDetailsList.Aggregate(0, (acc, item) => acc + item.total_price);
            TotalPrice.Text = totalSum.ToString();
        }

        private void DeleteBasket_Click(object sender, RoutedEventArgs e)
        {
            var selectedPreparation = (DetailClass)DataGridBasket.SelectedItem;
            if (selectedPreparation != null)
                OrderDetailsList = OrderDetailsList.Where(p => p.id_preparation != selectedPreparation.id_preparation)
                    .ToList();
            DataGridBasket.ItemsSource = OrderDetailsList.Select(detail => new DetailClass
            {
                id_preparation = detail.preparation.id_preparation,
                drug_name = detail.preparation.drug_name,
                price = detail.preparation.price,
                amount = (int)detail.amount,
                total_price = (int)(detail.preparation.price * detail.amount)
            });
            var totalSum = OrderDetailsList.Aggregate(0, (acc, item) => acc + item.total_price);
            TotalPrice.Text = totalSum.ToString();
        }

        private List<order_details> OrderDetailsList = new List<order_details>();

        private void SetBasket_Click(object sender, RoutedEventArgs e)
        {

            preparation selectedPreparation = (preparation)LViewPreparation.SelectedItem;
            if (selectedPreparation != null)
                if (selectedPreparation.amount <= 0)
                {
                    MessageBox.Show("Препарат отсутсвует в наличии");
                }
                else
                {
                    if (OrderDetailsList.Count > 0)
                    {
                        indent details = PharmacySystemEntities.GetContext().indent.Create();
                        int totalSum = OrderDetailsList.Aggregate(0, (acc, item) => acc + item.total_price);
                        TotalPrice.Text = totalSum.ToString();
                        details.login = PreviewLogin.Text;
                        details.data_indent = DateTime.Now;
                        details.id_status_indent = 1;
                        details.total_sum = totalSum;

                        foreach (order_details orderDetail in OrderDetailsList)
                        {
                            details.order_details.Add(orderDetail);
                        }

                        PharmacySystemEntities.GetContext().indent.Add(details);
                        PharmacySystemEntities.GetContext().SaveChanges();

                        PrintOrder.Print(details, PreviewLogin.Text, totalSum, OrderDetailsList);

                        OrderDetailsList.Clear();

                        DataGridBasket.ItemsSource = OrderDetailsList.Select(detail => new DetailClass
                        {
                            id_preparation = detail.id_preparation,
                            drug_name = detail.preparation.drug_name,
                            price = detail.preparation.price,
                            amount = (int)detail.amount,
                            total_price = (int)(detail.preparation.price * detail.amount)
                        });
                        MessageBox.Show("Заказ успешно сформирован. Подробности можно узнать во вкладке ~Заказы~");
                    }
                    else
                        MessageBox.Show("Ваша корзина пуста.");
                }
        }

        private void CloseDataGridPersonalOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            CloseDataGridPersonalOrderDetails.Visibility = Visibility.Hidden;
            DataGridPersonalOrderDetails.Visibility = Visibility.Hidden;
            DataGridIndentPreview.Visibility = Visibility.Visible;
            DataGridIndent.Visibility = Visibility.Visible;
            DataGridInforamtionIndent.Visibility = Visibility.Visible;
        }
        
        private void Indent_Click(object sender, RoutedEventArgs e)
        {
            LViewPreparation.Visibility = Visibility.Hidden;
            CloseDataGridPersonalOrderDetails.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            DataGridBasket.Visibility = Visibility.Hidden;
            SetBasket.Visibility = Visibility.Hidden;
            ChangeAmountAddBasket.Visibility = Visibility.Hidden;
            ChangeAmountDeleteBasket.Visibility = Visibility.Hidden;
            DeleteBasket.Visibility = Visibility.Hidden;
            Count.Visibility = Visibility.Hidden;
            LabelTotalPrice.Visibility = Visibility.Hidden;
            DataGridPersonalOrderDetails.Visibility = Visibility.Hidden;
            TotalPrice.Visibility = Visibility.Hidden;
            DataGridIndent.Visibility = Visibility.Visible;
            DataGridInforamtionIndent.Visibility = Visibility.Visible;
            DataGridIndentPreview.Visibility = Visibility.Visible;

            var currentIndent = PharmacySystemEntities.GetContext().indent.Where(p => p.login == PreviewLogin.Text)
                .ToList();
            DataGridIndent.ItemsSource = currentIndent;

        }
        
        private void DataGridIndentPreview_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedIndentOpen = (indent)DataGridIndent.SelectedItem;
            try
            {
                var filePath = @"C:\Users\artur\OneDrive\Рабочий стол\Курсовая работа\Заказ " +
                               selectedIndentOpen.id_indent + ".docx";
                Process.Start(filePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DataGridInforamtionIndent_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndent = (indent)DataGridIndent.SelectedItem;
            if (selectedIndent != null)
            {
                LViewPreparation.Visibility = Visibility.Hidden;
                Search.Visibility = Visibility.Hidden;
                DataGridBasket.Visibility = Visibility.Hidden;
                SetBasket.Visibility = Visibility.Hidden;
                ChangeAmountAddBasket.Visibility = Visibility.Hidden;
                ChangeAmountDeleteBasket.Visibility = Visibility.Hidden;
                DeleteBasket.Visibility = Visibility.Hidden;
                Count.Visibility = Visibility.Hidden;
                LabelTotalPrice.Visibility = Visibility.Hidden;
                TotalPrice.Visibility = Visibility.Hidden;
                DataGridIndent.Visibility = Visibility.Hidden;
                DataGridInforamtionIndent.Visibility = Visibility.Hidden;
                DataGridIndentPreview.Visibility = Visibility.Hidden;
                DataGridPersonalOrderDetails.Visibility = Visibility.Visible;
                CloseDataGridPersonalOrderDetails.Visibility = Visibility.Visible;
                
                var currentIndent = PharmacySystemEntities.GetContext().order_details
                .Where(p => p.id_indent == selectedIndent.id_indent).ToList();
                DataGridPersonalOrderDetails.ItemsSource = currentIndent;
                DataGridIndent.SelectedIndex = -1;
            }
        }
    }
}