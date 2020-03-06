using Datos.Entidades;
using FluentNHibernate.Mapping;

namespace Datos.Mappings
{
    public class EntidadConValueObjectMapping : ClassMap<EntidadConValueObject>
    {
        public EntidadConValueObjectMapping()
        {
            Id(p => p.Id);
            Component(p => p.Dinero, m =>
            {
                m.Map(p => p.Valor).CustomSqlType("MONEY");
                m.Map(p => p.Moneda).CustomSqlType("TINYINT");
            });
            Component(p => p.Dinero2, m =>
            {
                m.Map(p => p.Valor, "valor2").CustomSqlType("MONEY");
                m.Map(p => p.Moneda, "moneda2").CustomSqlType("TINYINT");
            });
        }
    }
}