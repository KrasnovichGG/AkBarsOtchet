//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AkBarsOtchet.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Repair_Order
    {
        public int Id_Order { get; set; }
        public int Id_Object { get; set; }
        public string Description_of_Works { get; set; }
        public int Id_Con { get; set; }
        public string Damage_Defects { get; set; }
        public string Type_Repair_Obj { get; set; }
        public int Id_User { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> Start_Date_Repair { get; set; }
        public Nullable<System.DateTime> End_Date_Repair { get; set; }
    
        public virtual Consumables Consumables { get; set; }
        public virtual Object_of_Fixed_Assets Object_of_Fixed_Assets { get; set; }
        public virtual Users Users { get; set; }
    }
}
