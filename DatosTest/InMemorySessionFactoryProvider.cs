using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Datos;
using Datos.Entidades;
using FluentNHibernate;

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
            _sessionFactory = CreateSessionFactory<EntidadRaiz>();
        }

        private ISessionFactory CreateSessionFactory<T>()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile("TestBD.mdf"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
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

            //var export = new SchemaExport(_configuration);
            //export.Execute(true, true, false, session.Connection, null);

            var export2 = new SchemaUpdate(_configuration);
            export2.Execute(true, true);
            
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