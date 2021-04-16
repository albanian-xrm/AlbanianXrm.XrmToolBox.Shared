using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorkerFunc<T, TResult> : BackgroundWorkerFuncAbstract<T, TResult>
    {
        public Func<T, TResult> Work { get; internal set; }

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
                progress.Report(new BackgroundWorkBase<T, TResult>(Argument, e));
                return;
            }
            progress.Report(new BackgroundWorkBase<T, TResult>(Argument, result));
            return;
        }
    }
}
