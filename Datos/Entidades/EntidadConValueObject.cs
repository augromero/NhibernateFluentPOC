namespace Datos.Entidades
{
    public class EntidadConValueObject
    {
        protected EntidadConValueObject()
        {
        }

        public EntidadConValueObject(Dinero dinero, Dinero dinero2)
        {
            Dinero = dinero;
            Dinero2 = dinero2;
        }

        public virtual int Id { get; protected set; }
        public virtual Dinero Dinero { get; protected set; }
        public virtual Dinero Dinero2 { get; protected set; }

    }
}