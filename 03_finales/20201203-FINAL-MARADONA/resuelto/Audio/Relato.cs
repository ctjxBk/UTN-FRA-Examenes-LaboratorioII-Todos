﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Resources;

namespace Audio
{
    public delegate void AvanceRelato();

    public static class Relato
    {
        public static event AvanceRelato Avanzar;
        public static event Action Guardar;

        public static void VictorHugoMorales()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = "gol-del-siglo-relatado.mp3";
            wplayer.controls.play();

            Relato.Guardar?.Invoke();

            // Agregar invocación al evento
            Relato.Avanzar?.Invoke();

            System.Threading.Thread.Sleep(1000);
            do
            {
                // Agregar invocación al evento
                Relato.Avanzar?.Invoke();

                System.Threading.Thread.Sleep(1800);
            } while (wplayer.playState != WMPLib.WMPPlayState.wmppsStopped);
            System.Threading.Thread.Sleep(2000);
            
            // Agregar invocación al evento
            Relato.Avanzar?.Invoke();

            
        }
    }
}
