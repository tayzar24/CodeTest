using Hacker.News.Common.CustomException;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hacker.News.AppService.Util
{
    public class HttpClientCaller
    {
        public static async Task<string> GetMethod(string url)
        {
            string responseBody = string.Empty;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            responseBody = await response.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            throw new ErrorException(ErrorCode.ThirdParty_Error, "", (int)HttpStatusCode.BadRequest);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ErrorException(ErrorCode.ThirdParty_Error, ex.Message, (int)HttpStatusCode.BadRequest);
                    }

                    return responseBody;
                }
            }
            catch(Exception ex)
            {
                throw new ErrorException(ErrorCode.ThirdParty_Error, ex.Message, (int)HttpStatusCode.BadRequest);
            }
        }
    }
}
