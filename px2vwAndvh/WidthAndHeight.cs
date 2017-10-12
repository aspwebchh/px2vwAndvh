using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace px2vwAndvh
{
    class WidthAndHeight
    {
        public WidthAndHeight(float w, float h)
        {
            this.Width = w;
            this.Height = h;
        }

        public WidthAndHeight() { }

        public float Width { get; set; }
        public float Height { get; set; }

        public bool IsValid {
            get {
                return Width != 0 && Height != 0;
            }
        }

        public string Format()
        {
            return Width.ToString() + "," + Height.ToString();
        }
    }
}
