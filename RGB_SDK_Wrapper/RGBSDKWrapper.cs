using RGB_SDK_Wrapper.controllers;
using System;
using System.Threading.Tasks;

namespace RGB_SDK_Wrapper
{
    public class RGBSDKWrapper
    {

        private readonly RazerSynapse _synapseController;
        private readonly CorsairCue _cueController;
        private readonly PhilipsHue _hueController;

        public RGBSDKWrapper()
        {
            _synapseController = new RazerSynapse();
            _cueController = new CorsairCue();
            _hueController = new PhilipsHue();
            Console.WriteLine("Initializing SDK's...");
            _synapseController.Initialize();
            _cueController.Initialize();
            _hueController.Initialize();
            Console.WriteLine("Initialization done");
        }

        public async Task<String> SetupHue(string ip, string appKey)
        {
            return await _hueController.Initialize(ip, appKey);
        }

        public void SetColor(RgbColor color)
        {
            Console.WriteLine("Setting color of devices to " + color.ToString());
            _cueController.SetColor(color);
            _synapseController.SetColor(color);
            _hueController.SetColor(color);
        }

        public void Shutdown()
        {
            _synapseController.Shutdown();
            _cueController.Shutdown();
            _hueController.Shutdown();
        }

    }
}
