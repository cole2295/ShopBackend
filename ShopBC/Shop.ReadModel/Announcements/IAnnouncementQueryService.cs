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
        Announcement Find(Guid id);
        IEnumerable<Announcement> ListPage();
    }
}