﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kafe
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KafeEntities : DbContext
    {
        public KafeEntities()
            : base("name=KafeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<StatusCook> StatusCook { get; set; }
        public virtual DbSet<StatusOrder> StatusOrder { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<DishOrder> DishOrder { get; set; }
    }
}