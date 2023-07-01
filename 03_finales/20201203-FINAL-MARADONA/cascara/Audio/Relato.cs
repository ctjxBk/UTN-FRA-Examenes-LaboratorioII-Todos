using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace Audio
{
    public static class Relato
    {

        public static void VictorHugoMorales()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = "gol-del-siglo-relatado.mp3";
            wplayer.controls.play();

            // Agregar invocación al evento
            
            System.Threading.Thread.Sleep(1000);
            do
            {
                // Agregar invocación al evento
                
                System.Threading.Thread.Sleep(1800);
            } while (wplayer.playState != WMPLib.WMPPlayState.wmppsStopped);
            System.Threading.Thread.Sleep(2000);
            // Agregar invocación al evento
            
        }
    }
}
