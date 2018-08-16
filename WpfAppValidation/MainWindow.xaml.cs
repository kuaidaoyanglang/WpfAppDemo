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

namespace WpfAppValidation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding binding= new Binding("Value") { Source=this.slider1};
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            RangValidationRule rvr = new RangValidationRule();
            rvr.ValidatesOnTargetUpdated = true;
            binding.NotifyOnValidationError = true;
            binding.ValidationRules.Add(rvr);
            this.txtBox.SetBinding(TextBox.TextProperty,binding);
            this.txtBox.AddHandler(Validation.ErrorEvent,new RoutedEventHandler(this.ValidationError));
        }

        void ValidationError(object sender,RoutedEventArgs args)
        {
            if (Validation.GetErrors(this.txtBox).Count>0)
            {
                this.txtBox.ToolTip = Validation.GetErrors(this.txtBox)[0].ErrorContent.ToString();
            }
        }
    }
}
