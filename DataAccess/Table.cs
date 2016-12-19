using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Table 
    {
		public int TableID { get; set; }
		public string Name { get; set; }

		public virtual List<Stack> Stacks { get; set; }
    }
}
