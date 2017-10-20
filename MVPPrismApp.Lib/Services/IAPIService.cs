using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MVPPrismApp.Lib.Models;

namespace MVPPrismApp.Lib.Services
{
    public interface IAPIService
    {
        Task<List<VideoItem>> getVideoList();
        Task<List<SchduleItem>> getSchduleList();
        Task<List<NewsInfoItem>> getNewsList();
    }
}
