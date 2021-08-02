using RealGameWebsiteTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGameWebsiteTest.IService
{
    public interface INotiService
    {
        List<Noti> GetNotifications(int nTOUserId, bool bIsGetOnlyUnread);
    }
}
