using System;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestAlumnoNulo()
            {
                string dni = "0";
                Alumno a1 = null;
                try
                {
                    a1 = new Alumno(1, "0", "0", dni, Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
                    Assert.Fail("El alumno tiene datos invalidos, por lo tanto no se deberia crear");
                }
                catch (Exception)
                {
                    Assert.IsNull(a1);


                }

            }
            [TestMethod]
            public void TestRangoNumerico()
            {
                Alumno al = null;
                try
                {
                    al = new Alumno(1, "Nombre", "Apellido", "0", Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
                    Assert.Fail("Dni menor por lo que no deberia cargarse");
                }
                catch (Exception)
                {

                    Assert.IsNull(al);

                }
                try
                {
                    al = new Alumno(1, "Nombre", "Apellido", "90000000", Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
                    Assert.Fail("Dni mayor por lo que no deberia cargarse");
                }
                catch (Exception)
                {

                    Assert.IsNull(al);

                }
            }
            [TestMethod]
            public void ValidarSinInstructor()
            {
                try
                {
                    Gimnasio test;
                    test = new Gimnasio();

                    test += Gimnasio.EClases.Natacion;

                    Assert.Fail("No hay instructor");
                }
                catch (Exception ex)
                {
                    Assert.IsInstanceOfType(ex, typeof(SinInstructorException));
                }
            }
            [TestMethod]
            public void TestDNIExtranjero()
            {
                Alumno Al = null;
                try
                {
                    Al = new Alumno(1, "Nombre", "Apellido", "4000000", Persona.ENacionalidad.Extranjero, Gimnasio.EClases.CrossFit);
                    Assert.Fail("Dni invalido");

                }
                catch (Exception e)
                {

                    Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));

                }


            }
            [TestMethod]
            public void ValidarAlumnoRepetido()
            {
                try
                {
                    Alumno alumnoUno;
                    alumnoUno = new Alumno(1, "Nombre", "Apellido", "100", Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.AlDia);

                    Alumno alumnoDos;
                    alumnoDos = new Alumno(5, "Nombre", "Apellido", "100", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates, Alumno.EEstadoCuenta.AlDia);

                    Gimnasio gimnasioPrueba = new Gimnasio();

                    gimnasioPrueba += alumnoUno;
                    gimnasioPrueba += alumnoDos;

                    Assert.Fail("Alumno repetido");
                }
                catch (Exception ex)
                {
                    Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
                }
            }
        }
    }
}
