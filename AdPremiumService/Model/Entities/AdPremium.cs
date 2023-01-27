using System;

namespace Model.Entities
{
	public class AdPremium
	{
		public virtual int AdId { get; set; }
		public virtual DateTime? PremiumStart { get; set; }
		public virtual DateTime? PremiumEnd { get; set; }

		public virtual Location Location { get; set; }
		public virtual Subcategory Subcategory { get; set; }

		//TODO: Equals and GetHashCode :))
	}
}