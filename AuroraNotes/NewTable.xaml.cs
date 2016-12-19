using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess;

namespace AuroraNotes
{
	/// <summary>
	/// Interaction logic for NewTable.xaml
	/// </summary>
	public partial class NewTable : Window
	{

		public Table Table { get; set; }
		public NewTable()
		{
			Table = new Table();
			InitializeComponent();
		}
		private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			if (textBox != null)
			{
				e.CanExecute = !string.IsNullOrWhiteSpace(textBox.Text);
			}
		}

		private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			Table.Name = textBox.Text;
			DialogResult = true;
		}
	}
}
