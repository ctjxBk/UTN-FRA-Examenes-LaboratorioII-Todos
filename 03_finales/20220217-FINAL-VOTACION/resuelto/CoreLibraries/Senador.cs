using System;
using System.Data.SqlClient;
using System.Drawing;

namespace CoreLibraries
{

    public enum Evoto { Indefinido, Abstencion, Positivo, Negativo}
    
    public class Senador : IParlamento
    {
        private string banca;
        private object controlVisual;
        private bool presentismo;
        private Evoto voto;

        public bool AperturaSesion
        {
            set
            {
                //si recibo true
                if (value == true)
                {
                    if (this.banca == "P")
                    {
                        this.Presentismo = value;
                    }
                    else
                    {
                        // TODO:  Asignar presentismo
                        this.presentismo = new Random().Next(0,2) == 0 ? true : false;
                    }
                }
                else
                {
                    this.Presentismo = false;
                }
            }
            get
            {
                return this.presentismo;
            }
        }

        public string Banca
        {
            get
            {
                return this.banca;//base.nombreCompleto;
            }
            set
            {
                //base.nombreCompleto = value;
                this.banca = value;
            }
        }


        public Color ColorDeBanca
        {
            get
            {
                if (this.presentismo)
                {
                    switch (this.Voto)
                    {
                        case Evoto.Abstencion:
                            return Color.FromArgb(0, 200, 255);
                        case Evoto.Negativo:
                            return Color.DarkRed;
                        case Evoto.Positivo:
                            return Color.DarkGreen;
                        default:
                            return Color.DarkBlue;
                    }
                }
                else
                    return Color.Black;
            }
        }

        [System.Text.Json.Serialization.JsonIgnore]
        public object ControlVisual { get => controlVisual; set => controlVisual = value; }

        public bool Presentismo
        {
            get { return presentismo; }
            set => presentismo = value;
        }

        public Evoto Voto
        {
            get { return voto; }
            set => voto = value;
        }

        public void EmitirVoto()
        {
            this.Voto = (Evoto)new Random().Next(1, 4);
        }



        public Senador(string banca, object controlVisual)
            //: base(banca)
        {
            this.banca = banca;
            this.controlVisual = controlVisual;
            this.voto = Evoto.Indefinido;
        }



    }
}
