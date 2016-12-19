using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess;

namespace AuroraNotes
{
	/// <summary>
	/// Interaction logic for NewBook.xaml
	/// </summary>
	public partial class NewPage : Window
	{

		public NewPage(int BookID) : this()
		{
			Page = BookID > 0 ? new Page {BookID = BookID} : new Page();
		}

		public Page Page { get; set; }
		public NewPage()
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
			Page.Title = textBox.Text;
			DialogResult = true;
		}
	}
}
