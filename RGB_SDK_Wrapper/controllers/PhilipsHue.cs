using RGB_SDK_Wrapper.interfaces;
using Q42.HueApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.Interfaces;
using Q42.HueApi.ColorConverters.Original;

namespace RGB_SDK_Wrapper.controllers
{
    class PhilipsHue : IRgbController
    {

        private ILocalHueClient _client;
        private List<LightState> _originalStates = new List<LightState>();

        public async Task<string> Initialize(string hueIp, string appKey)
        {
            Console.WriteLine("Initializing Philips Hue SDK...");
            _client = new LocalHueClient(hueIp);
            if (appKey.Equals(""))
            {
                appKey = await _client.RegisterAsync("rgb_sdk", "computer_controller");
            }
            else
            {
                _client.Initialize(appKey);
            }
            Console.WriteLine("Initialized Philips Hue SDK");
            IEnumerable<Light> lights = await _client.GetLightsAsync();
            foreach (Light light in lights)
            {
                LightCommand cmd = new LightCommand();
                cmd.On = light.State.On;
                cmd.SetColor(light.ToRGBColor());
                _originalStates.Add(new LightState(cmd, light.Id));
            }
            return appKey;
        }

        public void SetColor(RgbColor color)
        {
            LightCommand command = new LightCommand();
            command.SetColor(new RGBColor(color.ToHex()));
            _client.SendCommandAsync(command);
        }

        public void Initialize()
        {

        }

        public async void Shutdown()
        {
            foreach (LightState light in _originalStates)
            {
                await _client.SendCommandAsync(light._command, new List<string> {light._lightNumber});
            }   
        }

        class LightState
        {

            public LightCommand _command;
            public string _lightNumber;

            public LightState(LightCommand cmd, string id)
            {
                _command = cmd;
                _lightNumber = id;
            }

        }

    }
}
