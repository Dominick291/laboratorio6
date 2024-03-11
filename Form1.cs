using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace laboratorio6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Clientes> clientess = new List<Clientes>();
        List<Vehiculos> vehiculoss = new List<Vehiculos>();
        List<Alquiler> alquilers = new List<Alquiler>();

        public void cargarClientes()
        {
            String fileName = "Clientes.txt";


            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Clientes clientes = new Clientes();
                clientes.Nit = Convert.ToInt32(reader.ReadLine());
                clientes.Nombre = reader.ReadLine();
                clientes.Direccion = reader.ReadLine();
            
                clientess.Add(clientes);

            }
            reader.Close();
        }

        public void cargarAlquileres()
        {
            String fileName = "Alquileres.txt";


            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Alquiler alquileres = new Alquiler();
                alquileres.Nit = Convert.ToInt32(reader.ReadLine());
                alquileres.Placa = reader.ReadLine();
                alquileres.FechaAlq = Convert.ToDateTime(reader.ReadLine());
                alquileres.FechaDev = Convert.ToDateTime(reader.ReadLine());
                alquileres.Kilometros = Convert.ToInt32(reader.ReadLine());

                alquilers.Add(alquileres);

            }
            reader.Close();
        }
        public void MostrarClientes()
        {

            //mostrar la lista de empleados en el gridview 
            dataGridViewClientes.DataSource = null;
            dataGridViewClientes.DataSource = clientess;
            dataGridViewClientes.Refresh();
        }
        public void Mostrarvehiculos()
        {

            //mostrar la lista de empleados en el gridview 
            dataGridViewVehiculos.DataSource = null;
            dataGridViewVehiculos.DataSource = vehiculoss;
            dataGridViewVehiculos.Refresh();
        }
        public void MostrarAlquiler()
        {

            //mostrar la lista de empleados en el gridview 
            dataGridViewAlquiler.DataSource = null;
            dataGridViewAlquiler.DataSource = alquilers;
            dataGridViewAlquiler.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cargarClientes();
            MostrarClientes();
            cargarAlquileres();
            MostrarAlquiler();
            
        }
    }
}
