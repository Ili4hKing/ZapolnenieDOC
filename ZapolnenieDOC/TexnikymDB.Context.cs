﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZapolnenieDOC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TexnikymBDEntities : DbContext
    {
        public TexnikymBDEntities()
            : base("name=TexnikymBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Бд_911> Бд_911 { get; set; }
        public virtual DbSet<И_913> И_913 { get; set; }
        public virtual DbSet<Ип_93> Ип_93 { get; set; }
        public virtual DbSet<М_92> М_92 { get; set; }
        public virtual DbSet<Мц_91> Мц_91 { get; set; }
        public virtual DbSet<Мэ_912> Мэ_912 { get; set; }
        public virtual DbSet<Ол_94> Ол_94 { get; set; }
        public virtual DbSet<Тв_914> Тв_914 { get; set; }
        public virtual DbSet<ШаблонГруппы> ШаблонГруппы { get; set; }
        public virtual DbSet<Студенты2> Студенты2 { get; set; }
    }
}
