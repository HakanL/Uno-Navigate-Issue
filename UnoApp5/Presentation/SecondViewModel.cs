using System.Net.Http.Headers;

namespace UnoApp5.Presentation
{
    public partial class SecondViewModel : ObservableObject
    {
        private INavigator _navigator;

        [ObservableProperty]
        private string? name;

        public Entity Entity { get; set; }

        public SecondViewModel(
            INavigator navigator,
            Entity entity)
        {
            Entity = entity;
            _navigator = navigator;
            GoToSecond = new AsyncRelayCommand(GoToSecondView);
        }

        public ICommand GoToSecond { get; }

        private async Task GoToSecondView()
        {
            await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
        }
    }
}