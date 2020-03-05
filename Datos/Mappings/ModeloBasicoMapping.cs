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
}