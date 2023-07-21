namespace UnoApp5.Presentation
{
    public partial class MainViewModel : ObservableObject
    {
        private INavigator _navigator;

        [ObservableProperty]
        private string? name;

        public MainViewModel(
            INavigator navigator)
        {
            _navigator = navigator;
            Title = "Main";
            GoToSecond = new AsyncRelayCommand(GoToSecondView);
            DisplayOverlay = new AsyncRelayCommand(DisplayOverlayView);
            GoToGroupedListViewDemo = new AsyncRelayCommand(GoToGroupedListView);
            GoToListViewDemo = new AsyncRelayCommand(GoToListView);
        }
        public string? Title { get; }

        public ICommand GoToSecond { get; }

        public ICommand DisplayOverlay { get; }

        public ICommand GoToGroupedListViewDemo { get; }

        public ICommand GoToListViewDemo { get; }


        private async Task GoToSecondView()
        {
            await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
        }

        private async Task GoToGroupedListView()
        {
            await _navigator.NavigateViewModelAsync<GroupedListViewViewModel>(this, data: new Entity(Name!));
        }

        private async Task GoToListView()
        {
            await _navigator.NavigateViewModelAsync<ListViewViewModel>(this);
        }

        private async Task DisplayOverlayView()
        {
            var popupCancellationTokenSource = new CancellationTokenSource(2_000);

            var result = await _navigator.NavigateViewForResultAsync<OverlayPage, bool>(this, qualifier: Qualifiers.Dialog, cancellation: popupCancellationTokenSource.Token);
        }
    }
}
