using Datos.Entidades;
using FluentNHibernate.Mapping;

namespace Datos.Mappings
{
    public class EntidadSecundariaMapping : ClassMap<EntidadSecundaria>
    {
        public EntidadSecundariaMapping()
        {
            Id(p => p.Id)
                .GeneratedBy.Guid();;
            Map(p => p.Cantidad);
        }
    }
}