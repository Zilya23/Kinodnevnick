﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KinokradEntities : DbContext
    {
        public KinokradEntities()
            : base("name=KinokradEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Award> Award { get; set; }
        public virtual DbSet<Award_User> Award_User { get; set; }
        public virtual DbSet<Collection> Collection { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Film_Calendar> Film_Calendar { get; set; }
        public virtual DbSet<Film_Collection> Film_Collection { get; set; }
        public virtual DbSet<Follow> Follow { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User_Test> User_Test { get; set; }
    }
}
