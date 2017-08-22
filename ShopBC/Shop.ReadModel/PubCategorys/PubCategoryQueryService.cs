using Dapper;
using ECommon.Components;
using ECommon.Dapper;
using Shop.Common;
using Shop.ReadModel.PubCategorys.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.ReadModel.PubCategorys
{
    /// <summary>
    /// ��ѯ���� ʵ��
    /// </summary>
    [Component]
    public class PubCategoryQueryService : BaseQueryService,IPubCategoryQueryService
    {
        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PubCategory> RootCategorys()
        {
            
            using (var connection = GetConnection())
            {
                return connection.QueryList<PubCategory>(new { ParentId = Guid.Empty}, ConfigSettings.PubCategoryTable).ToList();
            }
        }

        public IEnumerable<PubCategory> GetChildren(Guid id)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<PubCategory>(new { ParentId = id }, ConfigSettings.PubCategoryTable);
            }
        }
    }
}