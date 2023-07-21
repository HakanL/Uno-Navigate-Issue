using System.Collections;
using System.Net.Http.Headers;
using Microsoft.UI.Xaml.Data;

namespace UnoApp5.Presentation
{
    public partial class ListViewViewModel : ObservableObject
    {
        private INavigator _navigator;

        public ListViewViewModel(
            INavigator navigator)
        {
            _navigator = navigator;
        }

    }
}
