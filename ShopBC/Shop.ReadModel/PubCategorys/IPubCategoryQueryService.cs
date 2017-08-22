using Shop.ReadModel.PubCategorys.Dtos;
using System;
using System.Collections.Generic;

namespace Shop.ReadModel.PubCategorys
{
    /// <summary>
    /// ��ѯ����ӿ�
    /// </summary>
    public interface IPubCategoryQueryService
    {
        IEnumerable<PubCategory> RootCategorys();

        IEnumerable<PubCategory> GetChildren(Guid id);

    }
}