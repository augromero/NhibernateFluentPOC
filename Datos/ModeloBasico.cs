using System;
using System.Collections.Generic;
using NHibernate.Mapping;

namespace Datos
{
    public class ModeloBasico
    {
        protected ModeloBasico()
        {
        }

        public ModeloBasico(string descripcion)
        {
            Descripcion = descripcion;
        }

        public virtual int Id { get; protected set; }
        public virtual string Descripcion { get; protected set; }
    }

    public class EntidadRaiz
    {
        protected EntidadRaiz()
        {
        }

        public EntidadRaiz( string descripcion)
        {
            Guid = Guid.NewGuid();
            Descripcion = descripcion;
            Detalles = new List<EntidadSecundaria>();
        }

        public virtual Guid Guid { get; protected set; }
        public virtual string Descripcion { get; protected set; }
        public virtual IList<EntidadSecundaria> Detalles { get; protected set; }

        public virtual void AgregarSecundaria(EntidadSecundaria secundaria)
        {
            Detalles.Add(secundaria);
        }
    }

    public class EntidadSecundaria
    {
        protected EntidadSecundaria()
        {
            
        }

        public EntidadSecundaria(int cantidad)
        {
            Cantidad = cantidad;
        }
        public virtual Guid Id { get; protected set; }
        public virtual Guid Encabezado { get; protected set; }
        public virtual int Cantidad { get; protected set; }
    }
}
