namespace Lists_LAB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AppShell());
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int width = 300;
            const int height = 350;

            window.Width = width;
            window.Height = height;

            return window;
        }
    }
}
