﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMSDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SMSdb : DbContext
    {
        public SMSdb()
            : base("name=SMSdb")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tm_cre_credential> tm_cre_credential { get; set; }
        public virtual DbSet<tm_mes_message> tm_mes_message { get; set; }
        public virtual DbSet<tm_sen_sent> tm_sen_sent { get; set; }
        public virtual DbSet<tm_usr_user> tm_usr_user { get; set; }
    }
}
