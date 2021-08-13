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

namespace Gerenciamento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        
        private void Click_Procedimentos(object sender, RoutedEventArgs e)
        {
            try { 

                Tela_Procedimentos Proc = new Tela_Procedimentos();

                Proc.ShowDialog();

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
