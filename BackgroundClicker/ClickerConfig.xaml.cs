using System.Windows;
using System.Windows.Controls;

namespace BackgroundClicker
{
	/// <summary>
	/// Логика взаимодействия для ClickerConfig.xaml
	/// </summary>
	public partial class ClickerConfig : UserControl
	{
		public static readonly DependencyProperty IsClickerEnabledProperty;
		public static readonly DependencyProperty LabelTextProperty;
		public static readonly DependencyProperty DelayProperty;

		public bool IsClickerEnabled
		{
			get => (bool)GetValue(IsClickerEnabledProperty);
			set => SetValue(IsClickerEnabledProperty, value);
		}

		public string LabelText
		{
			get => (string)GetValue(LabelTextProperty);
			set => SetValue(LabelTextProperty, value);
		}

		public int Delay
		{
			get => (int)GetValue(DelayProperty);
			set => SetValue(DelayProperty, value);
		}

		static ClickerConfig()
		{
			IsClickerEnabledProperty =
				DependencyProperty.Register("IsClickerEnabled", typeof(bool), typeof(ClickerConfig));
			LabelTextProperty =
				DependencyProperty.Register("LabelText", typeof(string), typeof(ClickerConfig));
			DelayProperty =
				DependencyProperty.Register("Delay", typeof(int), typeof(ClickerConfig));
		}



		public ClickerConfig()
		{
			InitializeComponent();
		}

	}
}
