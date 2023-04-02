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
        }

        private void btnOtchet_Click(object sender, RoutedEventArgs e)
        {
            var order = App.db.Repair_Order.FirstOrDefault(); // здесь будет выбранный пользователем заказ
            var mergeData = new MergeData();
            mergeData.DateSost = DateTime.Now.ToString("dd.MM.yyyy");


            SetDataExcel(mergeData);
        }

        public static void SetDataExcel(MergeData objects)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            _Workbook oWB;
            _Worksheet oSheet;
            //Microsoft.Office.Interop.Excel.Range oRng;

            try
            {
                Console.WriteLine("Start Fill Excel");
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();

                oXL.Visible = false;

                //Get a new workbook.
                oWB = oXL.Workbooks.Open(@"C:\Users\Ильсаф\Desktop\Otchet.xlsx");

                oSheet = oWB.Worksheets[1];
                //oSheet = (_Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.

                //oSheet.Cells[1, 1] = "Название организации";
                //oSheet.Cells[1, 2] = "ИНН";
                //oSheet.Cells[1, 3] = "КПП";
                //oSheet.Cells[1, 4] = "Id_1C";
                //oSheet.Cells[1, 5] = "Примечание";
                //oSheet.Cells[1, 6] = "TillDate";
                //oSheet.Cells[1, 7] = "HospDog";
                //oSheet.Cells[1, 8] = "HospCode";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "H1").Font.Bold = true;
                oSheet.get_Range("A1", "H1").VerticalAlignment =
                XlVAlign.xlVAlignCenter;

                //for (int i = 2; i < objects.Count + 2; i++)
                //{
                //    oSheet.Cells[i, 1].Value = objects[i - 2];
                //}

                oSheet.Cells[10, 65] = objects.DateSost;
                oSheet.Cells[6, 165] = objects.DateZayvka; // строка, столбец  // формула: 26 * номер первой буквы + кол-во букв до второй буквы включительно
                //oSheet.Cells[2, 12] = "больше одного кода";
                //oSheet.Cells[3, 12] = "код не нашелся";


                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                Console.WriteLine(errorMessage, "Error");
            }
        }
    }


    public class MergeData
    {
        public MergeData()
        {

        }

        public MergeData(string numberOrder, string dateSost, string dateZayvka, string dateStartRepair, string dateEndRepair, List<ObjectRepair1> objRepair1, List<ObjectRepair2> objRepair2, Users userSdal, Users userPrinal)
        {
            NumberOrder = numberOrder;
            DateSost = dateSost;
            DateZayvka = dateZayvka;
            DateStartRepair = dateStartRepair;
            DateEndRepair = dateEndRepair;
            ObjRepair1 = objRepair1;
            ObjRepair2 = objRepair2;
            UserSdal = userSdal;
            UserPrinal = userPrinal;
        }

        public string NumberOrder { get; set; }
        public string DateSost { get; set; }
        public string DateZayvka { get; set; }
        public string DateStartRepair { get; set; }
        public string DateEndRepair { get; set; }
        public List<ObjectRepair1> ObjRepair1 { get; set; } 
        public List<ObjectRepair2> ObjRepair2 { get; set; }
        public Users UserSdal { get; set; }
        public Users UserPrinal { get; set; }
    }

    public class ObjectRepair1
    {
        public ObjectRepair1(int number, string mainObject, string inventoryNumber, string replacementCost, string actuallyServiceLive, string damageDefects, string typeRepairObj)
        {
            Number = number;
            MainObject = mainObject;
            InventoryNumber = inventoryNumber;
            ReplacementCost = replacementCost;
            ActuallyServiceLive = actuallyServiceLive;
            DamageDefects = damageDefects;
            TypeRepairObj = typeRepairObj;
        }

        public int Number { get; set; }
        public string MainObject { get; set; }
        public string InventoryNumber { get; set; }
        public string ReplacementCost { get; set; }
        public string ActuallyServiceLive { get; set; }
        public string DamageDefects { get; set; }
        public string TypeRepairObj { get; set; }
    }
    public class ObjectRepair2

    {
        public ObjectRepair2(int number, string mainObject, string descriptionOfWorks, string repairOrModern, string nameConsmbles, string serialNumber, string byOrNew, string cost, string note)
        {
            Number = number;
            MainObject = mainObject;
            DescriptionOfWorks = descriptionOfWorks;
            RepairOrModern = repairOrModern;
            NameConsmbles = nameConsmbles;
            SerialNumber = serialNumber;
            ByOrNew = byOrNew;
            Cost = cost;
            Note = note;
        }

        public int Number { get; set; }
        public string MainObject { get; set; }
        public string DescriptionOfWorks { get; set; }
        public string RepairOrModern { get; set; }
        public string NameConsmbles { get; set; }
        public string SerialNumber { get; set; }
        public string ByOrNew { get; set; }
        public string Cost { get; set; }
        public string Note { get; set; }
    }
}