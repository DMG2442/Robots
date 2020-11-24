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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Robot_acabat
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int filaTresor;
        int columnaTresor;
        DispatcherTimer temps = new DispatcherTimer();


        public MainWindow()
        {

            InitializeComponent();

            grdTauler.Children.Remove(imgTresor);

            ColocaTresor();

            temps.Start();
            temps.Tick += Temps_Tick;
            temps.Interval = TimeSpan.FromSeconds(1);

        }

        private void Temps_Tick(object sender, EventArgs e)
        {
            #region Moviment robot
            grdTauler.Children.Remove(imgRobot);
            grdTauler.Children.Remove(imgRobotAmbBarret);
            imgRobot.Visibility = Visibility.Visible;
            imgRobotAmbBarret.Visibility = Visibility.Visible;
            Random rnd = new Random();
            int filaRobot = rnd.Next(0, 4);
            int columnaRobot = rnd.Next(0, 4);
            int filaRobotBarret = rnd.Next(0, 4);
            int columnaRobotBarret = rnd.Next(0, 4);

            Grid.SetColumn(imgRobot, columnaRobot);
            Grid.SetRow(imgRobot, filaRobot);
            Grid.SetColumn(imgRobotAmbBarret, columnaRobotBarret);
            Grid.SetRow(imgRobotAmbBarret, filaRobotBarret);

            grdTauler.Children.Add(imgRobot);
            grdTauler.Children.Add(imgRobotAmbBarret);
            #endregion

            if (filaRobot == filaTresor && columnaRobot == columnaTresor)
            {
                temps.Stop();
                MessageBox.Show("El robot normal ha trobat el tresor!");
            }

            else if (filaRobotBarret == filaTresor && columnaRobotBarret == columnaTresor)
            {
                temps.Stop();
                MessageBox.Show("El robot amb barret ha trobat el tresor!");
            }

        }

        private void ColocaTresor()
        {
            imgTresor.Visibility = Visibility.Visible;
            Random rnd = new Random();
            filaTresor = rnd.Next(0, 4);
            columnaTresor = rnd.Next(0, 4);

            Grid.SetColumn(imgTresor, columnaTresor);
            Grid.SetRow(imgTresor, filaTresor);
            grdTauler.Children.Add(imgTresor);

        }
    }
}
