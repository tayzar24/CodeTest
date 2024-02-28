using Hacker.News.AppService.Dto;
using Hacker.News.AppService.IService;
using Hacker.News.AppService.Response.News;
using Hacker.News.AppService.Util;
using Hacker.News.Common.CommonConstant;
using Hacker.News.Common.CustomException;
using Hacker.News.Common.Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hacker.News.AppService.Service
{
    public class NewsAppService : INewsAppService
    {
        private readonly LogService _log;
        public NewsAppService(LogService log)
        {
            _log = log;
        }

        public async Task<List<NewsDto>> GetAllList()
        {
            var list = new List<NewsDto>();
            try
            {
                var lstBestStories = await HttpClientCaller.GetMethod(CommonConstants.URL_BEST_STORIES);
                int[] intArray = JsonConvert.DeserializeObject<int[]>(lstBestStories);

                foreach(var item in intArray)
                {
                    string response = await HttpClientCaller.GetMethod(string.Format(CommonConstants.URL_BEST_STORIES_DETAIL, item));

                    var objResponse = JsonConvert.DeserializeObject<DetailDto>(response);

                    list.Add(new NewsDto
                    {
                        PostedBy = objResponse.by,
                        Score = Convert.ToInt32(objResponse.score),
                        Time = objResponse.time,
                        URL = objResponse.url,
                        Title = objResponse.title,
                        CommentCount = objResponse.descendants
                    });
                    list = list.OrderByDescending(o=>o.Score).ToList();
                }
                return list;
            }catch(ErrorException ex)
            {
                throw;
            }
        }

        public async Task<NewsDto> GetDetailBy(int id)
        {
            try
            {
                string response = await HttpClientCaller.GetMethod(string.Format(CommonConstants.URL_BEST_STORIES_DETAIL, id));

                var objResponse = JsonConvert.DeserializeObject<DetailDto>(response);

                return new NewsDto
                {
                    PostedBy = objResponse.by,
                    Score = Convert.ToInt32(objResponse.score),
                    Time = objResponse.time,
                    URL = objResponse.url,
                    Title = objResponse.title,
                    CommentCount = objResponse.descendants
                };
            }
            catch(ErrorException e)
            {
                throw e;
            }
            catch(Exception ex)
            {
                throw new ErrorException(ErrorCode.UnknownException, ex.Message, (int)HttpStatusCode.BadRequest);
            }
        }

    }
}
