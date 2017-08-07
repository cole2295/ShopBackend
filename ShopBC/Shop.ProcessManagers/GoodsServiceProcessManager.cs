﻿using ECommon.Components;
using ECommon.IO;
using ENode.Commanding;
using ENode.Infrastructure;
using Shop.Commands.Users;
using Shop.Domain.Events.Stores.StoreOrders.GoodsServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.ProcessManagers
{

    [Component]
    public class GoodsServiceProcessManager :
        IMessageHandler<ServiceFinishedEvent>,//商品服务结束 (OrderGoods)
        IMessageHandler<ServiceExpiredEvent>//商品服务过期 (OrderGoods)
       
    {
        private ICommandService _commandService;

        public GoodsServiceProcessManager(ICommandService commandService)
        {
            _commandService = commandService;
        }

        /// <summary>
        /// 商品服务结束 可以结算用户奖励等等 联盟等等
        /// </summary>
        /// <param name="evnt"></param>
        /// <returns></returns>
        public Task<AsyncTaskResult> HandleAsync(ServiceFinishedEvent evnt)
        {
            var tasks = new List<Task>();
            //结算用户奖励
            tasks.Add(_commandService.SendAsync(new AcceptMyNewSpendingCommand(
                evnt.Total,
                evnt.SurrenderPersent
                )));
            //结算商家奖励也是给用户结算
            tasks.Add(_commandService.SendAsync(new AcceptNewSaleCommand(
                evnt.Total,
                evnt.SurrenderPersent
                )));

            Task.WaitAll(tasks.ToArray());
            //Task.WhenAll(tasks).ConfigureAwait(false);
            return Task.FromResult(AsyncTaskResult.Success);
        }

        /// <summary>
        /// 商品服务到期
        /// </summary>
        /// <param name="evnt"></param>
        /// <returns></returns>
        public Task<AsyncTaskResult> HandleAsync(ServiceExpiredEvent evnt)
        {
            var tasks = new List<Task>();
            //结算用户奖励
            tasks.Add(_commandService.SendAsync(new AcceptMyNewSpendingCommand(
                evnt.Total,
                evnt.SurrenderPersent
                )));
            //结算商家奖励也是给用户结算
            tasks.Add(_commandService.SendAsync(new AcceptNewSaleCommand(
                evnt.Total,
                evnt.SurrenderPersent
                )));

            return Task.FromResult(AsyncTaskResult.Success);
        }
    }
}