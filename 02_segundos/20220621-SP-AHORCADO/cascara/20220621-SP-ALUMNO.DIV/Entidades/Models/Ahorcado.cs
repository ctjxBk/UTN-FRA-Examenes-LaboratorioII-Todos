using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades.Models
{
//15.Ahorcado, será genérica, solo podrá recibir tipos que implementen
//  la interfaz Ilector y posean un constructor publico sin parámetros:
//  a.En su constructor publico sin parámetros realizar:
//      i.Instanciar el atributo entidad.
//      ii.Inicializar:
//          1.	estaAdivinada en false.
//          2.	cantidadIntentosPorPalabra y cantidadAciertos en 0 (cero).
//          3.	palabraSecreta en empty.
//16.La propiedad Activar:
//  a.El GET retornara True, si la tares no es nula y estado de la tarea es Running o WaitingToRun o WaitingForActivation.
//  b.En el SET, si el valor recibido es TRUE y la tarea es nula o su estado no es Running o no es WaitingToRun o no es WaitingForActivation, se instanciará un nuevo CancelationTokenSource y se llamará a IniciarJuego. De lo contrario se llamará al método Cancel de cancellation.
//17.El método IniciarJuego será privado y:
//  a.Ejecutara en un hilo secundario la acción de que:
//      i.Mientras no se requiera cancelación de la tarea invocara al mensaje
//      NotificarNuevaPalabra y luego NotificarSegundosRestantes.Para este último enviar 30 segundos.
//18.El método NotificarNuevaPalabra, verificara si el evento OnPalabra posee suscriptores
//  y en caso exitoso realizara:
//  a.Cambiar el estado del atributo estaAdivinada a False.
//  b.Guardara en palabraSecreta el valor obtenido desde la entidad.
//  c.cantidadDeIntentosPorPalabra será igual al doble de la longitud de la palabra secreta.
//  d.Notificara la palabra secreta.
//19.El método NotificarSegundosRestantes si posee un suscriptor notificara los segundos
//restantes mientras que (Utilizar Thread.Sleep para dormir el hilo 1 segundos antes de ir decrementando):
//  a.segundosRestantes sea mayor o igual a cero.
//  b.El hilo secundario no requiera cancelación.
//  c.La palabra no haya sido adivinada.
//  d.La cantidad de intentos sea mayor que 0 (cero).
//20.El método AsertarPalabra comparara la palabra secreta con la recibida por parámetro (usar ToLower para comparar).  Si son iguales cambiara el estado de estaAdivinada a True e incrementara el valor de cantidadDeAciertos en 1 (uno). De lo contrario restara cantidadDeIntentosPorPalabra.

    public class Ahorcado
    {

       

    }
}
