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
using WPF_PR6_Morozov.AppPages;

namespace WPF_PR6_Morozov.AppPages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelOdb.User.FirstOrDefault(x => x.login == txbLogin.Text && x.password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Пользователя не существует", "Ошибка авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здраствуйте, Администратор " + userObj.name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new PageData());
                            break;
                        case 2:
                            MessageBox.Show("Здраствуйте, " + userObj.name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new PageData());
                            break;

                    }
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая ошибка приложения",
                " Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}

