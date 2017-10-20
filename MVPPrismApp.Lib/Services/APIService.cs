using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MVPPrismApp.Lib.Models;
using MVPPrismApp.Lib.Utils;
using Newtonsoft.Json;

namespace MVPPrismApp.Lib.Services
{
    public class APIService : BaseHttpProvider , IAPIService
    {
        public APIService()
        {
        }

        public async Task<List<VideoItem>> getVideoList()
        {
            var resultList = await Get(URL.VIDEOURL);

            return JsonConvert.DeserializeObject<List<VideoItem>>(resultList);
        }

        public async Task<List<SchduleItem>> getSchduleList()
        {
            var resultList = await Get(URL.SCHDULEURL);
            return JsonConvert.DeserializeObject<List<SchduleItem>>(resultList);

        }

        public async Task<List<NewsInfoItem>> getNewsList()
        {
            var resultList = await Get(URL.GALLERYURL);
            return JsonConvert.DeserializeObject<List<NewsInfoItem>>(resultList);
            
        }

    }
}
