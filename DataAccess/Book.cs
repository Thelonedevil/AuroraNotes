using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class Book
	{
		public int BookID { get; set; }
		public string Name { get; set; }
		public int StackID { get; set; }
		public virtual Stack Stack { get; set; }

		public virtual List<Page> Pages { get; set; }
	}
}
