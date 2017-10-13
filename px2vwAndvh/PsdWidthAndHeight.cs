using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace px2vwAndvh
{
    class PsdWidthAndHeight : WidthAndHeight
    {
        public PsdWidthAndHeight(float w, float h) :base(w,h)
        {

        }

        public PsdWidthAndHeight() { }

        public float WidthScale() {
            return 100 / this.Width;
        }

        public float HeightScale() {
            return 100 / this.Height;
        }
    }
}
