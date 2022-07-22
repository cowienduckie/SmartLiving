﻿using System.Collections.Generic;
using EventBus.Base.Standard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SmartLiving.DeviceMVC.BusinessLogics.IntegrationEvents.Events;
using SmartLiving.DeviceMVC.BusinessLogics.IntegrationEvents.Handlers;

namespace SmartLiving.DeviceMVC.Extensions
{
    public static class EventBusExtension
    {
        public static IEnumerable<IIntegrationEventHandler> GetHandlers()
        {
            return new List<IIntegrationEventHandler>
            {
                new SeverMsgEventHandler()
            };
        }

        public static IApplicationBuilder SubscribeToEvents(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<ServerMsgEvent, SeverMsgEventHandler>();

            return app;
        }
    }
}