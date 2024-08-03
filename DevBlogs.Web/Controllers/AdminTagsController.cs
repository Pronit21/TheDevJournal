using System.ComponentModel;
using DevBlogs.Web.Data;
using DevBlogs.Web.Models.Domain;
using DevBlogs.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevBlogs.Web.Controllers
{
	public class AdminTagsController : Controller
	{
		private readonly DevBlogDbContext _devBlogDbContext;

		public AdminTagsController(DevBlogDbContext devBlogDbContext)
		{
			_devBlogDbContext = devBlogDbContext;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Add")]
		public IActionResult SubmitTag(AddTagRequest addTagRequest)
		{
			//Mapping AddTagRequest to Tag domain model
			var tag = new Tag
			{
				Name = addTagRequest.Name,
				DisplayName = addTagRequest.DisplayName
			};

			_devBlogDbContext.Add(tag);
			_devBlogDbContext.SaveChanges();

			return RedirectToAction("ShowList");
		}

		[HttpGet]
		[ActionName("ShowList")]
		public IActionResult ShowList()
		{
			var tags = _devBlogDbContext.Tags.ToList();
			return View(tags);
		}

		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			var tag = _devBlogDbContext.Tags.FirstOrDefault(t => t.Id == id);
			return View();
		}
	}
}
