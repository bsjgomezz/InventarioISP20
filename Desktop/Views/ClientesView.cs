using Desktop.Models;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class ClientesView : Form
    {
        ClienteService clienteService = new ClienteService();
        Cliente clienteModificado;
        public ClientesView()
        {
            InitializeComponent();
            LoadClientes();
            //clienteService
        }

        private async void LoadClientes()
        {
            var clientes = await clienteService.GetAllAsync();
            if (clientes != null)
            {
                dataGridClientes.DataSource = clientes;
            }
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            var clientes = await clienteService.GetAllWithFiltersAsync(BoxBuscar.Text);
            if (clientes != null)
            {
                dataGridClientes.DataSource = clientes;

            }

        }



        private async void btnguardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                firstname = txtNombre.Text,
                lastname = txtApellido.Text,
                dni = txtDni.Text,
                address = txtDireccion.Text
            };
            bool clienteGuardado;
            if (clienteModificado == null)
                clienteGuardado = await clienteService.AddClienteAsync(cliente);
            else
            {
                cliente.id = clienteModificado.id;
                cliente.created_at = clienteModificado.created_at;
                clienteGuardado = await clienteService.updateClienteAsync(cliente);
            }
            if (clienteGuardado)
            {
                MessageBox.Show("Cliente guardado correctamente :D");
                LoadClientes();
                ClearTextBox();
                tabControl1.SelectedTab = TabPageLista;
                clienteModificado = null;
            }
            else
                MessageBox.Show("error al guardar el cliente );");
    
        }

        private void ClearTextBox()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = TabPageLista;
            ClearTextBox();
            clienteModificado = null;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //Capturamos los datos del clientes seleccionado en el DataGridView y los mostramos en los TextBox para poder editarlos
            if (dataGridClientes.CurrentRow != null)
            {
                clienteModificado = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
                txtNombre.Text = clienteModificado.firstname;
                txtApellido.Text = clienteModificado.lastname;
                txtDni.Text = clienteModificado.dni;
                txtDireccion.Text = clienteModificado.address;
                //Cambiamos a la pestaña de agregar/editar para mostrar los datos del cliente seleccionado
                tabControl1.SelectedTab = tabPageAgregarEditar;
            } 
            else {
                MessageBox.Show("Por favor, seleccione un cliente para modificar ;).");
            }
        }
    }
}
