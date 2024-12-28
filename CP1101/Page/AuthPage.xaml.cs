using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CP1101.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page {

        public AuthPage() {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            Navigation.Root.Close();
        }

        private void Auth_Click(object sender, RoutedEventArgs e) {
            Пользователи user = Database.Instance.Пользователи.FirstOrDefault(u => u.Логин == Login.Text && u.Пароль == Password.Password);

            if (user != null)
            {
                MessageBox.Show($"Добро пожаловать, {user.Сотрудники.Фамилия} {user.Сотрудники.Имя} {user.Сотрудники.Отчество}!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigation.CurrentFrame.Navigate(new MainPage());
            }
            else if (Login.Text == "Test" && Password.Password == "Test")
            {
                MessageBox.Show($"Вход с тестового пользователя.", "Тест", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigation.CurrentFrame.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Неверные данные для входа!", "Провал", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}
