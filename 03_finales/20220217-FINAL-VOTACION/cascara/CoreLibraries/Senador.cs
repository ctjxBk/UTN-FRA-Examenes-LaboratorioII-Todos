using System;
using System.Drawing;

namespace CoreLibraries
{
    public class Senador
    {
        private object controlVisual;

        [System.Text.Json.Serialization.JsonIgnore]
        public object ControlVisual { get => controlVisual; set => controlVisual = value; }

        public Color ColorDeBanca
        {
            get
            {
                if (this.)
                {
                    switch (this.)
                    {
                        case .Abstencion:
                            return Color.FromArgb(0,200,255);
                        case .Negativo:
                            return Color.DarkRed;
                        case .Positivo:
                            return Color.DarkGreen;
                        default:
                            return Color.DarkBlue;
                    }
                }
                else
                    return Color.Black;
            }
        }

        public bool AperturaSesion
        {
            set
            {
                if (value)
                {
                    if (this.banca == "P")
                    {
                        this.Presentismo = value;
                    }
                    else
                    {
                        // TODO:  Asignar presentismo

                    }
                }
                else
                {
                    this.Presentismo = false;
                }
            }
        }
    }
}
