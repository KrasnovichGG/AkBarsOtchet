using AkBarsOtchet.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AkBarsOtchet
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AkBarsMedPracticsEntities db = new AkBarsMedPracticsEntities();
    }
}
