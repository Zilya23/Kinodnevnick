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
    
    public partial class Film_Collection
    {
        public int ID { get; set; }
        public Nullable<int> ID_Film { get; set; }
        public Nullable<int> ID_Collection { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Collection Collection { get; set; }
        public virtual Film Film { get; set; }
    }
}
