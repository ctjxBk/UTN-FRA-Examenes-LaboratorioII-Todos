using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Comercio : IBackup
    {
        List<Cliente> clientes;

        public List<Cliente> Clientes { get => clientes; set => clientes = value; }

        public Comercio()
        {
            clientes = new List<Cliente>();
        }

        private Stream ruta;

        public Stream Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }

        public void LoadBackup()
        {
            using (XmlTextReader reader = new XmlTextReader(Ruta))//cambiar path
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Cliente>));
                
                clientes = (List<Cliente>)ser.Deserialize(reader);
            }
        }

        public void SaveBackup()
        {
            using (XmlTextWriter writer = new XmlTextWriter(Ruta, Encoding.UTF8))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Cliente>));
                ser.Serialize(writer, this.clientes);
            }
        }
        public static Comercio operator +(Comercio c, Cliente cli)
        {
            if (c.clientes.Count == 0)
            {
                cli.Numero = 1;
            }
            else
            {
                cli.Numero = c.clientes[c.clientes.Count-1].Numero + 1;
            }
            c.clientes.Add(cli);
            return c;
        }
        public Cliente LlamarCliente()
        {
            if (this.clientes.Count == 0)
            {
                throw new SinClientesException();
            }
            else
            {
                Cliente c = clientes[0];
                clientes.RemoveAt(0);
                return c;
            }

        }

    }
}
