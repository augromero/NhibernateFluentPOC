using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Datos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace DatosTest
{
    [TestClass]
    public class DatosUnitTest
    {
        private ISession _contexto;
        [TestInitialize]
        public void Inicializar()
        {
            InMemorySessionFactoryProvider.Instance.Initialize();
            _contexto = InMemorySessionFactoryProvider.Instance.OpenSession();
        }

        [TestMethod]
        public void DebeInstanciarBaseDatosEnMemoria()
        {
            Assert.IsTrue(_contexto.IsConnected);
        }

        [TestMethod]
        public void DebeGuardarUnModeloBasico()
        {
            var modeloBasico = new ModeloBasico("Primero");

            _contexto.Save(modeloBasico);

            ModeloBasico modeloGuardado = _contexto.Load<ModeloBasico>(1);

            Assert.AreEqual("Primero",  modeloGuardado.Descripcion);
        }

        [TestMethod]
        public void DebeGuardarAgregado()
        {
            var agregado = new EntidadRaiz("Raiz");
            agregado.AgregarSecundaria(new EntidadSecundaria(10));
            agregado.AgregarSecundaria(new EntidadSecundaria(15));

            _contexto.Save(agregado);
            _contexto.Flush();

            var agregadoGuardado = _contexto.Query<EntidadRaiz>().First();

            Assert.IsNotNull(agregadoGuardado);
        }

        [TestCleanup]
        public void Limpiar()
        {
            InMemorySessionFactoryProvider.Instance.Dispose();
        }
    }
}
