using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorkerAsync<TResult> : BackgroundWorkerAbstract<TResult>
    {
        public Func<Task<TResult>> Work { get; internal set; }

        internal override void DoWork()
        {
            task = Task.Factory.StartNew(InternalDoWork, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
        }

        private async Task InternalDoWork()
        {
            TResult result;
            try
            {
                result = await Work();
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
