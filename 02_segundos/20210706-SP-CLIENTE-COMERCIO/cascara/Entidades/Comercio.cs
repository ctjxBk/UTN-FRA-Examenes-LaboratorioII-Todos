using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Comercio : IBackup
    {
        private List<Cliente> clientes;

        public List<Cliente> Clientes { get => clientes; set => clientes = value; }

        public Comercio()
        {
            this.clientes = new List<Cliente>();
        }

        public Cliente LlamarCliente()
        {
            if(this.clientes.Count == 0)
            {
                throw new SinClientesException("No hay mas clientes");
            }
            //else
            //{
            Cliente c = this.clientes[0];
            this.clientes.RemoveAt(0);
            return c;
            //}
        }

        public static bool operator +(Comercio comercio, Cliente cliente)
        {
            if(comercio is not null && cliente is not null)
            {
                if(comercio.Clientes.Count == 0)
                {
                    cliente.Numero = 1;
                    comercio.Clientes.Add(cliente);   
                }
                else
                {
                    int ultimo = comercio.clientes.Count - 1;
                    int numeroDelUltimo = comercio.clientes[ultimo].Numero;
                    numeroDelUltimo++;
                    cliente.Numero = numeroDelUltimo;
                    comercio.clientes.Add(cliente);
                }
            }
            return false;
        }

        public void LoadBackup(string path)
        {
            //throw new NotImplementedException();
            using (StreamReader streamReader = new StreamReader(path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Cliente>));
                this.clientes = xmlSerializer.Deserialize(streamReader) as List<Cliente>;
            }
        }

        public void SaveBackup(string path)
        {
            //throw new NotImplementedException();
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Cliente>));
                xmlSerializer.Serialize(streamWriter, this.clientes);
            }
        }
    }
}
