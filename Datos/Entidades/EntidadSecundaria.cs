using System;

namespace Datos.Entidades
{
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
        public virtual int Cantidad { get; protected set; }
    }
}