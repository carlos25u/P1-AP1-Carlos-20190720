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

namespace P1_AP1_Carlos_20190720.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cAportes.xaml
    /// </summary>
    public partial class cAportes : Window
    {
        public cAportes()
        {
            InitializeComponent();
        }

        private void consultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Aportes>();

            if (filtroTextBox.Text.Trim().Length > 0)
            {
                switch (filtroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = AportesBLL.GetList(e => e.persona.ToLower().Contains(filtroTextBox.Text.ToLower()));
                        break;

                    case 1:
                        listado = AportesBLL.GetList(e => e.concepto.ToLower().Contains(filtroTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = AportesBLL.GetList(c => true);
            }

            if (desdeDatePicker.SelectedDate != null)
                listado = AportesBLL.GetList(c => c.fechaAporte.Date >= desdeDatePicker.SelectedDate);

            if (hastaDatePicker.SelectedDate != null)
                listado = AportesBLL.GetList(c => c.fechaAporte.Date <= hastaDatePicker.SelectedDate);

            var monto = listado.Sum(x => x.monto);
            var conteo = listado.Count();

            totalTextBox.Text = monto.ToString();
            conteoTextBox.Text = conteo.ToString();

            DatosDataDrid.ItemsSource = null;
            DatosDataDrid.ItemsSource = listado;
        }

    }
}

