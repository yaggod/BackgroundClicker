using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackgroundClicker
{
    /// <summary>
    /// Логика взаимодействия для ClickerConfig.xaml
    /// </summary>
    public partial class ClickerConfig : UserControl
    {
        public static readonly DependencyProperty IsClickerEnabledProperty;
        public static readonly DependencyProperty LabelTextProperty;

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

		static ClickerConfig()
        {
			IsClickerEnabledProperty =
				DependencyProperty.RegisterAttached("IsClickerEnabled", typeof(bool), typeof(ClickerConfig));
			LabelTextProperty =
				DependencyProperty.RegisterAttached("LabelText", typeof(string), typeof(ClickerConfig));
		}



		public ClickerConfig()
        {

            InitializeComponent();
        }

	}
}
