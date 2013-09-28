using FluentNHibernate.Mapping;

namespace HierarchyManagement.Mappings
{
	public class NodeMapping : ClassMap<Node>
	{
		public NodeMapping()
		{
			Id(n => n.Id).GeneratedBy.GuidComb();
			Map(n => n.Name).Length(50).Not.Nullable();
			References(n => n.Parent).Column("ParentId");//root has no parent
			HasManyToMany(n => n.Ancestors).Cascade.All().ParentKeyColumn("ParentId").ChildKeyColumn("ChildId").Table("NodeHierarchy").AsSet();
			HasMany(n => n.Children).Inverse().KeyColumn("ParentId").Cascade.All().AsSet();//one2many
			HasManyToMany(n => n.Descendants).Inverse().Cascade.All().ParentKeyColumn("ParentId").ChildKeyColumn("ChildId").Table("NodeHierarchy").AsSet();
		}
	}
}
