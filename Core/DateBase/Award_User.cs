//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.DateBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Award_User
    {
        public int ID { get; set; }
        public Nullable<int> ID_Award { get; set; }
        public Nullable<int> ID_User { get; set; }
        public Nullable<bool> IsDone { get; set; }
    
        public virtual Award Award { get; set; }
        public virtual User User { get; set; }
    }
}
