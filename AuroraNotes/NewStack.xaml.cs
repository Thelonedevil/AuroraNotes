using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess;

namespace AuroraNotes
{
	/// <summary>
	/// Interaction logic for NewStack.xaml
	/// </summary>
	public partial class NewStack : Window
	{
		public NewStack(int TableID) : this()
		{
			Stack = new Stack {TableID = TableID};
		}
		public Stack Stack { get; set; }
		public NewStack()
		{
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
			Stack.Name = textBox.Text;
			DialogResult = true;
		}
	}
}
