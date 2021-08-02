using Dapper;
using Microsoft.Data.SqlClient;
using RealGameWebsiteTest.Common;
using RealGameWebsiteTest.IService;
using RealGameWebsiteTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RealGameWebsiteTest.Service
{
    public class NotiService : INotiService
    {
        List<Noti> _oNotifications = new List<Noti>();
        public List<Noti> GetNotifications(int nTOUserId, bool bIsGetOnlyUnread)
        {
            _oNotifications = new List<Noti>();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                var oNotis = con.Query<Noti>("SELECT * FROM View_Notification WHERE ToUserId=" + nTOUserId).ToList();

                if(oNotis !=null&& oNotis.Count() > 0)
                {
                    _oNotifications = oNotis;
                }
                return _oNotifications;
            }
        }

    }
}
