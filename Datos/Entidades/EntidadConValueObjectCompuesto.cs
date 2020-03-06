namespace Datos.Entidades
{
    public class EntidadConValueObjectCompuesto
    {
        protected EntidadConValueObjectCompuesto()
        {
        }

        public EntidadConValueObjectCompuesto(ValueObjectCompuesto compuesto)
        {
            Compuesto = compuesto;
        }

        public virtual int Id { get; protected set; }
        public virtual ValueObjectCompuesto Compuesto { get; protected set; }
    }
}