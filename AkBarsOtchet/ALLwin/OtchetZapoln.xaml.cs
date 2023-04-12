using System;
using Microsoft.Office.Interop.Excel;
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
using AkBarsOtchet.DB;

namespace AkBarsOtchet.ALLwin
{
    /// <summary>
    /// Логика взаимодействия для OtchetZapoln.xaml
    /// </summary>
    public partial class OtchetZapoln : System.Windows.Window
    {
        public OtchetZapoln()
        {
            InitializeComponent();
            CmbBoxUserSdal.ItemsSource = App.db.Users.Where(x => x.isSup == true).ToList();
            UserPrinual.ItemsSource = App.db.Users.Where(x => x.isSup == false).ToList();
            feelcmb();
            dpStart.SelectedDate = DateTime.Now;
            dpEnd.SelectedDate = DateTime.Now;
        }

        private void feelcmb()
        {
            cmbboxbynew.Items.Add("Новая");
            cmbboxbynew.Items.Add("Б/У");
            cmboxModern.Items.Add("Ремонт");
            cmboxModern.Items.Add("Модернизация");

        }
        
        //private void btnSaveOtchet_Click(object sender, RoutedEventArgs e)
        //{
        //    if (tbNameOBJ.Text == "" || tbinventNumber.Text == "" || tb_Damage_def.Text == "" || cmbboxbynew.SelectedIndex == -1)
        //    {
        //        MessageBox.Show("Поля, такие как : Объект основных средств, Инвентарный номер, Дефекты и повреждения, б/у или новая. Должны быть заполнены в обязательном порядке!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return;
        //    }
        //    else
        //    {
        //        var mergeData = new MergeData();
        //        var objFirst = new List<ObjectRepair1>() { new ObjectRepair1() };
        //        var objSecond = new List<ObjectRepair2>() { new ObjectRepair2() };
        //        mergeData.UserPrinal = (Users)UserPrinual.SelectedItem;
        //        mergeData.UserSdal = (Users)CmbBoxUserSdal.SelectedItem;
        //        objFirst[0].MainObject = tbNameOBJ.Text.Trim();
        //        objFirst[0].InventoryNumber = tbinventNumber.Text.Trim();
        //        objFirst[0].ReplacementCost = tb_ReplacementCost.Text.Trim();
        //        objFirst[0].ActuallyServiceLive = tb_ActualServiceLife.Text.Trim();
        //        objFirst[0].DamageDefects = tb_Damage_def.Text.Trim();
        //        objFirst[0].TypeRepairObj = tbTypeRepair.Text.Trim();
        //        objSecond[0].MainObject = ($"{tbNameOBJ.Text.Trim()} инф.номер {tbinventNumber.Text.Trim()}");
        //        objSecond[0].DescriptionOfWorks = tb_Description.Text.Trim();
        //        objSecond[0].RepairOrModern = cmboxModern.Text.Trim();
        //        objSecond[0].NameConsmbles = tbnamecost.Text.Trim();
        //        objSecond[0].SerialNumber = tbserialnumber.Text.Trim();
        //        objSecond[0].ByOrNew = cmbboxbynew.Text.Trim();
        //        objSecond[0].Cost = tbCostNew.Text.Trim();
        //        objSecond[0].Note = tbNote.Text.Trim();
        //        mergeData.DateSost = DateTime.Now.ToString("dd.MM.yyyy");
        //        mergeData.DateZayvka = DateTime.Now.ToString("dd.MM.yyyy");
        //        mergeData.DateStartRepair = Convert.ToDateTime(dpStart.SelectedDate).ToString("dd.MM.yyyy");
        //        mergeData.DateEndRepair = Convert.ToDateTime(dpEnd.SelectedDate).ToString("dd.MM.yyyy");
        //        mergeData.ObjRepair1 = objFirst;
        //        mergeData.ObjRepair2 = objSecond;
        //        SetDataExcel(mergeData);
        //    }
        //}
        //public static void SetDataExcel(MergeData objects)
        //{
        //    Microsoft.Office.Interop.Excel.Application oXL;
        //    _Workbook oWB;
        //    _Worksheet oSheet;
        //    try
        //    {
        //        oXL = new Microsoft.Office.Interop.Excel.Application();
        //        oXL.Visible = false;
        //        oWB = oXL.Workbooks.Open(@"C:\Users\Lapte\Desktop\ОтчётАкБарсМед.xlsx");
        //        oSheet = oWB.Worksheets[1];
        //        oSheet.get_Range("A19", "FW15").Font.Bold = true;
        //        oSheet.get_Range("A19", "FW25").VerticalAlignment =
        //        XlVAlign.xlVAlignCenter;
        //        oSheet.Cells[10, 65] = objects.DateSost;
        //        oSheet.Cells[8, 165] = objects.DateZayvka; // строка, столбец  // формула: 26 * номер первой буквы включительно + кол-во букв до второй буквы включительно
        //        oSheet.Cells[9, 165] = objects.DateStartRepair;
        //        oSheet.Cells[10, 165] = objects.DateEndRepair;
        //        oSheet.Cells[18, 11] = objects.ObjRepair1[0].MainObject; //Объект основных средств K18
        //        oSheet.Cells[18, 51] = objects.ObjRepair1[0].InventoryNumber; //Инвентарный номер AY18
        //        oSheet.Cells[18, 69] = objects.ObjRepair1[0].ReplacementCost; //Восстановительная стоимость BQ18
        //        oSheet.Cells[18, 94] = objects.ObjRepair1[0].ActuallyServiceLive; //Фактический срок Экплуатации CP18
        //        oSheet.Cells[18, 108] = objects.ObjRepair1[0].DamageDefects; //Дефекты и повреждения DD18
        //        oSheet.Cells[18, 152] = objects.ObjRepair1[0].TypeRepairObj; //Виды работ по устранению дефекта EV18
        //        oSheet.Cells[25, 9] = objects.ObjRepair2[0].MainObject; //Объект основных средств 2.1 I25
        //        oSheet.Cells[25, 45] = objects.ObjRepair2[0].DescriptionOfWorks; //Описание работ AS25
        //        oSheet.Cells[25, 74] = objects.ObjRepair2[0].RepairOrModern; //Ремонт или Модернизация BV25
        //        oSheet.Cells[25, 89] = objects.ObjRepair2[0].NameConsmbles; //Наименование расходника CK25
        //        oSheet.Cells[25, 108] = objects.ObjRepair2[0].SerialNumber; //Серийный номер DD25
        //        oSheet.Cells[25, 129] = objects.ObjRepair2[0].ByOrNew; //Б\У или Новая DY25
        //        oSheet.Cells[25, 138] = objects.ObjRepair2[0].Cost; //Стоимость(для новых) EH25
        //        oSheet.Cells[25, 150] = objects.ObjRepair2[0].Note; //Примечание ET25
        //        oSheet.Cells[50, 90] = objects.UserSdal.FIO; //Расшифровка подписи сапорта CL50 вылетает какая-то неизвесная ошибка(страшная)
        //        oSheet.Cells[50, 29] = objects.UserSdal.S_Posts.Name_Post; //Должность сапорта AC50
        //        oSheet.Cells[53, 90] = objects.UserPrinal.FIO; //Расшифровка подписи не сапорта CL53
        //        oSheet.Cells[53, 29] = objects.UserPrinal.S_Posts.Name_Post; //Должность не сапорта несапорта AC53
        //        oXL.Visible = true;
        //        oXL.UserControl = true;
        //    }
        //    catch (Exception theException)
        //    {
        //        String errorMessage;
        //        errorMessage = "Error: ";
        //        errorMessage = String.Concat(errorMessage, theException.Message);
        //        errorMessage = String.Concat(errorMessage, " Line: ");
        //        errorMessage = String.Concat(errorMessage, theException.Source);

        //        Console.WriteLine(errorMessage, "Error");
        //    }
        //}

        private void tb_ReplacementCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!Char.IsDigit(e.Text, 0))
            {
                MessageBox.Show("Вводить только цифры!", "Только только цифры", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }

        }

        private void tb_ActualServiceLife_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                MessageBox.Show("Вводить только цифры!", "Только только цифры", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }
        }

        private void tbCostNew_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!Char.IsDigit(e.Text, 0))
            {
                MessageBox.Show("Вводить только цифры!", "Только только цифры", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }

        }

        private void bntADDtoDB_Click(object sender, RoutedEventArgs e)
        {
            if (tbNameOBJ.Text == "" || tbinventNumber.Text == "" || tb_Damage_def.Text == "" || cmbboxbynew.SelectedIndex == -1)
            {
                MessageBox.Show("Поля, такие как : Объект основных средств, Инвентарный номер, Дефекты и повреждения, б/у или новая. Должны быть заполнены в обязательном порядке!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var Cons = new Consumables();
                {
                    Cons.Id_Con = Cons.Id_Con;
                    Cons.Repair_or_Modern = cmboxModern.Text.Trim();
                    Cons.Name = tbnamecost.Text.Trim();
                    Cons.Serial_Number = tbserialnumber.Text.Trim();
                    Cons.BY_or_NEW = cmbboxbynew.Text.Trim();
                    Cons.Cost = Convert.ToDecimal(tbCostNew.Text.Trim());
                }
                App.db.Consumables.Add(Cons);
                var Obj = new Object_of_Fixed_Assets();
                {
                    Obj.Id_Object = Obj.Id_Object;
                    Obj.Name_Obj = tbNameOBJ.Text.Trim();
                    Obj.Inventory_Number = tbinventNumber.Text.Trim();
                    Obj.Replacement_Cost = Convert.ToDecimal(tb_ReplacementCost.Text.Trim());
                    if (tb_ActualServiceLife.Text == "1")
                    {
                        Obj.Actual_Service_Life = $"{tb_ActualServiceLife.Text}" + " год";
                    }
                    else if (tb_ActualServiceLife.Text == "2")
                    {
                        Obj.Actual_Service_Life = $"{tb_ActualServiceLife.Text}" + " года";
                    }
                    else if (tb_ActualServiceLife.Text == "3")
                    {
                        Obj.Actual_Service_Life = $"{tb_ActualServiceLife.Text}" + " года";
                    }
                    else if (tb_ActualServiceLife.Text == "4")
                    {
                        Obj.Actual_Service_Life = $"{tb_ActualServiceLife.Text}" + " года";
                    }
                    else
                    {
                        Obj.Actual_Service_Life = $"{tb_ActualServiceLife.Text}" + " лет";
                    }
                }
                App.db.Object_of_Fixed_Assets.Add(Obj);
                var OrderRepair = new Repair_Order();
                {
                    OrderRepair.Id_Order = OrderRepair.Id_Order;
                    OrderRepair.Id_Object = Obj.Id_Object;
                    OrderRepair.Description_of_Works = tb_Description.Text.Trim();
                    OrderRepair.Id_Con = Cons.Id_Con;
                    OrderRepair.Damage_Defects = tb_Damage_def.Text.Trim();
                    OrderRepair.Type_Repair_Obj = tbTypeRepair.Text.Trim();
                    OrderRepair.Id_User = (CmbBoxUserSdal.SelectedItem as Users).Id_User;
                    OrderRepair.Note = tbNote.Text.Trim();
                    OrderRepair.Start_Date_Repair = dpStart.SelectedDate;
                    OrderRepair.End_Date_Repair = dpEnd.SelectedDate;
                    OrderRepair.IdUserPrinayl = (UserPrinual.SelectedItem as Users).Id_User;
                }
                App.db.Repair_Order.Add(OrderRepair);
                App.db.SaveChanges();
                MessageBox.Show("Успешно!","Успешное сохранение в базу данных!",MessageBoxButton.OK,MessageBoxImage.Information);


            }
        }
        private void tbinventNumber_MouseEnter(object sender, MouseEventArgs e)
        {
            tbinventNumber.Text = "";
            
        }

        private void tb_Damage_def_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_Damage_def.Text = "";
        }

        private void tbNameOBJ_MouseEnter(object sender, MouseEventArgs e)
        {
            tbNameOBJ.Text = "";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            var a = MessageBox.Show("Вы точно хотите очистить форму?", "Вопрос!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(a == MessageBoxResult.Yes)
            {
                tbNameOBJ.Clear();
                tbinventNumber.Clear();
                tb_ReplacementCost.Clear();
                tb_ActualServiceLife.Clear();
                tb_Damage_def.Clear();
                tbTypeRepair.Clear();
                tb_Description.Clear();
                cmboxModern.SelectedIndex = -1;
                tbnamecost.Clear();
                tbserialnumber.Clear();
                cmbboxbynew.SelectedIndex = -1;
                tbCostNew.Clear();
                tbNote.Clear();
                CmbBoxUserSdal.SelectedIndex = -1;
                UserPrinual.SelectedIndex = -1;
                dpStart.SelectedDate = DateTime.Now;
                dpEnd.SelectedDate = DateTime.Now;
                MessageBox.Show("Форма очищена", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Форма не очищена", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        
    }

    //public class MergeData
    //{
    //    public MergeData()
    //    {

    //    }

    //    public MergeData(string numberOrder, string dateSost, string dateZayvka, string dateStartRepair, string dateEndRepair, List<ObjectRepair1> objRepair1, List<ObjectRepair2> objRepair2, Users userSdal, Users userPrinal)
    //    {
    //        NumberOrder = numberOrder;
    //        DateSost = dateSost;
    //        DateZayvka = dateZayvka;
    //        DateStartRepair = dateStartRepair;
    //        DateEndRepair = dateEndRepair;
    //        ObjRepair1 = objRepair1;
    //        ObjRepair2 = objRepair2;
    //        UserSdal = userSdal;
    //        UserPrinal = userPrinal;
    //    }

    //    public string NumberOrder { get; set; }
    //    public string DateSost { get; set; }
    //    public string DateZayvka { get; set; }
    //    public string DateStartRepair { get; set; }
    //    public string DateEndRepair { get; set; }
    //    public List<ObjectRepair1> ObjRepair1 { get; set; }
    //    public List<ObjectRepair2> ObjRepair2 { get; set; }
    //    public Users UserSdal { get; set; }
    //    public Users UserPrinal { get; set; }
    //}

    //public class ObjectRepair1
    //{
    //    public ObjectRepair1()
    //    {
    //    }

    //    public ObjectRepair1(int number, string mainObject, string inventoryNumber, string replacementCost, string actuallyServiceLive, string damageDefects, string typeRepairObj)
    //    {
    //        Number = number;
    //        MainObject = mainObject;
    //        InventoryNumber = inventoryNumber;
    //        ReplacementCost = replacementCost;
    //        ActuallyServiceLive = actuallyServiceLive;
    //        DamageDefects = damageDefects;
    //        TypeRepairObj = typeRepairObj;
    //    }

    //    public int Number { get; set; }
    //    public string MainObject { get; set; }
    //    public string InventoryNumber { get; set; }
    //    public string ReplacementCost { get; set; }
    //    public string ActuallyServiceLive { get; set; }
    //    public string DamageDefects { get; set; }
    //    public string TypeRepairObj { get; set; }
    //}
    //public class ObjectRepair2

    //{
    //    public ObjectRepair2()
    //    {
    //    }

    //    public ObjectRepair2(int number, string mainObject, string descriptionOfWorks, string repairOrModern, string nameConsmbles, string serialNumber, string byOrNew, string cost, string note)
    //    {
    //        Number = number;
    //        MainObject = mainObject;
    //        DescriptionOfWorks = descriptionOfWorks;
    //        RepairOrModern = repairOrModern;
    //        NameConsmbles = nameConsmbles;
    //        SerialNumber = serialNumber;
    //        ByOrNew = byOrNew;
    //        Cost = cost;
    //        Note = note;
    //    }

    //    public int Number { get; set; }
    //    public string MainObject { get; set; }
    //    public string DescriptionOfWorks { get; set; }
    //    public string RepairOrModern { get; set; }
    //    public string NameConsmbles { get; set; }
    //    public string SerialNumber { get; set; }
    //    public string ByOrNew { get; set; }
    //    public string Cost { get; set; }
    //    public string Note { get; set; }
    //}
}
