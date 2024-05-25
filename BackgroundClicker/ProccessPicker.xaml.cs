﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
