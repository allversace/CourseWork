using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;

namespace AutomaticPharmacyInformationSystem
{
    public partial class Signup
    {
        public Signup()
        {
            InitializeComponent();
            loginBox.MaxLength = 25;
            passwordBox.MaxLength = 25;
            passwordBoxRepeat.MaxLength = 25;
            SecondName.MaxLength = 25;
            FirstName.MaxLength = 25;
            Surname.MaxLength = 25;
            NumberPhone.MaxLength = 11;
        }
        
        private account currentRegestration = new account();
        
        private void RegistrationAccount(object sender, RoutedEventArgs e)
        {
            currentRegestration.login = loginBox.Text;
            currentRegestration.second_name = SecondName.Text;
            currentRegestration.first_name = FirstName.Text;
            currentRegestration.surname = Surname.Text;
            currentRegestration.telephone = NumberPhone.Text; 
            var password = passwordBox.Text;
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            currentRegestration.password = BCrypt.Net.BCrypt.HashPassword(password, salt);

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(loginBox.Text))
                errors.AppendLine("Не указан Логин");
            if (string.IsNullOrWhiteSpace(password)  || passwordBox.Text.Length < 8)
                errors.AppendLine("Не указан Пароль или количество символов меньше 8");
            if (string.IsNullOrWhiteSpace(password) || passwordBox.Text != passwordBoxRepeat.Text)
                errors.AppendLine("Не указан Повторный пароль или Пароли не совпадают");
            if (string.IsNullOrWhiteSpace(SecondName.Text))
                errors.AppendLine("Не указана Фамилия");
            if (string.IsNullOrWhiteSpace(FirstName.Text))
                errors.AppendLine("Не указано Имя");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (Surname.Text == "")
                if (MessageBox.Show("Отсутсвует отчество, ввести его?", "Внимание!", MessageBoxButton.YesNo,
                        MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (string.IsNullOrWhiteSpace(Surname.Text))
                            errors.AppendLine("Не указано Отчество");
                }
            if (string.IsNullOrWhiteSpace(NumberPhone.Text) || NumberPhone.Text.Length < 11)
                errors.AppendLine("Не указан Номера телефона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            
            try
            {
                using (PharmacySystemEntities db = new PharmacySystemEntities())
                {
                    account loginCurrent = db.account.FirstOrDefault(x => x.login == loginBox.Text);
                    if (loginCurrent != null)
                    {
                        MessageBox.Show("Логин занят");
                    }
                    else
                    {
                        currentRegestration.id_role = 2;
                        db.account.Add(currentRegestration);
                        db.SaveChanges();

                        StringBuilder informationAccount = new StringBuilder();
                        informationAccount.AppendLine($"Ваш логин: {loginBox.Text}");
                        informationAccount.AppendLine($"Ваш пароль: {password}");
                        informationAccount.AppendLine("Сохраните данные чтобы их не забыть");
                        MessageBox.Show(informationAccount.ToString());

                        Login login = new Login();
                        login.Show();
                        Close();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoginAccount(object sender, RoutedEventArgs e)
        {
            Login logIn = new Login();
            logIn.Show();
            Close();
        }

        private void NumberPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[0-9]+$"))
                e.Handled = true;
        }

        private void SecondName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[а-яА-я]+$"))
                e.Handled = true;
        }

        private void FirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[а-яА-я]+$"))
                e.Handled = true;
        }

        private void Surname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[а-яА-я]+$"))
                e.Handled = true;
        }

        private void loginBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void passwordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void passwordBoxRepeat_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void SecondName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void FirstName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void Surname_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void NumberPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                e.Handled = true;
        }

        private void LoginBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[a-zA-Z0-9]+$"))
                e.Handled = true;
        }

        private void PasswordBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[a-zA-Z0-9]+$"))
                e.Handled = true;
        }

        private void PasswordBoxRepeat_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[a-zA-Z0-9]+$"))
                e.Handled = true;
        }
    }
}