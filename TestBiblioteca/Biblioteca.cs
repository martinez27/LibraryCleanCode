using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using PruebaIngresoBibliotecario.TestBiblioteca;
using System;
using System.Net;
using System.Net.Http.Formatting;
using Xunit;

namespace TestBiblioteca
{
    public class Biblioteca : IDisposable
    {
        protected HttpClient TestClient;
        private bool Disposed;

        public Biblioteca()
        {
            Initialize();
        }

        protected void Initialize()
        {
            Disposed = false;
            var appFactory = new WebApplicationFactory<PruebaIngresoBibliotecario.Api.Startup>();
            TestClient = appFactory.CreateClient();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                TestClient.Dispose();
            }

            Disposed = true;
        }

        [Fact]
        public void TestsinISBN()
        {
            HttpResponseMessage respuesta = null;
            CalcularFecha calcularFecha = new CalcularFecha();
            try
            {
                var solicitudPrestamo = new
                {
                    TipoUsuario = TipoUsuarioPrestamo.AFILIADO,
                    IdentificacionUsuario = Guid.NewGuid().ToString()
                };

                var fechaEsperadaAfiliado = calcularFecha.CalcularFechaEntrega(TipoUsuarioPrestamo.AFILIADO).ToShortDateString();

                respuesta = this.TestClient.PostAsync("api/prestamo", solicitudPrestamo, new JsonMediaTypeFormatter()).Result;
                respuesta.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                respuesta.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }
    }
}
