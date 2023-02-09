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
using System.IO;
using Microsoft.Win32;

namespace WpfApp4
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

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _ofd = new OpenFileDialog(); 
            if (_ofd.ShowDialog() == false)
            {
                return;
            }
            String? olvasotttSor;
            StreamReader fajlolvaso = new StreamReader(_ofd.FileName);
            while (!fajlolvaso.EndOfStream)
            {
                olvasotttSor = fajlolvaso.ReadLine();
                if (olvasotttSor != "")
                {
                    lbForras.Items.Add(olvasotttSor);
                }
            }
            
            fajlolvaso.Close();
        }

        private void btnKivalogat_Click(object sender, RoutedEventArgs e)
        {

            lbModositott.Items.Clear();
            foreach (Object item in lbForras.Items)
            {
                if (chkNincsKülönbseg.IsChecked == true)
                {
                    if (item.ToString().ToLower().Contains(tbKivalaszt.Text.ToLower()))
                    {
                        lbModositott.Items.Add(item.ToString());
                    }
                }

                else
                {
                    if (item.ToString().Contains(tbKivalaszt.Text))
                    {
                        lbModositott.Items.Add(item.ToString());
                    }
                }
               
            }
        }

        private void btnElment_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog _sfd = new SaveFileDialog();

            if (_sfd.ShowDialog() == true)
            {
                StreamWriter fajlIro = new StreamWriter(_sfd.FileName);
                foreach (Object item in lbModositott.Items)
                {
                    fajlIro.WriteLine(item.ToString());
                }
                fajlIro.Close();
            }
        }
    }
}
