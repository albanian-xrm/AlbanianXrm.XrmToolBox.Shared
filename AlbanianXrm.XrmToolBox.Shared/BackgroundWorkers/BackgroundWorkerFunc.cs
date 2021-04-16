using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorkerFunc<T, TResult> : BackgroundWorkerAbstract<TResult>
    {
        public Func<T,TResult> Work { get; internal set; }

        public T Argument { get; set; }

        internal override void DoWork()
        {
            task = Task.Factory.StartNew(InternalDoWork, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
        }

        private void InternalDoWork()
        {
            TResult result;
            try
            {
                result = Work(Argument);
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
