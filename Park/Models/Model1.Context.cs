﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Park.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbParkEntities : DbContext
    {
        public DbParkEntities()
            : base("name=DbParkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Espacio> Espacio { get; set; }
        public virtual DbSet<Estacionamiento> Estacionamiento { get; set; }
        public virtual DbSet<Segmento> Segmento { get; set; }
        public virtual DbSet<Park> Park { get; set; }
    }
}
