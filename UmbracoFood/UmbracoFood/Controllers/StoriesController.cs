using Examine;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Trees;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoFood.Data;
using UmbracoFood.Models;
using static Lucene.Net.Documents.Field;

namespace UmbracoFood.Controllers
{
    public class StoriesController : UmbracoApiController
    {
        private readonly IContentService _contentService;

        public StoriesController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult UpViewCount(int nodeId)
        {
            var content = _contentService.GetById(nodeId);
            if (content != null)
            {
                // Lấy giá trị view hiện tại 
                int currentViewCount = content.GetValue<int>("storyView");

                // Tăng view
                currentViewCount++;

                // Lưu giá trị mới
                content.SetValue("storyView", currentViewCount);

                // Lưu và xuất bản nội dung
                _contentService.SaveAndPublish(content);
                return Ok("Thành Công !!!");
            }
            return Ok("Thất Bại !!!");
        }
    }
}
