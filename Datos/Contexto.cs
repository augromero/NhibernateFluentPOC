using System;
using System.Linq;
using Datos.Entidades;
using NHibernate;

namespace Datos
{
    public class Contexto : IDisposable
    {
        public readonly ISession _sesion;

        public IQueryable<EntidadRaiz> EntidadRaiz => _sesion.Query<EntidadRaiz>();

        public Contexto(ISession sesion)
        {
            _sesion = sesion;
        }

        public void Dispose()
        {
            _sesion.Close();
            _sesion.Dispose();
        }
    }
}