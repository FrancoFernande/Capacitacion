﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class escuelaContenx : DbContext
    {
        public escuelaContenx()
            : base("name=escuelaContenx")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<alu_pro> alu_pro { get; set; }
        public virtual DbSet<alumno> alumno { get; set; }
        public virtual DbSet<carrera> carrera { get; set; }
        public virtual DbSet<mat_alu> mat_alu { get; set; }
        public virtual DbSet<mat_pro> mat_pro { get; set; }
        public virtual DbSet<materia> materia { get; set; }
        public virtual DbSet<profesor> profesor { get; set; }
    }
}
