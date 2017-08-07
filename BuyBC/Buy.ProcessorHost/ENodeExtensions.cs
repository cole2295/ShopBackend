﻿using System.Net;
using System.Collections.Generic;
using Shop.Common;
using ECommon.Socketing;
using ENode.Commanding;
using ENode.Configurations;
using ENode.EQueue;
using ENode.Eventing;
using ENode.Infrastructure;
using EQueue.Clients.Consumers;
using EQueue.Clients.Producers;
using EQueue.Configurations;

namespace Buy.ProcessorHost
{
    public static class ENodeExtensions
    {
        private static CommandService _commandService;
        private static CommandConsumer _commandConsumer;
        private static ApplicationMessageConsumer _applicationMessageConsumer;
        private static DomainEventPublisher _domainEventPublisher;
        private static DomainEventConsumer _eventConsumer;

        public static ENodeConfiguration UseEQueue(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();

            configuration.RegisterEQueueComponents();

            var producerSetting = new ProducerSetting
            {
                NameServerList = new List<IPEndPoint> { new IPEndPoint(SocketUtils.GetLocalIPV4(), ConfigSettings.NameServerPort) }
            };
            var consumerSetting = new ConsumerSetting
            {
                NameServerList = new List<IPEndPoint> { new IPEndPoint(SocketUtils.GetLocalIPV4(), ConfigSettings.NameServerPort) }
            };

            _domainEventPublisher = new DomainEventPublisher(producerSetting);

            configuration.SetDefault<IMessagePublisher<DomainEventStreamMessage>, DomainEventPublisher>(_domainEventPublisher);

            _commandService = new CommandService(null, producerSetting);

            configuration.SetDefault<ICommandService, CommandService>(_commandService);

            _commandConsumer = new CommandConsumer("BuyCommandConsumerGroup", consumerSetting).Subscribe(Topics.BuyCommandTopic);
            _eventConsumer = new DomainEventConsumer("BuyEventConsumerGroup", consumerSetting).Subscribe(Topics.BuyDomainEventTopic);
            _applicationMessageConsumer = new ApplicationMessageConsumer("BuyMessageConsumerGroup", consumerSetting)
                .Subscribe(Topics.ShopApplicationMessageTopic)
                .Subscribe(Topics.PaymentApplicationMessageTopic);

            return enodeConfiguration;
        }
        public static ENodeConfiguration StartEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _applicationMessageConsumer.Start();
            _eventConsumer.Start();
            _commandConsumer.Start();
            _domainEventPublisher.Start();
            _commandService.Start();

            return enodeConfiguration;
        }
        public static ENodeConfiguration ShutdownEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _commandService.Shutdown();
            _domainEventPublisher.Shutdown();
            _commandConsumer.Shutdown();
            _eventConsumer.Shutdown();
            _applicationMessageConsumer.Shutdown();
            return enodeConfiguration;
        }
    }
}
