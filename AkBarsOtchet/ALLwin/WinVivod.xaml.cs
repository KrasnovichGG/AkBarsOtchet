using AkBarsOtchet.DB;
using Microsoft.Office.Interop.Excel;
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
    /// Логика взаимодействия для WinVivod.xaml
    /// </summary>
    public partial class WinVivod : System.Windows.Window
    {
        Repair_Order repair_;
        public WinVivod(Repair_Order repair_Order)
        {
            InitializeComponent();
            repair_ = repair_Order;
            tbNameOBJ.Text = repair_Order.Object_of_Fixed_Assets.Name_Obj;
            tbinventNumber.Text = repair_Order.Object_of_Fixed_Assets.Inventory_Number;
            tb_ReplacementCost.Text = Convert.ToString(repair_Order.Object_of_Fixed_Assets.Replacement_Cost);
            tb_ActualServiceLife.Text = repair_Order.Object_of_Fixed_Assets.Actual_Service_Life;
            tb_Modern_or_Repair.Text = repair_Order.Consumables.Repair_or_Modern;
            tbnamecost.Text = repair_Order.Consumables.Name;
            tbserialnumber.Text = repair_Order.Consumables.Serial_Number;
            tb_By_New.Text = repair_Order.Consumables.BY_or_NEW;
            tbCostNew.Text = Convert.ToString(repair_Order.Consumables.Cost);
            tb_Description.Text = repair_Order.Description_of_Works;
            tb_Damage_def.Text = repair_Order.Damage_Defects;
            tbTypeRepair.Text = repair_Order.Type_Repair_Obj;
            tbNote.Text = repair_Order.Note;
            tb_NachRepair.Text = Convert.ToString((repair_Order.Start_Date_Repair ?? DateTime.Now).ToString("dd.MM.yyyy"));
            tb_andRepair.Text = Convert.ToString((repair_Order.End_Date_Repair ?? DateTime.Now).ToString("dd.MM.yyyy"));
            tb_sdal_obj.Text = repair_Order.Users.FIO;
            tb_prinal_obj.Text = App.db.Users.Where(x=>x.Id_User == repair_Order.IdUserPrinayl).FirstOrDefault().FIO;
        }

        private async void btnFormOtchet_Click(object sender, RoutedEventArgs e)
        {
            var mergeData = new MergeData();
            var objFirst = new List<ObjectRepair1>() { new ObjectRepair1() };
            var objSecond = new List<ObjectRepair2>() { new ObjectRepair2() };
            mergeData.UserPrinal = App.db.Users.Where(x => x.FIO == tb_prinal_obj.Text).FirstOrDefault();
            mergeData.UserSdal = App.db.Users.Where(x=>x.FIO == tb_sdal_obj.Text).FirstOrDefault();
            objFirst[0].MainObject = tbNameOBJ.Text.Trim();
            objFirst[0].InventoryNumber = tbinventNumber.Text.Trim();
            objFirst[0].ReplacementCost = tb_ReplacementCost.Text.Trim();
            objFirst[0].ActuallyServiceLive = tb_ActualServiceLife.Text.Trim();
            objFirst[0].DamageDefects = tb_Damage_def.Text.Trim();
            objFirst[0].TypeRepairObj = tbTypeRepair.Text.Trim();
            objSecond[0].MainObject = ($"{tbNameOBJ.Text.Trim()} инф.номер {tbinventNumber.Text.Trim()}");
            objSecond[0].DescriptionOfWorks = tb_Description.Text.Trim();
            objSecond[0].RepairOrModern = tb_Modern_or_Repair.Text.Trim();
            objSecond[0].NameConsmbles = tbnamecost.Text.Trim();
            objSecond[0].SerialNumber = tbserialnumber.Text.Trim();
            objSecond[0].ByOrNew = tb_By_New.Text.Trim();
            objSecond[0].Cost = tbCostNew.Text.Trim();
            objSecond[0].Note = tbNote.Text.Trim();
            mergeData.DateSost = DateTime.Now.ToString("dd.MM.yyyy");
            mergeData.DateZayvka = DateTime.Now.ToString("dd.MM.yyyy");
            mergeData.DateStartRepair = tb_NachRepair.Text; /*Convert.ToDateTime(dpStart.SelectedDate).ToString("dd.MM.yyyy");*/
            mergeData.DateEndRepair = tb_andRepair.Text; /*Convert.ToDateTime(dpEnd.SelectedDate).ToString("dd.MM.yyyy");*/
            mergeData.ObjRepair1 = objFirst;
            mergeData.ObjRepair2 = objSecond;
            await Task.Run(() => SetDataExcel(mergeData));
        }
        public async static Task SetDataExcel(MergeData objects)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            _Workbook oWB;
            _Worksheet oSheet;
            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = false;
                oWB = oXL.Workbooks.Open(@"C:\Users\Lapte\Desktop\Копия ОтчётАкБарсМед.xlsx");
                oSheet = oWB.Worksheets[1];
                oSheet.get_Range("A18", "EV18").Font.Bold = true;
                oSheet.get_Range("A25", "ET25").Font.Bold = true;
                oSheet.get_Range("A19", "FW25").VerticalAlignment =
                XlVAlign.xlVAlignCenter;
                oSheet.Cells[10, 65] = objects.DateSost;
                oSheet.Cells[8, 165] = objects.DateZayvka; // строка, столбец  // формула: 26 * номер первой буквы включительно + кол-во букв до второй буквы включительно
                oSheet.Cells[9, 165] = objects.DateStartRepair;
                oSheet.Cells[10, 165] = objects.DateEndRepair;
                oSheet.Cells[18, 11] = objects.ObjRepair1[0].MainObject; //Объект основных средств K18
                oSheet.Cells[18, 51] = objects.ObjRepair1[0].InventoryNumber; //Инвентарный номер AY18
                oSheet.Cells[18, 69] = objects.ObjRepair1[0].ReplacementCost; //Восстановительная стоимость BQ18
                oSheet.Cells[18, 94] = objects.ObjRepair1[0].ActuallyServiceLive; //Фактический срок Экплуатации CP18
                oSheet.Cells[18, 108] = objects.ObjRepair1[0].DamageDefects; //Дефекты и повреждения DD18
                oSheet.Cells[18, 152] = objects.ObjRepair1[0].TypeRepairObj; //Виды работ по устранению дефекта EV18
                oSheet.Cells[25, 9] = objects.ObjRepair2[0].MainObject; //Объект основных средств 2.1 I25
                oSheet.Cells[25, 45] = objects.ObjRepair2[0].DescriptionOfWorks; //Описание работ AS25
                oSheet.Cells[25, 74] = objects.ObjRepair2[0].RepairOrModern; //Ремонт или Модернизация BV25
                oSheet.Cells[25, 89] = objects.ObjRepair2[0].NameConsmbles; //Наименование расходника CK25
                oSheet.Cells[25, 108] = objects.ObjRepair2[0].SerialNumber; //Серийный номер DD25
                oSheet.Cells[25, 129] = objects.ObjRepair2[0].ByOrNew; //Б\У или Новая DY25
                oSheet.Cells[25, 138] = objects.ObjRepair2[0].Cost; //Стоимость(для новых) EH25
                oSheet.Cells[25, 150] = objects.ObjRepair2[0].Note; //Примечание ET25
                oSheet.Cells[50, 90] = objects.UserSdal.FIO; //Расшифровка подписи сапорта CL50 вылетает какая-то неизвесная ошибка(страшная)
                 oSheet.Cells[50, 29] = objects.UserSdal.S_Posts.Name_Post; //Должность сапорта AC50
                oSheet.Cells[53, 90] = objects.UserPrinal.FIO; //Расшифровка подписи не сапорта CL53
                oSheet.Cells[53, 29] = objects.UserPrinal.S_Posts.Name_Post; //Должность не сапорта несапорта AC53
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
            UserSdal = new Users();
            UserPrinal = new Users();
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
        public ObjectRepair1()
        {
        }

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
        public ObjectRepair2()
        {
        }

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
