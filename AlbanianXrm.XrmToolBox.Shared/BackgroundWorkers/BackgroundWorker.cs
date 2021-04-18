using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorker<TResult> : BackgroundWorkerAbstract<TResult>
    {
        public BackgroundWorker(SynchronizationContext synchronizationContext) : base(synchronizationContext) { }

        public Func<TResult> Work { get; internal set; }

        internal override void DoWork()
        {
            task = Task.Factory.StartNew(InternalDoWork, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
        }

        private void InternalDoWork()
        {
            TResult result;
            try
            {
                result = Work();
            }
            catch (Exception e)
            {
                synchronizationContext.Post(postCallback, new BackgroundWorkBase<TResult>(e));
                return;
            }
            synchronizationContext.Post(postCallback, new BackgroundWorkBase<TResult>(result));
            return;
        }
    }
}
