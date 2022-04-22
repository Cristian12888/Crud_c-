using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EstudianteCrud.Modelo;
using EstudianteCrud.Datos;


namespace EstudianteCrud.Vista
{
    public partial class VistaEstudiante : Form
    {
        public VistaEstudiante()
        {
            InitializeComponent();
        }


        private void VistaEstudiante_Load(object sender, EventArgs e)
        {
            ListarEstudiantes();
        }

        private void ListarEstudiantes()
        {
            ClsEstudiante es=new ClsEstudiante();

            dtgEstudiante.DataSource = es.ListarEstudiante();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Estudiante es = new Estudiante();

                es.Documento1 = txtDocumento.Text;
                es.Nombre1 = txtNombre.Text;
                es.Apellido1 = txtApellido.Text;
                es.Edad1 = Convert.ToInt32(txtEdad.Text);
                es.Correo1 = txtCorreo.Text;
                es.Telefono1 = txtTelefono.Text;

                if(ClsEstudiante.InsertarEstudiante(es))
                {
                    MessageBox.Show("Se Guardo El estudiante");
                    ListarEstudiantes();
                    LimpiarCampos();

                }else
                {
                    MessageBox.Show("No se Guardo El estudiante");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }    

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Estudiante es = ClsEstudiante.ConsultarEstudiante(txtDocumento.Text);


            if(es==null)
            {
                MessageBox.Show("El Estudiante no existe");
            }else
            {
                txtDocumento.Text = es.Documento1;
                txtNombre.Text = es.Nombre1;
                txtApellido.Text = es.Apellido1;
                txtEdad.Text = es.Edad1.ToString();
                txtCorreo.Text = es.Correo1;
                txtTelefono.Text = es.Telefono1;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Estudiante es = new Estudiante();

                es.Documento1 = txtDocumento.Text;
                es.Nombre1 = txtNombre.Text;
                es.Apellido1 = txtApellido.Text;
                es.Edad1 = Convert.ToInt32(txtEdad.Text);
                es.Correo1 = txtCorreo.Text;
                es.Telefono1 = txtTelefono.Text;

                if (ClsEstudiante.EditarEstudiante(es))
                {
                    MessageBox.Show("Se edito el estudiante");
                    ListarEstudiantes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se edito el estudiante");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(ClsEstudiante.EliminarEstudiante(txtDocumento.Text))
            {
                ListarEstudiantes();
                LimpiarCampos();
                MessageBox.Show("Eliminado");
            }else
            {
                MessageBox.Show("No Eliminado");
            }
        }

        private void LimpiarCampos()
        {
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text= "";
            txtEdad.Text = "";
            txtCorreo.Text= "";
            txtTelefono.Text= "";

        }

        private void dtgEstudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
