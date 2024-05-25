using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace BackgroundClicker
{
	public class Clicker
	{
		public const uint LMBDOWN = 0x201;
		public const uint RMBDOWN = 0x204;

		private readonly bool _isLeft;
		private readonly DispatcherTimer _timer;

		private uint ButtonCode => _isLeft ? LMBDOWN : RMBDOWN;

		public int ClickDelay
		{
			get
			{
				return (int)_timer.Interval.TotalMilliseconds;
			}

			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Click delay can not be negative");
				_timer.Interval = TimeSpan.FromMilliseconds(value);
			}
		}

		public Process SelectedProcess
		{
			get;
			set;
		}

		public bool IsEnabled
		{
			get => _timer.IsEnabled;
			set => _timer.IsEnabled = value;
		}

		public Clicker(bool isLeft)
		{
			_isLeft = isLeft;

			_timer = new DispatcherTimer();
			_timer.Tick += (sender, eventArgs) => Click();
		}

		private void Click()
		{
			if (SelectedProcess == null)
				return;
			PostMessage(SelectedProcess.MainWindowHandle, ButtonCode, IntPtr.Zero, IntPtr.Zero);
			PostMessage(SelectedProcess.MainWindowHandle, ButtonCode + 1, IntPtr.Zero, IntPtr.Zero);
		}

		[DllImport("user32.dll")]
		private static extern IntPtr PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
	}
}