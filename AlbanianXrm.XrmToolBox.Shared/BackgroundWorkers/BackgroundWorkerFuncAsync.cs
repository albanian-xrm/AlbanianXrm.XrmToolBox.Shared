using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorkerFuncAsync<T, TResult> : BackgroundWorkerAbstract<TResult>
    {
        public Func<T,Task<TResult>> Work { get; internal set; }

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
                progress.Report(new BackgroundWork2Base<TResult>(e));
                return;
            }
            progress.Report(new BackgroundWork2Base<TResult>(result));
            return;
        }
    }
}
