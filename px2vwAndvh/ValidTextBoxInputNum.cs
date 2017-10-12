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

namespace px2vwAndvh {
    class ValidTextBoxInputNum {
        private string prevVal = "";
        private TextBox textBox;

        public ValidTextBoxInputNum(TextBox textBox) {
            this.textBox = textBox;
        }

        public void Validate() {
            var text = textBox.Text;
            if( Common.IsNumeric(text) ) {
                prevVal = text;
            } else {
                textBox.Text = prevVal;
                textBox.Select(prevVal.Length, 0);
            }
        }

        private static Dictionary<TextBox, ValidTextBoxInputNum> dic = new Dictionary<TextBox, ValidTextBoxInputNum>();

        public static ValidTextBoxInputNum Create( TextBox textBox ) {
            if( dic.ContainsKey(textBox)) {
                return dic [textBox];
            }
            var instance = new ValidTextBoxInputNum(textBox);
            dic [textBox] = instance;
            return instance;
        }
    }
}
