using ECommon.Components;
using Shop.ReadModel.Announcements.Dtos;
using System.Collections.Generic;
using Dapper;
using ECommon.Dapper;
using Shop.Common;

namespace Shop.ReadModel.Announcements
{
    /// <summary>
    /// ��ѯ���� ʵ��
    /// </summary>
    [Component]
    public class AnnouncementQueryService : BaseQueryService, IAnnouncementQueryService
    {
        public IEnumerable<Announcement> ListPage()
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<Announcement>(new {  }, ConfigSettings.AnnouncementTable);
            }
        }

        
    }
}