using CUE.NET;
using CUE.NET.Devices.Keyboard;
using RGB_SDK_Wrapper.interfaces;
using System;
using CUE.NET.Brushes;
using CUE.NET.Devices.Generic.Enums;

namespace RGB_SDK_Wrapper.controllers
{
    class CorsairCue : IRgbController
    {

        private CorsairKeyboard _keyboard;

        public void Initialize()
        {
            if (CueSDK.IsSDKAvailable())
            {
                CueSDK.Initialize();
                Console.WriteLine("Initialized Corsair CUE with " + CueSDK.LoadedArchitecture + "-SDK");
                _keyboard = CueSDK.KeyboardSDK;
                CueSDK.UpdateMode = UpdateMode.Manual;
            } else
            {
                Console.WriteLine("Failed to initialize Corsair CUE SDK, is it installed?");
            }
        }

        public void Shutdown()
        {
            
        }

        public void SetColor(RgbColor color)
        {
            // Keyboard
            CueSDK.KeyboardSDK.Brush = (SolidColorBrush) color.GetColor();
            foreach (var corsairLed in _keyboard.GetLeds())
            {
                corsairLed.Color = color.GetColor();
            }
            _keyboard.Update();
            // TODO: Mouse, Mousepad, and headset
        }

    }
}
