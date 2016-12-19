using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class NotesContext : DbContext
	{
		public DbSet<Table> Tables { get; set; }
		public DbSet<Stack> Stacks { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Page> Pages { get; set; }
	}
}
