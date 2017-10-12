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


namespace px2vwAndvh
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


        private PsdWidthAndHeight getPsdWidthAndHeight()
        {
            var psdWidth = PsdWidth.Text;
            var psdHeight = PsdHeight.Text;
            if (Common.IsNumeric(psdWidth) && Common.IsNumeric(psdHeight))
            {
                return new PsdWidthAndHeight(float.Parse(psdWidth), float.Parse(psdHeight));
            }
            else
            {
                return new PsdWidthAndHeight();
            }
        }

        private void PsdInputLoseFocus()
        {
            var wh = getPsdWidthAndHeight();
            if (wh.IsValid)
            {
                Config.SavePsdWidthAndHeight(wh);
            }
        }

        private void PsdWidth_LostFocus(object sender, RoutedEventArgs e)
        {

            PsdInputLoseFocus();
        }

        private void PsdHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            PsdInputLoseFocus();
        }

        private void PsdWidth_KeyUp(object sender, KeyEventArgs e)
        {
            ValidTextBoxInputNum.Create(sender).Validate();
        }

        private void PsdHeight_KeyUp(object sender, KeyEventArgs e)
        {
            ValidTextBoxInputNum.Create(sender).Validate();
        }
    }
}
