using Shop.ReadModel.Carts.Dtos;
using System;
using System.Collections.Generic;

namespace Shop.ReadModel.Carts
{
    /// <summary>
    /// ��ѯ����ӿ�
    /// </summary>
    public interface ICartQueryService
    {
        Cart Info(Guid id);

        IEnumerable<CartGoods> CartGoodses(Guid cartId);
    }
}