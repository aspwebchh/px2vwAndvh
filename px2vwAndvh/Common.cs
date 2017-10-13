using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace px2vwAndvh {
    class Common {

        public static bool IsNumeric( string text ) {
            float val;
            if(float.TryParse(text, out val)) {
                return true;
            } else {
                return false;
            }

        }
    }
}
