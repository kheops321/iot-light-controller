using System;
using Iot.LightController.Messaging;
using Xamarin.Forms;

namespace Iot.LightController.MobileApp
{
    public partial class MainPage : ContentPage
    {
        private readonly SendBroker _messageBroker;

        public MainPage()
        {
            InitializeComponent();

            _messageBroker = new SendBroker();
            _messageBroker.Initialize();

            Light1.Clicked += Light1_Clicked;
            Light2.Clicked += Light2_Clicked;
            Light3.Clicked += Light3_Clicked;
            Light4.Clicked += Light4_Clicked;
        }

        private void Light4_Clicked(object sender, EventArgs e)
        {
            _messageBroker.SendMessage("4");
        }

        private void Light3_Clicked(object sender, EventArgs e)
        {
            _messageBroker.SendMessage("3");
        }

        private void Light2_Clicked(object sender, EventArgs e)
        {
            _messageBroker.SendMessage("2");
        }

        private void Light1_Clicked(object sender, EventArgs e)
        {
            _messageBroker.SendMessage("1");
        }
    }
}
