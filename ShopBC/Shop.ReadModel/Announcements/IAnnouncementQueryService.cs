using Shop.ReadModel.Announcements.Dtos;
using System;
using System.Collections.Generic;

namespace Shop.ReadModel.Announcements
{
    /// <summary>
    /// ��ѯ����ӿ�
    /// </summary>
    public interface IAnnouncementQueryService
    {
        IEnumerable<Announcement> ListPage();
    }
}