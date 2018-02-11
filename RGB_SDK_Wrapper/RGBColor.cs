using System;
using System.Drawing;

namespace RGB_SDK_Wrapper
{
    public class RgbColor
    {

        public int Red, Green, Blue;

        public RgbColor(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public RgbColor(Color color)
        {
            Red = color.R;
            Green = color.G;
            Blue = color.B;
        }

        public Color GetColor()
        {
            return Color.FromArgb(255, Red, Green, Blue);
        }

        public string ToHex()
        {
            return string.Format("{0:X2}{1:X2}{2:X2}", Red, Green, Blue);
        }

        override
        public String ToString()
        {
            return "{ Red: " + Red + ", Green: " + Green + ", Blue: " + Blue + ", Hex: " + ToHex() + " }";
        }

    }
}
