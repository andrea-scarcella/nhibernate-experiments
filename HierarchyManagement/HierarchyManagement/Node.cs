using System;
//using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace HierarchyManagement
{
	public class Node
	{
		private ISet<Node> _Ancestors = new HashedSet<Node>();
		private ISet<Node> _Children = new HashedSet<Node>();
		private ISet<Node> _Descendants = new HashedSet<Node>();
		//public Node()
		//{
		//	//Children = new HashedSet<Node>();
		//	//Ancestors=new HashedSet<Node>();
		//	//Descendants=new HashedSet<Node>();
		//}
		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual Node Parent { get; set; }
		public virtual ISet<Node> Children { get { return _Children; } }

		public virtual ISet<Node> Ancestors
		{
			get { return _Ancestors; }
		}
		public virtual ISet<Node> Descendants { get { return _Descendants; } }
		public virtual Node AddChild(Node childNode)
		{
			Children.Add(childNode);
			childNode.Parent = this;
			childNode.Ancestors.AddAll(this.Ancestors);
			childNode.Ancestors.Add(this);
			this.Descendants.Add(childNode);
			return childNode;
		}

	}

}
