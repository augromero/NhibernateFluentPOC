using Datos.Entidades;
using FluentNHibernate.Mapping;

namespace Datos.Mappings
{
    public class EntidadRaizMapping : ClassMap<EntidadRaiz>
    {
        public EntidadRaizMapping()
        {
            Id(p => p.Guid)
                .GeneratedBy.Guid();
            Map(p => p.Descripcion);
            HasMany<EntidadSecundaria>(a => a.Detalles)
                .KeyColumn("Encabezado")
                .Not.KeyUpdate()
                .Not.Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}