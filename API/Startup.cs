using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Datos.Entidades;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ISession = NHibernate.ISession;

namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AgregarContexto<Contexto>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }

    public static class Extensiones
    {
        public static IServiceCollection AgregarContexto<T>(this IServiceCollection servicios) where T : class
        {
            servicios.AddScoped<T>(proveedorDeServicios =>
            {
                Configuration configuracion = null;
                ISessionFactory sessionFactory = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.InMemory())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
                    .ExposeConfiguration(config => configuracion = config)
                    .BuildSessionFactory();

                ISession session = sessionFactory.OpenSession();
                
                var export = new SchemaExport(configuracion);
                export.Execute(true, true, false, session.Connection, null);
                return Activator.CreateInstance(typeof(T), session) as T;
            });

            return servicios;
        }
    }
}
