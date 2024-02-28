using Hacker.News.AppService.IService;
using Hacker.News.AppService.Response.News;
using Hacker.News.Common.CustomException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using System.Net;

namespace Hacker.News.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {
        private readonly INewsAppService _newsAppService;
        public HackerNewsController(INewsAppService service)
        {
            _newsAppService = service;
        }

        [HttpGet("GetAllList")]
        public async Task<IActionResult> GetAllList()
        {
            int statusCode = (int)HttpStatusCode.OK;
            ResGetAllNewsList response = new ResGetAllNewsList();
            try
            {
                var list = await _newsAppService.GetAllList();
                response.Data = list;
            }
            catch(ErrorException ex)
            {
                statusCode = ex.StatusCode;
                response.Error = ex.ErrorInfo;
            }
            return new JsonResult(response) { StatusCode = statusCode };
        }

        [HttpPost("GetDetail")]
        public async Task<IActionResult> GetDetail([FromBody] int id)
        {
            int statusCode = (int)HttpStatusCode.OK;
            ResGetDetail response = new ResGetDetail();
            try
            {
                var objNews = await _newsAppService.GetDetailBy(id);
                response.Data = objNews;
            }
            catch (ErrorException ex)
            {
                statusCode = ex.StatusCode;
                response.Error = ex.ErrorInfo;
            }
            return new JsonResult(response) { StatusCode = statusCode };
        }

    }
}
