using Hacker.News.AppService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacker.News.AppService.IService
{
    public interface INewsAppService
    {
        Task<List<NewsDto>> GetAllList();
        Task<NewsDto> GetDetailBy(int id);
    }
}
