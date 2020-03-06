using System;
using System.Collections.Generic;

namespace Datos.Entidades
{
    public class EntidadRaiz
    {
        protected EntidadRaiz()
        {
        }

        public EntidadRaiz(string descripcion)
        {
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

        public virtual void LimpiarSecundaria()
        {
            Detalles.Clear();
        }
    }
}