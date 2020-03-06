using Datos.Entidades;
using FluentNHibernate.Mapping;

namespace Datos.Mappings
{
    public class EntidadConValueObjectCompuestoMapping : ClassMap<EntidadConValueObjectCompuesto>
    {
        public EntidadConValueObjectCompuestoMapping()
        {
            Id(p => p.Id);
            Component(p => p.Compuesto, m =>
            {
                m.Component(p => p.Dinero, m =>
                {
                    m.Map(p => p.Valor);
                    m.Map(p => p.Moneda);
                });
                m.Map(p => p.Fecha).CustomSqlType("DATE");
            });
        }
    }
}