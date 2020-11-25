using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuguAPI;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Models
{
	[ApiController]
	[Route("api/learningcenter")]
	public class LearningCenterController : Controller
	{
		private readonly string connection = "Data Source=67.192.16.33;Initial Catalog=Fugu_Dev;User Id = GracieUniversityv3_dev_v02; Password=wyhwrsK^FN5^_LU_; Persist Security Info=True; Connect Timeout = 300; MultipleActiveResultSets=true";

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult GetLearningCenters()
		{
			var learning = new DataStore(connection);

			var result = learning.GetLearningCenters();

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpGet("{lcNum}")]
		public IActionResult GetLearningCenterByLcNum(int lcNum)
		{
			var learning = new DataStore(connection);

			var result = learning.GetLearningCenterByLcNum(lcNum);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}
	}
}
