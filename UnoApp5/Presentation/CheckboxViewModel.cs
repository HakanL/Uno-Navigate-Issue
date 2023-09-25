using System.Net.Http.Headers;

namespace UnoApp5.Presentation
{
    public partial class CheckboxViewModel : ObservableObject
    {
        private INavigator _navigator;

        public CheckboxViewModel(
            INavigator navigator)
        {
            _navigator = navigator;
        }
    }
}