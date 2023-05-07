using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace AutomaticPharmacyInformationSystem
{
    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
            loginBox.MaxLength = 25;
            passwordBox.MaxLength = 25;
            passwordBoxDubler.IsReadOnly = true;
        }
        
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void NewAccount(object sender, RoutedEventArgs e)
        {
            Signup signUp = new Signup();
            signUp.Show();
            Close();
        }

        private void LoginAccount(object sender, RoutedEventArgs e)
        {
            var accountCurrent = PharmacySystemEntities.GetContext().account.FirstOrDefault(p => p.login == loginBox.Text);
            var roleCurrent = PharmacySystemEntities.GetContext().account.FirstOrDefault(p => p.login == loginBox.Text && p.id_role == 1);

                if (accountCurrent != null && BCrypt.Net.BCrypt.Verify(passwordBox.Password, accountCurrent.password))
                {
                    if (roleCurrent != null && BCrypt.Net.BCrypt.Verify(passwordBox.Password, accountCurrent.password))
                    {
                        MainWindowAdmin mainWindow = new MainWindowAdmin();
                        mainWindow.Show();
                        Close();
                    }
                    else
                    {
                        MainWindow mainWindow = new MainWindow(loginBox.Text);
                        mainWindow.Show();
                        Close();
                    }
                }
                else
                    MessageBox.Show("Дынные введены некорректно");
        }

        private void viewBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            passwordBoxDubler.Text = passwordBox.Password;
            passwordBox.Visibility = Visibility.Hidden;
            passwordBoxDubler.Visibility = Visibility.Visible;
        }

        private void viewBtn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            passwordBoxDubler.Visibility = Visibility.Hidden;
            passwordBox.Password = passwordBoxDubler.Text;
            passwordBox.Visibility = Visibility.Visible;
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
    }
}