﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Monopoly_DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Data_r0718763Entities1 : DbContext
    {
        public Data_r0718763Entities1()
            : base("name=Data_r0718763Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AlgemeenFonds> AlgemeenFonds { get; set; }
        public virtual DbSet<Kans> Kans { get; set; }
        public virtual DbSet<Speler> Speler { get; set; }
        public virtual DbSet<Spelvak> Spelvak { get; set; }
    }
}
