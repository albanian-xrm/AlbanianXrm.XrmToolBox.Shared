using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorker<TResult> : BackgroundWorkerAbstract<TResult>
    {
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
                progress.Report(new BackgroundWork2Base<TResult>(e));
                return;
            }
            progress.Report(new BackgroundWork2Base<TResult>(result));
            return;
        }
    }
}
