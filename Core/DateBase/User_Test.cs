//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.DateBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_Test
    {
        public int ID { get; set; }
        public Nullable<int> ID_User { get; set; }
        public Nullable<int> ID_Test { get; set; }
        public Nullable<bool> IsComplite { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Test Test { get; set; }
        public virtual User User { get; set; }
    }
}
