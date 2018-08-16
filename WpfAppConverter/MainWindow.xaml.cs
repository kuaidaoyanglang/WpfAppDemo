using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfAppConverter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> lstPlane = new List<Plane>() {
                new Plane(){ Category= Category.Bomber,Name="B-1",State=State.Unknown},
                new Plane(){ Category=Category.Bomber,Name="B-2",State=State.Available},
                new Plane(){Category=Category.Fighter,Name="F-22",State=State.Available},
                new Plane(){Category=Category.Fighter,Name="su-47",State=State.Unknown},
                new Plane(){Category=Category.Bomber,Name="B-52",State=State.Unknown},
                new Plane(){Category=Category.Fighter,Name="J-10",State=State.Unknown}
            };
            this.listBoxPlane.ItemsSource = lstPlane;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Plane item in listBoxPlane.Items)
            {
                stringBuilder.AppendLine($"Category={item.Category},Name={item.Name},State={item.State}");
            }

            File.WriteAllText(@"D:\ListBoxPlane.txt",stringBuilder.ToString());
        }
    }
}
