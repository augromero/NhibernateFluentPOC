using Datos.Entidades;
using FluentNHibernate.Mapping;

namespace Datos.Mappings
{
    public class ModeloBasicoMapping : ClassMap<ModeloBasico>
    {
        public ModeloBasicoMapping()
        {
            Id(p => p.Id);
            Map(p => p.Descripcion);
            Map(p => p.ValorMoney).CustomSqlType("MONEY");
            Map(p => p.ValorDecimal).CustomSqlType("DECIMAL(15, 10)");
        }
    }
}