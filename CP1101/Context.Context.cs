﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CP1101
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<График_работы> График_работы { get; set; }
        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<Заработная_плата> Заработная_плата { get; set; }
        public virtual DbSet<История_работы> История_работы { get; set; }
        public virtual DbSet<Контакты> Контакты { get; set; }
        public virtual DbSet<Навыки> Навыки { get; set; }
        public virtual DbSet<Образование> Образование { get; set; }
        public virtual DbSet<Отделы> Отделы { get; set; }
        public virtual DbSet<Пользователи> Пользователи { get; set; }
        public virtual DbSet<Сертификаты> Сертификаты { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
    }
}
