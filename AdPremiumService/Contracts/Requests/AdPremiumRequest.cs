using System;

namespace Contracts.Requests
{
	public class AdPremiumRequest
	{
		public int LocationId { get; set; }
		public int SubcategoryId { get; set; }
		public DateTime? PremiumStart { get; set; }
		public DateTime? PremiumEnd { get; set; }

		//TODO: Equals and GetHashCode :))

	}
}
