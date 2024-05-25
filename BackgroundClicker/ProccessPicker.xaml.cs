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

		private readonly ObservableCollection<Process> _processes = new();
		public ReadOnlyObservableCollection<Process> Processes
		{
			get;
		}

		public ProcessPicker()
		{
			InitializeComponent();
			Processes = new(_processes);
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
			var validProcesses = allProcessess.Where(process => process.MainWindowHandle != IntPtr.Zero);
			_processes.Clear();
			foreach(Process process in validProcesses)
				_processes.Add(process);
		}


		private void Refresh(object sender, RoutedEventArgs e)
		{
			Refresh();
        }
    }
}
