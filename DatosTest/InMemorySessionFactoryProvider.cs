using System.Diagnostics;
using System.IO;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Datos;
using Datos.Entidades;

namespace DatosTest
{
    public class InMemorySessionFactoryProvider
    {
        private static InMemorySessionFactoryProvider _instance;
        public static InMemorySessionFactoryProvider Instance
        {
            get { return _instance ??= new InMemorySessionFactoryProvider(); }
        }

        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        private InMemorySessionFactoryProvider() { }

        public void Initialize()
        {
            _sessionFactory = CreateSessionFactory();
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EntidadRaiz>())
                .ExposeConfiguration(config =>
                {
                    config.DataBaseIntegration(db =>
                    {
                        db.LogFormattedSql = true;
                        db.LogSqlInConsole = true;
                    });
                    //config.SetInterceptor(new SqlStatementInterceptor());

                    _configuration = config;
                })
                .BuildConfiguration()
                .BuildSessionFactory();
        }

        public ISession OpenSession() 
        {
            ISession session = _sessionFactory.OpenSession();

            var export = new SchemaExport(_configuration);
            export.Execute(true, true, false, session.Connection, null);
            
            return session;
        }

        public void Dispose()
        {
            _sessionFactory?.Dispose();
            

            _sessionFactory = null;
            _configuration = null;
        }
    }

    
}