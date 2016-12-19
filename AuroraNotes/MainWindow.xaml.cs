using System;
using System.Collections.Generic;
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
using DataAccess;

namespace AuroraNotes
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private NotesContext _context = new NotesContext();
		public MainWindow()
		{
			InitializeComponent();
		}

		private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			
		}

		private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
		{
			var item = sender as TreeViewItem;
			if (item?.DataContext is DataAccess.Page)
			{
				textBox.Text = ((DataAccess.Page) item.DataContext).Content;
			}
		}
		private void CommonCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			var item = treeView.SelectedItem;
			if (item is DataAccess.Table)
			{
				var popup = new NewStack(((DataAccess.Table)item).TableID);
				Stack stack;
				if (popup.ShowDialog().GetValueOrDefault())
				{
					stack = popup.Stack;
				}
				else
				{
					return;
				}
				using (var db = new NotesContext())
				{
					db.Stacks.Add(stack);
					db.SaveChanges();
				}
				treeView.Items.Refresh();
				treeView.UpdateLayout();
			}
		}
	}
}
