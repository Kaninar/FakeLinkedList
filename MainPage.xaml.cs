namespace Lists_LAB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BasicTaskButton_Clicked(object sender, EventArgs e)
        {
            this.Window.Height = 1000;
            this.Window.Width = 1000;
            await Navigation.PushAsync(new BasicTaskPage());
        }
        private async void NormalTaskButton_Clicked(object sender, EventArgs e)
        {
            this.Window.Height =1000;
            this.Window.Width = 1000;
            await Navigation.PushAsync(new NormalTaskPage());
        }
        private async void HardTaskButton_Clicked(object sender, EventArgs e)
        {
            this.Window.Height = 1000;
            this.Window.Width = 1000;
            await Navigation.PushAsync(new HardTaskPage());
        }
    }

}
