using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Datos;
using Datos.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Linq;

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
            var modeloBasico = new ModeloBasico("Primero", 33.44m, 33.44m);

            _contexto.Save(modeloBasico);
            _contexto.Flush();

            ModeloBasico modeloGuardado = _contexto.Load<ModeloBasico>(1);

            Assert.AreEqual("Primero", modeloGuardado.Descripcion);
            Assert.AreEqual(33.44m, modeloGuardado.ValorMoney);
        }

        [TestMethod]
        public void DebeGuardarAgregado()
        {

            var agregado = new EntidadRaiz("Raiz");
            agregado.AgregarSecundaria(new EntidadSecundaria(10));
            agregado.AgregarSecundaria(new EntidadSecundaria(15));

            _contexto.Save(agregado);
            _contexto.Flush();

            var agregadoGuardado = _contexto.Query<EntidadRaiz>()
                .Fetch(entidad => entidad.Detalles)
                .First();

            Assert.AreEqual(10, agregadoGuardado.Detalles[0].Cantidad);
        }

        [TestMethod]
        public void DebeCompararCorrectamenteDecimalesMoney()
        {
            var modeloBasico = new ModeloBasico("Primero", 33.44m, 33.44m);

            _contexto.Save(modeloBasico);
            _contexto.Flush();

            var modeloObtenido = _contexto.Query<ModeloBasico>().Where(m => m.ValorMoney >= 33.44m).ToList();

            Assert.IsNotNull(modeloObtenido.First().Id);
        }

        [TestMethod]
        public void DebeCompararCorrectamenteDecimales()
        {
            var modeloBasico = new ModeloBasico("Primero", 33.44m, 33.44m);

            _contexto.Save(modeloBasico);
            _contexto.Flush();

            var modeloObtenido = _contexto.Query<ModeloBasico>().Where(m => m.ValorDecimal >= 33.44m).ToList();

            Assert.IsNotNull(modeloObtenido.First().Id);
        }

        [TestMethod]
        public void DebeGuardarValueObjects()
        {
            var entidadConValueObject = new EntidadConValueObject(new Dinero(1_000.25m, Moneda.COP), new Dinero(100m, Moneda.COP));

            _contexto.Save(entidadConValueObject);
            _contexto.Flush();

            var entidadRecuperada = _contexto.Query<EntidadConValueObject>().First();

            Assert.AreEqual(new Dinero(1_000.25m, Moneda.COP), entidadRecuperada.Dinero);
            Assert.AreEqual(new Dinero(100, Moneda.COP), entidadRecuperada.Dinero2);
        }

        [TestMethod]
        public void DebeGuardarYObtenerValueObjectCompuestos()
        {
            var dinero = new Dinero(10_000m, Moneda.COP);
            var valueObjectCompuesto = new ValueObjectCompuesto(dinero, DateTime.MaxValue);

            var entidadConValueObjectCompuesto = new EntidadConValueObjectCompuesto(valueObjectCompuesto);

            _contexto.Save(entidadConValueObjectCompuesto);
            _contexto.Flush();

            var entidadConValueObjectCompuestoObtenido = _contexto.Query<EntidadConValueObjectCompuesto>().First();

            Assert.AreEqual(dinero, entidadConValueObjectCompuestoObtenido.Compuesto.Dinero);
            Assert.AreEqual(valueObjectCompuesto, entidadConValueObjectCompuestoObtenido.Compuesto);
        }

        [TestCleanup]
        public void Limpiar()
        {
            InMemorySessionFactoryProvider.Instance.Dispose();
        }
    }
}
