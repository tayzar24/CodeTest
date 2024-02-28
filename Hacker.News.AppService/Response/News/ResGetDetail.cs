using Hacker.News.AppService.Dto;
using Hacker.News.Common.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacker.News.AppService.Response.News
{
    public class ResGetDetail : ResponseBase
    {
        public NewsDto Data { get; set; }
    }
}
