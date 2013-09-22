using System;

namespace ComponentExamples
{
	public class Customer
	{
		public virtual Guid Id { get; protected set; }
		public virtual string Name { get; set; }
		public virtual Address BillingAddress { get; set; }
		public virtual Address ShippingAddress { get; set; }
	}
}
