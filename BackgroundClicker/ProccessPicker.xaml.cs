using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace BackgroundClicker
{
	/// <summary>
	/// Логика взаимодействия для ProccessPicker.xaml
	/// </summary>
	public partial class ProccessPicker : UserControl
	{
		public ReadOnlyCollection<Process> Processes
		{
			get;
			private set;
		}

		public ProccessPicker()
		{
			InitializeComponent();
			Refresh();
		}

		public void Refresh()
		{
			Process[] allProcessess = Process.GetProcesses();
			Processes = new ReadOnlyCollection<Process>(allProcessess.Where(process => process.MainWindowHandle != IntPtr.Zero).ToList());
		}
	}
}
