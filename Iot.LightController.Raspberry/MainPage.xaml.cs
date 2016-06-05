using Windows.UI.Xaml.Controls;
using Iot.LightController.Messaging;
using Iot.LightController.Raspberry.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Iot.LightController.Raspberry
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ReceiveBroker _listerner;
        private readonly LightSwitcher _lightSwitcher;

        public MainPage()
        {
            InitializeComponent();


            _lightSwitcher = new LightSwitcher();
            _lightSwitcher.Initialize();

            _listerner = new ReceiveBroker();
            _listerner.OnReceivedMessage += _listerner_OnReceivedMessage;
            _listerner.Initialize();
            _listerner.StartListening();
        }

        private void _listerner_OnReceivedMessage(string message)
        {
            var lightNumber = int.Parse(message);
            _lightSwitcher.SwitchLight(lightNumber);
        }
    }
}
