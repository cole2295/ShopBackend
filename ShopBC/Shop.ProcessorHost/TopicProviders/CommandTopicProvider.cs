﻿using ECommon.Components;
using ENode.Commanding;
using ENode.EQueue;
using Shop.Common;

namespace Shop.ProcessorHost.TopicProviders
{
    [Component]
    public class CommandTopicProvider : AbstractTopicProvider<ICommand>
    {
        public override string GetTopic(ICommand command)
        {
            //if (command is MakeSeatReservation || command is CommitSeatReservation || command is CancelSeatReservation)
            //{
            //    return Topics.ConferenceCommandTopic;
            //}
            //else if (command is CreatePayment || command is CompletePayment || command is CancelPayment)
            //{
            //    return Topics.PaymentCommandTopic;
            //}
            return Topics.ShopCommandTopic;
        }
    }
}
