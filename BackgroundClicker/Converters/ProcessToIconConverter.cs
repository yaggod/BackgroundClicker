using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BackgroundClicker.Converters
{
	class ProcessToIconConverter : IValueConverter
	{
		public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var process = (value as Process);
				if (process == null || targetType != typeof(ImageSource))
					throw new InvalidCastException();
				Icon? icon = Icon.ExtractAssociatedIcon(process.MainModule.FileName);
				ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
				icon.Handle,
				Int32Rect.Empty,
				BitmapSizeOptions.FromEmptyOptions());

				return imageSource;
			}
			catch(Exception)
			{
				return null;
			}

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}