﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASM.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLDaiHocEntities1 : DbContext
    {
        public QLDaiHocEntities1()
            : base("name=QLDaiHocEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category_Course> Category_Course { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Profile_User> Profile_User { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<User_Account> User_Account { get; set; }
    }
}
