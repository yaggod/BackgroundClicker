using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace BackgroundClicker
{
	/// <summary>
	/// Логика взаимодействия для ProccessPicker.xaml
	/// </summary>
	public partial class ProcessPicker : UserControl
	{
		public static readonly DependencyProperty CurrentProcessProperty;

		public Process CurrentProcess
		{
			get => (Process)GetValue(CurrentProcessProperty);
			set => SetValue(CurrentProcessProperty, value);
		}

		public ReadOnlyCollection<Process> Processes
		{
			get;
			private set;
		}

		public ProcessPicker()
		{
			InitializeComponent();
			Refresh();
		}

		static ProcessPicker()
		{
			CurrentProcessProperty =
			DependencyProperty.Register("CurrentProcess", typeof(Process), typeof(ProcessPicker));
		}

		public void Refresh()
		{
			Process[] allProcessess = Process.GetProcesses();
			Processes = new ReadOnlyCollection<Process>(allProcessess.Where(process => process.MainWindowHandle != IntPtr.Zero).ToList());
		}

		private void Refresh(object sender, RoutedEventArgs e)
		{
			Refresh();
        }
    }
}
