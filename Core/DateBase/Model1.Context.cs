﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Kinodnev1Entities : DbContext
    {
        public Kinodnev1Entities()
            : base("name=Kinodnev1Entities")
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
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User_Test> User_Test { get; set; }
    }
}
