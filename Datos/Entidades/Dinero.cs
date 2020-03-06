using System;

namespace Datos.Entidades
{
    public class Dinero : IEquatable<Dinero>
    {
        protected Dinero()
        {
            
        }
        public Dinero(decimal valor, Moneda moneda)
        {
            Valor = valor;
            Moneda = moneda;
        }   

        public  decimal Valor { get; protected set; }
        public virtual Moneda Moneda { get; protected set; }

        public bool Equals(Dinero other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Valor == other.Valor && Moneda == other.Moneda;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Dinero) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Valor, (int) Moneda);
        }

        public static bool operator ==(Dinero left, Dinero right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Dinero left, Dinero right)
        {
            return !Equals(left, right);
        }
    }
}