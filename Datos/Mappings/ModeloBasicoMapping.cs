using FluentNHibernate.Mapping;

namespace Datos.Mappings
{
    public class ModeloBasicoMapping : ClassMap<ModeloBasico>
    {
        public ModeloBasicoMapping()
        {
            Id(p => p.Id);
            Map(p => p.Descripcion);
        }
    }

    public class EntidadRaizMapping : ClassMap<EntidadRaiz>
    {
        public EntidadRaizMapping()
        {
            Id(p => p.Guid);
            Map(p => p.Descripcion);
            HasMany<EntidadSecundaria>(a => a.Detalles)
                .Cascade.All();
        }
    }

    public class EntidadSecundariaMapping : ClassMap<EntidadSecundaria>
    {
        public EntidadSecundariaMapping()
        {
            Id(p => p.Id);
            Map(p => p.Cantidad);
            //References(m => m.Encabezado);
        }
    }

}