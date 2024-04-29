using System.Diagnostics;
using System.Windows;

namespace BackgroundClicker
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Clicker LeftClicker
		{
			get;
			set;
		} = new(true);

		public Clicker RightClicker
		{
			get;
			set;
		} = new(false);


		public MainWindow()
		{
			IntPtr hWnd = Process.GetProcessById(5952).MainWindowHandle;
			LeftClicker.HWnd = hWnd;

			InitializeComponent();
		}
	}
}