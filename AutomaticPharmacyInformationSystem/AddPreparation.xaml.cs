using System;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace AutomaticPharmacyInformationSystem
{
    public partial class AddPreparation
    {
        public AddPreparation(preparation selectedpreparation)
        {
            InitializeComponent();
            producer.MaxLength = 55;
            form.MaxLength = 25;
            name.MaxLength = 55;
            price.MaxLength = 15;
            amount.MaxLength = 15;

            if (selectedpreparation != null)
                preparationCurrent = selectedpreparation;

            DataContext = preparationCurrent;
        }

        private preparation preparationCurrent = new preparation();
        
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin windowAdmin = new MainWindowAdmin();
            windowAdmin.Show();
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            if (preparationCurrent.producer == null || string.IsNullOrWhiteSpace(producer.Text))
                errors.AppendLine("Производитель перпарата отсутсвует");
            if (preparationCurrent.release_form == null || string.IsNullOrWhiteSpace(form.Text))
                errors.AppendLine("Форма выпуска отсутвует");
            if (preparationCurrent.drug_name == null || string.IsNullOrWhiteSpace(name.Text))
                errors.AppendLine("Название перпарата отсутсвует");
            if (preparationCurrent.price < 0 || preparationCurrent.price > 100000 || string.IsNullOrWhiteSpace(price.Text))
                errors.AppendLine("Цена указа не коректно");
            if (preparationCurrent.amount < 0 || preparationCurrent.amount > 100000 || string.IsNullOrWhiteSpace(amount.Text))
                errors.AppendLine("Количество указано не коректно");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            
            if(preparationCurrent.id_preparation == 0)
                PharmacySystemEntities.GetContext().preparation.Add(preparationCurrent);
            
            try
            {
                PharmacySystemEntities.GetContext().SaveChanges();
                if (MessageBox.Show("Продолжить операцию?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MainWindowAdmin windowAdmin = new MainWindowAdmin();
                    windowAdmin.Show();
                    Close();
                }
                else
                {
                    AddPreparation repeetAdd = new AddPreparation(null);
                    repeetAdd.Show();
                    Close();
                }
            }
            catch (Exception exception)
            {
               MessageBox.Show(exception.Message);
            }
        }

        private void TextBox_PreviewTextInputPrice(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e. Text, 0)) 
                e.Handled = true;
        }

        private void TextBox_PreviewTextInputCount(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e. Text, 0)) 
                e.Handled = true;
            if (!Char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void Amount_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                e.Handled = true;
        }

        private void Price_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                e.Handled = true;
        }
        
        private void Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
    }
}
