using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Devices.Gpio;

namespace Iot.LightController.Raspberry.Core
{
    public class LightSwitcher
    {
        private IEnumerable<KeyValuePair<int, GpioPin>>  _lights;

        public void Initialize()
        {
            _lights = new List<KeyValuePair<int, GpioPin>>
            {
                InitializePin(12), // Gpio numéro 12 pour controller la première lampe
                InitializePin(16), // Gpio numéro 16 pour controller la deuxième lampe
                InitializePin(20), // Gpio numéro 20 pour controller la troisième lampe
                InitializePin(21) // Gpio numéro 21 pour controller la quatrième lampe
            };
        }

        /// <summary>
        /// Inverser le statut d'une lampe
        /// </summary>
        /// <param name="lightIndicator">numéro de la lampe de 1 à 4</param>
        public void SwitchLight(int lightIndicator)
        {
            if(lightIndicator < 1 || lightIndicator > _lights.Count())
                throw new ArgumentException($"Please provide an indicator between 1 and {_lights.Count()}");

            var lightPinController = GetLightControllerByIndex(lightIndicator - 1);

            lightPinController.Write(
                lightPinController.Read() == GpioPinValue.High ? 
                    GpioPinValue.Low : 
                    GpioPinValue.High);
        }
        
        private KeyValuePair<int, GpioPin> InitializePin(int pinNumber)
        {
            var pin = GpioController.GetDefault().OpenPin(pinNumber);
            pin.SetDriveMode(GpioPinDriveMode.Output);
            pin.Write(GpioPinValue.Low);
            return new KeyValuePair<int, GpioPin>(pinNumber, pin);
        }

        private GpioPin GetLightControllerByIndex(int lightIndex)
        {
            return _lights.ElementAt(lightIndex).Value;
        }
    }
}
