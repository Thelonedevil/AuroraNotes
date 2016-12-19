using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace AuroraNotes
{
	class MainViewModel
	{
		public IEnumerable<Table> Tables { get; set; }
		public MainViewModel()
		{
			using (var db = new NotesContext())
			{
				db.Tables.Include("Stacks.Books.Pages").Load();
				Tables = db.Tables.Local;
			}
		}
	}
}
