using System.Windows.Forms;

namespace ImageScan.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            label1.Text = "¿Por qué desarrollaste este software?\n" +
                          "Porque tenía los huevos llenos de que se vean mal a la hora de imprimir alguna imágen de TP o Parciales que fueron sacadas en el cel.\n" +
                          "Así que desarrollé un programa que no hay que instalar nada, remueve algo de sombra y es rápido.\n" +
                          "Además estaba aburrido\n" +
                          "Es gratis, sin límite ni restricciones y de código abierto\n\n"+
                          "By: Dimitri Isakow";
        }
    }
}
