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
    
    public partial class Follow
    {
        public int ID { get; set; }
        public Nullable<int> ID_Follower_User { get; set; }
        public Nullable<int> ID_Following_User { get; set; }
        public Nullable<System.DateTime> Date_follow { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
