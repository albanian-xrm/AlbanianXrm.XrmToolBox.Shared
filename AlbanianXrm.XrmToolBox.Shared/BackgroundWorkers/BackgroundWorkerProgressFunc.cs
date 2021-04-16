using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorkerProgressFunc<T, TValue, TProgress> : BackgroundWorkerAbstractProgress<TValue, TProgress>
    {
        public Func<T, Reporter<TProgress>, TValue> Work { get; set; }

        public T Argument { get; set; }

        internal override void DoWork()
        {
            task = Task.Factory.StartNew(InternalDoWork, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
        }

        private void InternalDoWork()
        {
            TValue result;
            try
            {
                result = Work(Argument, new Reporter<TProgress>(InternalProgress));
            }
            catch (Exception e)
            {
                reporter.Report(new BackgroundWork2Progress<TValue, TProgress>(e));
                return;
            }
            reporter.Report(new BackgroundWork2Progress<TValue, TProgress>(result));
            return;
        }
    }
}
