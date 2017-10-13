using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private Object textBox;

        public ValidTextBoxInputNum(Object textBox) {
            this.textBox = textBox;
        }

        public void Validate() {
            var textBox = this.textBox as TextBox;
            var text = textBox.Text;
            if( Common.IsNumeric(text) || string.IsNullOrEmpty(text) ) {
                prevVal = text;
            } else {
                textBox.Text = prevVal;
                textBox.Select(prevVal.Length, 0);
            }
        }

        private static Dictionary<Object, ValidTextBoxInputNum> dic = new Dictionary<Object, ValidTextBoxInputNum>();

        public static ValidTextBoxInputNum Create( Object textBox ) {
            if( dic.ContainsKey(textBox)) {
                return dic [textBox];
            }
            var instance = new ValidTextBoxInputNum(textBox);
            dic [textBox] = instance;
            return instance;
        }
    }
}
