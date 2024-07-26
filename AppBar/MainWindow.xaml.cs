using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace AppBar
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            MainFunction();
        }

        private void MainFunction()
        {
            // Position and update window
            double workAreaHeight = SystemParameters.WorkArea.Height;
            double workAreaWidth = SystemParameters.WorkArea.Width;
            this.Height = workAreaHeight;
            this.Left = workAreaWidth - this.Width;
            this.Top = SystemParameters.WorkArea.Top;

            // Update info
            var dpiScale = VisualTreeHelper.GetDpi(this);
            screensizeandpostion.Text = $"Screen Working Area:\n" +
                $"Width: {workAreaWidth:F2}\n" +
                $"Height: {workAreaHeight:F2}\n" +
                $"Top: {SystemParameters.WorkArea.Top:F2}\n" +
                $"Left: {SystemParameters.WorkArea.Left:F2}\n\n" +
                $"Window Position:\n\n" +
                $"Width: {this.ActualWidth:F2}\n\n" +
                $"Height: {this.ActualHeight:F2}\n" +
                $"Top: {this.Top:F2}\n" +
                $"Left: {this.Left:F2}\n\n\n\n" +
                $"DPI Scale: {dpiScale.DpiScaleX:F2}x{dpiScale.DpiScaleY:F2}";

            // Set up timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += (sender, e) => MainFunction();
            timer.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            timer.Stop();
            base.OnClosed(e);
        }
    }
}