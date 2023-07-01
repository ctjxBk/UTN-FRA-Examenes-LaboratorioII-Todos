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

        }

        [TestMethod]
        public void SerializarObjetosInflables()
        {
            #region Consigna
            /*
               serializar una la pelota a json y la lista de vehiculos (al menos 2) a xml  o Json
             */
            #endregion

           
        }

        [TestMethod]
        public void InsertarYLeerDatosDB()
        {
            #region Consigna
            /*
               crear un Auto, guardarlo en la base de datos
               volver a obtener el registro de la base y comparar que su informacion sea la enviada
            */
            #endregion

          
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

        }

    }
}
