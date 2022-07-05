using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.ContentTagService
{
    public class ContentTagServices: GenericService<ContentTag>,IContentTagServices
    {
        public ContentTagServices(IRepository repository) : base(repository) { }
    }
}