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

namespace WpfAppNewCommand
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

        private void New_CanExecute(Object sencer,CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.CanExecute=false;
            }
            else
            {
                e.CanExecute = true;
            }
            e.Handled = true;
        }

        private void New_Executed(Object sencer, ExecutedRoutedEventArgs e)
        {
            string name = txtName.Text;
            if (e.Parameter.ToString()=="Teacher")
            {
                this.listBoxItem.Items.Add($"New Teacher {name}:学而不厌，慧人不倦！");
            }
            else if (e.Parameter.ToString()=="Student")
            {
                this.listBoxItem.Items.Add($"New Student {name}:好好学习，天天向上！");
            }
            e.Handled = true;
        }
    }
}
