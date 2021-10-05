using P1_AP1_Carlos_20190720.BLL;
using P1_AP1_Carlos_20190720.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P1_AP1_Carlos_20190720.UI.Registros
{
    /// <summary>
    /// Interaction logic for rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        Aportes aportes = new Aportes();

        public object AportesBll { get; private set; }

        public rAportes()
        {
            InitializeComponent();
            this.DataContext = aportes;
        }

        private void Limpiar()
        {
            this.aportes = new Aportes();
            this.DataContext = aportes;

            aporteIDTextBox.Text = "";
            fechaDatePicker.SelectedDate = DateTime.Now;
            personaTextBox.Text = "";
            conceptoTextBox.Text = "";
            montoTextBox.Text = "";
        }

        private bool Validar()
        {
            String mensajeValidacion = "";

            if(int.Parse(aporteIDTextBox.Text) <= 0)
            {
                aporteIDTextBox.Focus();
                mensajeValidacion = "El ID no puede estar vacio ni menor a 0";
            }

            if(fechaDatePicker.Text.Length == 0)
            {
                fechaDatePicker.Focus();
                mensajeValidacion = "La fecha no puede estar vacia";
            }

            if (string.IsNullOrWhiteSpace(personaTextBox.Text))
            {
                personaTextBox.Focus();
                mensajeValidacion = "El campo persona no puede estar vacia";
            }

            if (string.IsNullOrWhiteSpace(conceptoTextBox.Text))
            {
                conceptoTextBox.Focus();
                mensajeValidacion = "El concepto no puede estar vacio";
            }

            if(int.Parse(montoTextBox.Text) <= 0)
            {
                montoTextBox.Focus();
                mensajeValidacion = "El monto no puede estar vacio ni menor a 0";
            }

            return mensajeValidacion.Length == 0;
        }



        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            var ciudad = AportesBLL.Buscar(int.Parse(aporteIDTextBox.Text));

            if (ciudad != null)
            {
                fechaDatePicker.SelectedDate = aportes.fechaAporte;
                personaTextBox.Text = aportes.persona;
                conceptoTextBox.Text = aportes.concepto;
                montoTextBox.Text = aportes.monto.ToString();

                this.aportes = ciudad;
            }
            else
            {
                this.aportes = new Aportes();
            }
            this.DataContext = this.aportes;
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            aportes.fechaAporte = fechaDatePicker.SelectedDate.Value;
            aportes.persona = personaTextBox.Text;
            aportes.concepto = conceptoTextBox.Text;
            aportes.monto = int.Parse(montoTextBox.Text);

            var paso = AportesBLL.Guardar(aportes);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AportesBLL.Eliminar(int.Parse(aporteIDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
