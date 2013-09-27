using System;
using System.Collections.Generic;

namespace HierarchyManagement
{
	public class Node
	{
		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual Node Parent { get; set; }
		public virtual ISet<Node> Children { get; set; }

		public virtual ISet<Node> Ancestors { get; set; }
		public virtual ISet<Node> Descendants { get; set; }
	}

}
