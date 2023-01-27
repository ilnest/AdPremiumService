using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Contracts.Requests;
using Contracts.Responses;
using System;
using System.Collections.Generic;

namespace AdPremiumService.Controllers
{
	[EnableCors]
	[ApiController]
	[Route("api/v1/AdPremium")]
	public class AdPremiumController : Controller
	{
		private readonly IAdPremiumManager _adPremiumManager;

		public AdPremiumController(IAdPremiumManager adPremiumManager)
		{
			_adPremiumManager = adPremiumManager ?? throw new ArgumentNullException(nameof(adPremiumManager));
		}

		[HttpPost("add")]
		[ProducesResponseType(typeof(AdPremiumResponse), StatusCodes.Status200OK)]
		public IActionResult SaveAdPremium([FromBody] AdPremiumRequest adPremiumRequest)
		{
			return Ok(_adPremiumManager.AddNewAdPremium(adPremiumRequest));
		}

		[HttpGet("get")]
		[ProducesResponseType(typeof(List<AdPremiumResponse>), StatusCodes.Status200OK)]
		public IActionResult GetAllAdPremium()
		{
			return Ok(_adPremiumManager.GetAllAdPremium());
		}
	}
}
