using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorkerFuncAsync<T, TResult> : BackgroundWorkerFuncAbstract<T, TResult>
    {
        public BackgroundWorkerFuncAsync(SynchronizationContext synchronizationContext) : base(synchronizationContext) { }

        public Func<T, Task<TResult>> Work { get; set; }

        public T Argument { get; set; }

        internal override void DoWork()
        {
            task = Task.Factory.StartNew(InternalDoWork, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
        }

        private async Task InternalDoWork()
        {
            TResult result;
            try
            {
                result = await Work(Argument);
            }
            catch (Exception e)
            {
                synchronizationContext.Post(postCallback, new BackgroundWorkBase<T, TResult>(Argument, e));
                return;
            }
            synchronizationContext.Post(postCallback, new BackgroundWorkBase<T, TResult>(Argument, result));
            return;
        }
    }
}
