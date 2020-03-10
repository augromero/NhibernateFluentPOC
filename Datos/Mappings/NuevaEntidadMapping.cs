using System;
using System.Collections.Generic;
using System.Text;
using Datos.Entidades;
using FluentNHibernate.Mapping;

namespace Datos.Mappings
{
    public class NuevaEntidadMapping : ClassMap<NuevaEntidad>
    {
        public NuevaEntidadMapping()
        {
            Id(p => p.Id)
                .GeneratedBy.Identity();
            Map(p => p.ColumnaUno);
            Map(p => p.ColumnaDos);
        }
    }
}
