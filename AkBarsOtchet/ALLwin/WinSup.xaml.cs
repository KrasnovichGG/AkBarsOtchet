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
using System.Windows.Shapes;

namespace AkBarsOtchet.ALLwin
{
    /// <summary>
    /// Логика взаимодействия для WinSup.xaml
    /// </summary>
    public partial class WinSup : Window
    {
        public WinSup()
        {
            InitializeComponent();
            LstSup.ItemsSource = App.db.Users.Where(x => x.isSup == true).ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
