using AkBarsOtchet.ALLwin;
using AkBarsOtchet.DB;
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

namespace AkBarsOtchet
{
    /// <summary>
    /// Логика взаимодействия для WinWelcome.xaml
    /// </summary>
    public partial class WinWelcome : Window
    {
        public WinWelcome()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            AuthUser();
        }
        private void AuthUser()
        {
            if (tbLog.Text == "" || pbPass.Password == "")
            {
                MessageBox.Show("Неоставляйте поля логина и пароля не заполненными!", "Ошибочка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else foreach (var user in App.db.Users)
                {
                   
                    if (user.Login_User == tbLog.Text.Trim() && user.isSup == true)
                    {
                        if (user.Password_User == pbPass.Password.Trim() )
                        {
                            MessageBox.Show($"Добро пожаловать:  {user.FIO}", "С возвращением!", MessageBoxButton.OK, MessageBoxImage.Information);
                            App.users = user;
                            WinMain winMain = new WinMain();
                            winMain.Show();
                            Close();
                            //В приложение будет заходить Сотрудник техпоодержки или Обычный сотрудник?
                        }
                    }
                }
            if (App.users == null)
            {
                MessageBox.Show("Такого пользователя не существует,либо этот пользователь не сотрудник техподдержки", "Что-то не так", MessageBoxButton.OK, MessageBoxImage.Error);
                tbLog.Clear();
                pbPass.Clear();
                return;
            }
        }
    }
}
