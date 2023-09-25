using System.Collections;
using System.Net.Http.Headers;
using Microsoft.UI.Xaml.Data;

namespace UnoApp5.Presentation
{
    public partial class ListViewViewScrollModel : ObservableObject
    {
        private INavigator _navigator;

        public ListViewViewScrollModel(
            INavigator navigator)
        {
            _navigator = navigator;
        }

    }
}
