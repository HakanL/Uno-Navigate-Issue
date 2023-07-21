namespace UnoApp5.Presentation
{
    public sealed partial class ListViewPage : Page
    {
        public ListViewPage()
        {
            this.InitializeComponent();

            ListContainer.ItemsSource = new List<(string Text, string Value)>()
            {
                ("Hej", "asdfasd"),
                ("sadfkljsdakl", "asdfasdXXXX")
            };
        }

        private void ListView_Clicked(object sender, ItemClickEventArgs e)
        {
            var listViewItem = ListContainer.ContainerFromItem(e.ClickedItem);

            TestFlyout.Items.Clear();

            var timezones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var zone in timezones)
            {
                TestFlyout.Items.Add(new MenuFlyoutItem
                {
                    Text = zone.DisplayName
                });
            }

            TestFlyout.ShowAt(listViewItem as FrameworkElement);
        }
    }
}
