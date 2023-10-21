using DotNetStarter.Bridges;
using Hangfire;
using MediatR;

namespace DotNetStarter.Extensions
{
    public static class MediatorExtensions
    {
        public static void Enqueue(this IRequest @this) => BackgroundJob.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send(@this));

        public static void Enqueue(this INotification @this) => BackgroundJob.Enqueue<MediatorHangfireBridge>(bridge => bridge.Publish(@this));

        public static void Schedule(this IRequest @this, int delay) => BackgroundJob.Schedule<MediatorHangfireBridge>(bridge => bridge.Send(@this), TimeSpan.FromMinutes(delay));

        public static void Schedule(this INotification @this, int delay) => BackgroundJob.Schedule<MediatorHangfireBridge>(bridge => bridge.Publish(@this), TimeSpan.FromMinutes(delay));
    }
}