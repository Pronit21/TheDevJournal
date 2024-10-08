﻿using DevBlogs.Web.Data;
using DevBlogs.Web.Models.Domain;
using DevBlogs.Web.Models.ViewModels;
using DevBlogs.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevBlogs.Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminTagsController : Controller
	{
        private readonly ITagRepository tagRepository;

        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        public IActionResult Index()
		{
			return View("Main");
		}

		[Authorize]
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Add")]
		public async Task<IActionResult> Add(AddTagRequest addTagRequest)
		{
			//Mapping AddTagRequest to Tag domain model
			var tag = new Tag
			{
				Name = addTagRequest.Name,
				DisplayName = addTagRequest.DisplayName
			};

			await tagRepository.AddAsync(tag);
			return RedirectToAction("ShowList");
		}

		[HttpGet]
		[ActionName("ShowList")]
		public async Task<IActionResult> ShowList()
		{
			var tags = await tagRepository.GetAllAsync();
			return View(tags);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
            var tag = await tagRepository.GetAsync(id);

            if (tag != null)
			{
				var editTagRequest = new EditTagRequest
				{
					Id = tag.Id,
					Name = tag.Name,
					DisplayName = tag.DisplayName
				};

				return View(editTagRequest);

			}
			return View(null);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
		{
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

            if (updatedTag != null)
            {
				// Show success notification
				return RedirectToAction("ShowList");
            }
            

            return RedirectToAction("Edit", new { id = editTagRequest.Id });

        }

		[HttpPost]
		public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
		{
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag != null)
            {
                // Show success notification
                return RedirectToAction("ShowList");
            }

            // Show an error notification
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

		public IActionResult Main()
		{
			return View();
		}

	}
}
