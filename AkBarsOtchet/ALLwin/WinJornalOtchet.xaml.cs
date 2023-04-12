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
using System.Windows.Shapes;

namespace AkBarsOtchet.ALLwin
{
    /// <summary>
    /// Логика взаимодействия для WinJornalOtchet.xaml
    /// </summary>
    public partial class WinJornalOtchet : Window
    {
        public WinJornalOtchet()
        {
            InitializeComponent();
            lstOtchet.ItemsSource = App.db.Repair_Order.ToList();
        }

        private void lstOtchet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Repair_Order)lstOtchet.SelectedItem;
            new WinVivod(item).Show();
        }

        private void tbpoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            var res = App.db.Repair_Order.ToList();
            res = res.Where(x => x.Users.FIO.ToLower().Contains(tbpoisk.Text.ToLower())).ToList();
            lstOtchet.ItemsSource = res.ToList();
        }
    }
}
