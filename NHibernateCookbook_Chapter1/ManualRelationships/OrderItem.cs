using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualRelationships
{
	public class OrderItem
	{
		public Guid Id { get; protected set; }
		public Order Order { get; protected set; }

		public virtual void SetOrder(Order newOrder)
		{
			var prevOrder = Order;

			if (newOrder == prevOrder)
				return;

			Order = newOrder;

			if (prevOrder != null)
				prevOrder.RemoveItem(this);

			if (newOrder != null)
				newOrder.AddItem(this);

		}
	}
}
