using Contracts.DTO;
using System;

namespace Contracts.Responses
{
	public class AdPremiumResponse
	{
		public int AdId { get; set; }
		public DateTime? PremiumStart { get; set; }
		public DateTime? PremiumEnd { get; set; }

		public LocationDto Location { get; set; }
		public SubcategoryDTO Subcategory { get; set; }

		//TODO: Equals and GetHashCode :))

	}
}
