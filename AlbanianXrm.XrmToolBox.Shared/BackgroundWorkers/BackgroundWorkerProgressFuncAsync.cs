using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorkerProgressFuncAsync<T, TValue, TProgress> : BackgroundWorkerProgressFuncAbstract<T, TValue, TProgress>
    {
        public Func<T, Reporter<TProgress>, Task<TValue>> Work { get; set; }

        public T Argument { get; set; }

        internal override void DoWork()
        {
            task = Task.Factory.StartNew(InternalDoWork, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
        }

        private async Task InternalDoWork()
        {
            TValue result;
            try
            {
                result = await Work(Argument, new Reporter<TProgress>(InternalProgress));
            }
            catch (Exception e)
            {
                reporter.Report(new BackgroundWorkProgress<T, TValue, TProgress>(Argument, e));
                return;
            }
            reporter.Report(new BackgroundWorkProgress<T, TValue, TProgress>(Argument, result));
            return;
        }
    }
}
