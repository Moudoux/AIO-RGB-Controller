using Corale.Colore.Core;
using RGB_SDK_Wrapper.interfaces;
using ColoreColor = Corale.Colore.Core.Color;

namespace RGB_SDK_Wrapper.controllers
{
    class RazerSynapse : IRgbController
    {
        public void Initialize()
        {
           
        }

        public void Shutdown()
        {
            
        }

        public void SetColor(RgbColor color)
        {
            ColoreColor coloreColor = new ColoreColor((byte) color.Red, (byte) color.Red, (byte) color.Blue);
            Chroma.Instance.SetAll(coloreColor);
        }
    }
}
