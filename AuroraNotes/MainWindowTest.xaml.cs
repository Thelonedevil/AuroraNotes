using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
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
	/// Interaction logic for MainWindowTest.xaml
	/// </summary>
	public partial class MainWindowTest : Window
	{
		private NotesContext _context = new NotesContext();
		public MainWindowTest()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// tableViewSource.Source = [generic data source]
			_context.Tables.Include("Stacks.Books.Pages").Load();
			tableViewSource.Source = _context.Tables.Local;
		}
		private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
		{
			var item = treeView.SelectedItem;
			if (item is DataAccess.Page)
			{
				textBox.DataContext = item;
				//textBox.Text = ((DataAccess.Page)item).Content;
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
				var popup = new NewTable();
				Table table;
				if (popup.ShowDialog().GetValueOrDefault())
				{
					table = popup.Table;
				}
				else
				{
					return;
				}
				_context.Tables.Add(table);
			}
			else if (item is DataAccess.Stack)
			{
				var popup = new NewStack(((DataAccess.Stack) item).TableID);
				Stack stack;
				if (popup.ShowDialog().GetValueOrDefault())
				{
					stack = popup.Stack;
				}
				else
				{
					return;
				}
				((DataAccess.Stack) item).Table.Stacks.Add(stack);
				//_context.Stacks.Add(stack);

			}
			else if (item is DataAccess.Book)
			{
				var popup = new NewBook(((DataAccess.Book)item).StackID);
				Book book;
				if (popup.ShowDialog().GetValueOrDefault())
				{
					book = popup.Book;
				}
				else
				{
					return;
				}
				((DataAccess.Book)item).Stack.Books.Add(book);
			}

			_context.SaveChanges();

			treeView.Items.Refresh();
			treeView.UpdateLayout();
		}
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			base.OnClosing(e);
			this._context.Dispose();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			_context.SaveChanges();
		}
	}
}
