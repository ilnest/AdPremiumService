using FluentNHibernate.Mapping;
using Model.Entities;

namespace Repositories.DataMaps
{
	public class AdPremiumMap : ClassMap<AdPremium>
	{
		public AdPremiumMap()
		{
			Table("AdPremium");
			Id(x => x.AdId).GeneratedBy.Identity().Not.Nullable();
			Map(x => x.PremiumStart).Nullable();
			Map(x => x.PremiumEnd).Nullable();

			References(x => x.Location).Column("LocationsID").Unique().Cascade.None();
			References(x => x.Subcategory).Column("subcategoriesID").Unique().Cascade.None();
		}
	}
}
