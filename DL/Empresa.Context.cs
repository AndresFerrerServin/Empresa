﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmpresaEntities : DbContext
    {
        public EmpresaEntities()
            : base("name=EmpresaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_CAT_PUESTO> T_CAT_PUESTO { get; set; }
        public virtual DbSet<T_EMPLEADOS> T_EMPLEADOS { get; set; }
    
        public virtual ObjectResult<T_CAT_PUESTOGetall_Result> T_CAT_PUESTOGetall()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<T_CAT_PUESTOGetall_Result>("T_CAT_PUESTOGetall");
        }
    
        public virtual int T_EMPLEADOSAdd(string nombre, string apellido_Paterno, string apellido_Materno, Nullable<int> idPuesto)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellido_PaternoParameter = apellido_Paterno != null ?
                new ObjectParameter("Apellido_Paterno", apellido_Paterno) :
                new ObjectParameter("Apellido_Paterno", typeof(string));
    
            var apellido_MaternoParameter = apellido_Materno != null ?
                new ObjectParameter("Apellido_Materno", apellido_Materno) :
                new ObjectParameter("Apellido_Materno", typeof(string));
    
            var idPuestoParameter = idPuesto.HasValue ?
                new ObjectParameter("IdPuesto", idPuesto) :
                new ObjectParameter("IdPuesto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("T_EMPLEADOSAdd", nombreParameter, apellido_PaternoParameter, apellido_MaternoParameter, idPuestoParameter);
        }
    
        public virtual int T_EMPLEADOSDelete(Nullable<int> id_NumEmp)
        {
            var id_NumEmpParameter = id_NumEmp.HasValue ?
                new ObjectParameter("Id_NumEmp", id_NumEmp) :
                new ObjectParameter("Id_NumEmp", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("T_EMPLEADOSDelete", id_NumEmpParameter);
        }
    
        public virtual ObjectResult<T_EMPLEADOSGetAll_Result> T_EMPLEADOSGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<T_EMPLEADOSGetAll_Result>("T_EMPLEADOSGetAll");
        }
    
        public virtual ObjectResult<T_EMPLEADOSGetById_Result> T_EMPLEADOSGetById(Nullable<int> id_NumEmp)
        {
            var id_NumEmpParameter = id_NumEmp.HasValue ?
                new ObjectParameter("Id_NumEmp", id_NumEmp) :
                new ObjectParameter("Id_NumEmp", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<T_EMPLEADOSGetById_Result>("T_EMPLEADOSGetById", id_NumEmpParameter);
        }
    
        public virtual int T_EMPLEADOSUpdate(Nullable<int> id_NumEmp, string nombre, string apellido_Paterno, string apellido_Materno, Nullable<int> idPuesto)
        {
            var id_NumEmpParameter = id_NumEmp.HasValue ?
                new ObjectParameter("Id_NumEmp", id_NumEmp) :
                new ObjectParameter("Id_NumEmp", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellido_PaternoParameter = apellido_Paterno != null ?
                new ObjectParameter("Apellido_Paterno", apellido_Paterno) :
                new ObjectParameter("Apellido_Paterno", typeof(string));
    
            var apellido_MaternoParameter = apellido_Materno != null ?
                new ObjectParameter("Apellido_Materno", apellido_Materno) :
                new ObjectParameter("Apellido_Materno", typeof(string));
    
            var idPuestoParameter = idPuesto.HasValue ?
                new ObjectParameter("IdPuesto", idPuesto) :
                new ObjectParameter("IdPuesto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("T_EMPLEADOSUpdate", id_NumEmpParameter, nombreParameter, apellido_PaternoParameter, apellido_MaternoParameter, idPuestoParameter);
        }
    }
}
