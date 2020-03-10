using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Entidades
{
    public class NuevaEntidad
    {
        public virtual int Id { get; set; }

        public virtual string ColumnaUno { get; set; }

        public virtual string ColumnaDos { get; set; }
    }
}
