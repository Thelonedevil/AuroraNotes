using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class Page
	{
		public int PageID { get; set; }
		public int Order { get; set; }
		public string Content { get; set; }
		public string Title { get; set; }
		public int BookID { get; set; }
		public virtual Book Book { get; set; }
	}
}