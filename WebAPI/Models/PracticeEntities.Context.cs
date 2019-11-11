﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PracticeEntities : DbContext
    {
        public PracticeEntities()
            : base("name=PracticeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    
        public virtual ObjectResult<findInfor_Result> findInfor(string infor_Name, string infor_Gender, string infor_Phone, string infor_Email, string infor_Address)
        {
            var infor_NameParameter = infor_Name != null ?
                new ObjectParameter("infor_Name", infor_Name) :
                new ObjectParameter("infor_Name", typeof(string));
    
            var infor_GenderParameter = infor_Gender != null ?
                new ObjectParameter("infor_Gender", infor_Gender) :
                new ObjectParameter("infor_Gender", typeof(string));
    
            var infor_PhoneParameter = infor_Phone != null ?
                new ObjectParameter("infor_Phone", infor_Phone) :
                new ObjectParameter("infor_Phone", typeof(string));
    
            var infor_EmailParameter = infor_Email != null ?
                new ObjectParameter("infor_Email", infor_Email) :
                new ObjectParameter("infor_Email", typeof(string));
    
            var infor_AddressParameter = infor_Address != null ?
                new ObjectParameter("infor_Address", infor_Address) :
                new ObjectParameter("infor_Address", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<findInfor_Result>("findInfor", infor_NameParameter, infor_GenderParameter, infor_PhoneParameter, infor_EmailParameter, infor_AddressParameter);
        }
    
        public virtual ObjectResult<Verify_Result> Verify(string userName, string passWord)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passWordParameter = passWord != null ?
                new ObjectParameter("passWord", passWord) :
                new ObjectParameter("passWord", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Verify_Result>("Verify", userNameParameter, passWordParameter);
        }
    }
}
