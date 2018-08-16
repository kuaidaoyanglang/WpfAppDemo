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

namespace WpfAppMultiBing
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SetBinding();
        }

        private void SetBinding()
        {
            Binding binding1 = new Binding("Text") {Source=txt1 };
            Binding binding2 = new Binding("Text") { Source=txt2};
            Binding binding3 = new Binding("Text") { Source=txt3};
            Binding binding4 = new Binding("Text") { Source = txt4 };

            MultiBinding multi = new MultiBinding() { Mode=BindingMode.OneWay};

            multi.Bindings.Add(binding1);
            multi.Bindings.Add(binding2);
            multi.Bindings.Add(binding3);
            multi.Bindings.Add(binding4);

            multi.Converter = new LogonMultiBindingConverter();

            this.btn1.SetBinding(Button.IsEnabledProperty,multi);
        }
    }
}
