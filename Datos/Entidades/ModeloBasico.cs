namespace Datos.Entidades
{
    public class ModeloBasico
    {
        protected ModeloBasico()
        {
        }

        public ModeloBasico(string descripcion, decimal valorMoney, decimal valorDecimal)
        {
            Descripcion = descripcion;
            ValorMoney = valorMoney;
            ValorDecimal = valorDecimal;
        }

        public virtual int Id { get; protected set; }
        public virtual string Descripcion { get; protected set; }
        public virtual decimal ValorMoney { get; protected set; }
        public virtual decimal ValorDecimal { get; protected set; }
    }
}
