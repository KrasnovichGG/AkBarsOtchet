using Microsoft.Office.Interop.Excel;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using AkBarsOtchet.DB;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AkBarsOtchet.ALLwin
{
    /// <summary>
    /// Логика взаимодействия для WinMain.xaml
    /// </summary>
    public partial class WinMain : System.Windows.Window
    {
        public WinMain()
        {
            InitializeComponent();
            FellUser();
            StartClock();
        }
        private void StartClock()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += Tickevent;
            dispatcherTimer.Start();
        }
        private void Tickevent(object sender, EventArgs e)
        {
            tbTime.Text = DateTime.Now.ToString();
        }
        private void FellUser()
        {
            tbFio.Text = App.users.FIO;
            tbDivision.Text = App.users.S_Divisions.Name_Division;
            tbPost.Text = App.users.S_Posts.Name_Post;
        }

        private void btnguideSupEmployee_Click(object sender, RoutedEventArgs e)
        {
            WinSup winSup = new WinSup();
            winSup.ShowDialog();
        }

        private void BtnguideEmployee_Click(object sender, RoutedEventArgs e)
        {
            WinAllemployee winAllemployee = new WinAllemployee();
            winAllemployee.ShowDialog();
        }

        private void btnOtchet_Click(object sender, RoutedEventArgs e)
        {
            OtchetZapoln otchetZapoln = new OtchetZapoln();
            otchetZapoln.Show();
        }

        private void btnProsmotrJornal_Click(object sender, RoutedEventArgs e)
        {
            WinJornalOtchet winJornalOtchet = new WinJornalOtchet();
            winJornalOtchet.Show();
        }
    }
}