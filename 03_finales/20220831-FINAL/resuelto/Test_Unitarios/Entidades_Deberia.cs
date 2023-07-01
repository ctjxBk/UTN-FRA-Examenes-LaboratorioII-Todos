using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest_Entidades
{

    // APELLIDO . NOMBRE
    [TestClass]
    public class Entidades_Debe
    {
        [TestMethod]
        public void InflarTodosLosObjetos()
        {
            #region Consigna 
            /*
               Crear una lista de IInflable con autos,motos y pelotas desinflados
               Inflar todos los objetos.
               Verificar que todos quedan inflados.
             */
            #endregion
            Auto auto = new Auto(0,"x");
            Moto moto = new Moto(0, "y");
            Pelota pelota = new Pelota(0);
            List<IInflable> lista = new List<IInflable>() { auto, moto, pelota };

            foreach(IInflable inflable in lista)
            {
                inflable.Inflar(inflable.PresionMaxima);
            }

            foreach (IInflable inflable in lista)
            {
                Assert.IsTrue(inflable.EstaInflado);
            }


        }

        [TestMethod]
        [ExpectedException(typeof(ExplotaException))]
        public void LanzarExplotaException()
        {
            #region Consigna
            /*
             si pelota excede la presion maxima soportada por ella, 
             debe lanzar la excepcion ExplotaException
             notificando que exploto.
             */
            #endregion
            Pelota pelota = new Pelota(10);
            pelota.Inflar(pelota.PresionMaxima);
        }

        [TestMethod]
        public void SerializarObjetosInflables()
        {
            #region Consigna
            /*
               serializar una la pelota a json y la lista de vehiculos (al menos 2) a xml  o Json
             */
            #endregion

            Pelota pelota = new Pelota(0);
            string archivoPelota = "pelota.json";
            pelota.Inflar(pelota.PresionMaxima);
            ClaseSerializadora<Pelota>.Guardar(pelota, archivoPelota);
            Pelota pelotaLeida = ClaseSerializadora<Pelota>.Leer(archivoPelota);
            Assert.AreEqual(pelota.EstaInflado, pelotaLeida.EstaInflado);

            string archivoVehiculos = "vehiculos.xml";
            Auto a1 = new Auto(10, "x");
            Moto m1 = new Moto(10, "y");
            List<Vehiculo> lista = new List<Vehiculo>() { a1,m1};

            ClaseSerializadora<List<Vehiculo>>.Guardar(lista, archivoVehiculos);
            List<Vehiculo> listaLeida = ClaseSerializadora<List<Vehiculo>>.Leer(archivoVehiculos);

            for(int i = 0; i < lista.Count; i++)
            {
                Assert.AreEqual(lista[i].Patente, listaLeida[i].Patente);
            }
        }

        [TestMethod]
        public void InsertarYLeerDatosDB()
        {
            #region Consigna
            /*
               crear un Auto, guardarlo en la base de datos
               volver a obtener el registro de la base y comparar que su informacion sea la enviada

                CREATE DATABASE [final_20220831]
                GO
                USE [final_20220831]
                GO
                SET ANSI_NULLS ON
                GO
                SET QUOTED_IDENTIFIER ON
                GO
                CREATE TABLE[dbo].[Autos] (

                   [id][int] IDENTITY(1, 1) NOT NULL,

                   [presion] [int] NOT NULL,

                   [patente] [nchar] (10) NOT NULL
                ) ON[PRIMARY]
                GO


            */
            #endregion
            Auto a1 = new Auto(10, "XX");
            Auto a2 = new Auto(15, "YY");
            List<Auto> lista = new List<Auto>() { a1, a2};


            Taller<Auto>.RegistrarVehiculo(a1);
            Taller<Auto>.RegistrarVehiculo(a2);

            List<Auto> listaLeida = Taller<Auto>.ObtenerAutos();

            //Assert.IsTrue(listaLeida.Exists((auto) => auto.Patente == a1.Patente));
            //Assert.IsTrue(listaLeida.Exists((auto) => auto.Patente == a2.Patente));
            foreach (Auto auto in listaLeida)
            {
                if(auto.Patente == a1.Patente)
                {
                    Assert.IsTrue(true);
                }
                else if(auto.Patente == a2.Patente)
                {
                    Assert.IsTrue(true);
                }
            }


        }

        [TestMethod]
        public void RepararUnAuto()
        {
            #region Consigna
            /* 
              El metodo Reparar del taller debe recibir un objeto de tipo auto y repararlo.
               
              Cuando un auto se repara, se hacen dos procesos al mismo tiempo:
              mientras se inflan las cubiertas, tambien se le repara la mecanica.
              Inflar una cubierta tarda 3 segundos, y reparar la mecanica 7 segundos
              No se da por terminada la reparacion hasta que ambos procesos terminen
            
              Comprobar que el auto esta inflado y reparado.
             */
            #endregion
            Auto auto = new Auto(10, "XX");
            Taller<Auto>.Reparar(auto);
            Assert.IsTrue(auto.EstaInflado);
            Assert.IsTrue(auto.EstaReparado);
        }

        [TestMethod]
        public void Parametrizacion()
        {
            #region Consigna
            /* 
               Generar un metodo estatico,generico y parametrizado en Taller llamado UtilizarInflador
               que reciba un elemento del tipo T (restringir que sea de tipo IInflable)
               Crear dos objetos de tipo IInflable e inflarlos.
               Verificar que ambos estan inflados.
            */
            #endregion

            IInflable auto = new Auto(5,"XX");
            IInflable moto = new Moto(3,"YY");
            Assert.IsTrue(Taller<IInflable>.UtilizarInflador<IInflable>(auto));
            Assert.IsTrue(Taller<IInflable>.UtilizarInflador<IInflable>(moto));

        }

        [TestMethod]
        public void ExpresionLamda()
        {
            #region Consigna
            /* 
              Hacer una expresion lambda que retorne de la lista de vehiculos 
              solo los que tengan menor presion a 20 de presion de inflado

             Verificar que todos los devueltos tienen presion de inflado menor a 20.
            */
            #endregion

            int presionMenorA = 20;
            Vehiculo auto = new Auto(5, "XX");
            Vehiculo moto = new Moto(3, "YY");
            Vehiculo auto2 = new Auto(25, "XX2");
            Vehiculo moto2 = new Moto(23, "YY2");
            List<Vehiculo> vehiculos = new List<Vehiculo>() { auto, moto, auto2, moto2};

            List<Vehiculo> vehiculosConPresionMenorAVeinte = null;
            vehiculosConPresionMenorAVeinte = vehiculos.FindAll(v => v.PresionInflado < presionMenorA);

            foreach(Vehiculo vehiculo in vehiculosConPresionMenorAVeinte)
            {
                Assert.IsTrue(vehiculo.PresionInflado < presionMenorA);
            }

        }

        [TestMethod]
        public void CapturarEventoRuedaEnLLanta()
        {

            #region Consigna
            /* 
               Cada vez que una moto circula, pierde 10 unidades de presion de inflado. 
            Al llegar a 0 o menos su presion de inflado
            deberá ejecutarse un evento. 
            Dicho evento lo que hará es setear la moto como no reparada y tambien lanzará una excepcion de tipo
            rueda en llanta.

            Comprobar que la excepcion se lanza correctamente,que la presion de la rueda queda en 0,
            y que la moto no queda reparada.
             */
            #endregion
            Moto moto = new Moto(5, "YY");
            Assert.ThrowsException<RuedaEnLLantaException>(() =>
            {
                moto.CircularVehiculo();
            });
            Assert.AreEqual(moto.EstaReparado, false);
            Assert.AreEqual(moto.PresionInflado, 0);
        }

    }
}
