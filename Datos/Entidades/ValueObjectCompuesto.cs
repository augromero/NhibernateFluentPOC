using System;

namespace Datos.Entidades
{
    public class ValueObjectCompuesto : IEquatable<ValueObjectCompuesto>
    {
        protected ValueObjectCompuesto()
        {
        }

        public ValueObjectCompuesto(Dinero dinero, DateTime fecha)
        {
            Dinero = dinero;
            Fecha = fecha;
        }
        public virtual Dinero Dinero { get; protected set; }
        public virtual DateTime Fecha { get; protected set; }

        public bool Equals(ValueObjectCompuesto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Dinero, other.Dinero) && Fecha.Equals(other.Fecha);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValueObjectCompuesto) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Dinero, Fecha);
        }

        public static bool operator ==(ValueObjectCompuesto left, ValueObjectCompuesto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObjectCompuesto left, ValueObjectCompuesto right)
        {
            return !Equals(left, right);
        }
    }
}