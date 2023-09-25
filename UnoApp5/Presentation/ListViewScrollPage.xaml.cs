namespace UnoApp5.Presentation
{
    public sealed partial class ListViewScrollPage : Page
    {
        private List<(string Text, string Value)> items = new ();

        public ListViewScrollPage()
        {
            this.InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                items.Add(($"Key {i}", $"Value {i}"));
            }
            ListContainer.ItemsSource = this.items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListContainer.ScrollIntoView(this.items.Last());
        }
    }
}
