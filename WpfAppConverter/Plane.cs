using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfAppConverter
{
    public class Plane
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
    }

    public enum Category
    {
        Bomber,
        Fighter
    }

    public enum State
    {
        Available,
        Locked,
        Unknown
    }

    public class CategoryToSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Category category = (Category)value;
            switch (category)
            {
                case Category.Bomber:
                    return @"\Icons\emoji-1.png";
                case Category.Fighter:
                    return @"\Icons\emoji-16.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StateToNullBoolContverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            State state = (State)value;
            switch (state)
            {
                case State.Locked:
                    return false;
                case State.Available:
                    return true;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Boolean? flag = (Boolean)value;
            switch (flag)
            {
                case true:
                    return State.Available;
                case false:
                    return State.Locked;
                default:
                    return State.Unknown;
            }
        }
    }
}
