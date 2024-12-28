using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace CP1101.Util
{
    public class UIUtil
    {
        public static StackPanel concatDuoElements(UIElement e1, UIElement e2)
        {
            StackPanel stack = new StackPanel();
            stack.HorizontalAlignment = HorizontalAlignment.Center;
            stack.VerticalAlignment = VerticalAlignment.Center;
            stack.Orientation = Orientation.Horizontal;

            stack.Children.Add(e1);
            stack.Children.Add(e2);

            return stack;
        }
    }
}
