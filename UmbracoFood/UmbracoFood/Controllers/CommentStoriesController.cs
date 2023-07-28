using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;
using UmbracoFood.Data;
using UmbracoFood.Models;
using Microsoft.VisualBasic;
using Umbraco.Cms.Web.Common.Controllers;
namespace UmbracoFood.Controllers
{
    public class CommentStoriesController : UmbracoApiController
    {
        private readonly ICommentStories _iCommentStories;
        private readonly IContentService _contentService;

        public CommentStoriesController(ICommentStories iCommentStories, IContentService contentService)
        {
            _iCommentStories = iCommentStories;
            _contentService = contentService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        //[OpenApiOperation("Get data", "Get some data")]
        public ActionResult<IEnumerable<CommentStories>> GetComments()
        {
            var comments = _iCommentStories.GetAllComments();
            return comments.ToList();
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Comment(CommentStoriesModel model)
        {
            if (ModelState.IsValid)
            {
                // Thêm vào database
                //_iCommentStories.AddCommentStories(model);

                //Thêm vào Umbraco
                //var contentService = Services.ContentService;
                var parentContent = _contentService.GetById(new Guid("8efaaa3d-979b-483f-9248-ce8234effe32")).GetUdi();

                var newContent = _contentService.CreateContent("Comment", parentContent, "Comment");
                newContent.SetValue("cmtName", model.Name);
                newContent.SetValue("cmtEmail", model.Email);
                newContent.SetValue("cmtMessage", model.Message);
                newContent.SetValue("cmtDate", DateAndTime.Now);
                newContent.SetValue("cmtID", model.CmtId);
                newContent.Name = $"Comment - {model.Name}";
                _contentService.SaveAndPublish(newContent);

                //TempDataAttribute["CommentStoriesResult"] = "Thành Công";
                return Ok("Thành công !!!.");

                //return Json(new { success = true });



            }
            //TempData["CommentStoriesResult"] = "Thất Bại";
            return BadRequest("Thất bại !!!.");

            //return Json(new { success = false });

        }
    }
}
