using System;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerProgressFuncAbstract<T,TValue, TProgress> : BackgroundWorkerBase
    {
        protected readonly IProgress<BackgroundWorkProgress<T, TValue, TProgress>> reporter;

        public Action<TProgress> OnProgress { get; set; }

        public Action<BackgroundWorkResult<T,TValue>> WorkFinished { get; set; }

        public BackgroundWorkerProgressFuncAbstract()
        {
            reporter = new Progress<BackgroundWorkProgress<T,TValue, TProgress>>(InternalProgress);
        }

        protected void InternalProgress(TProgress progress)
        {
            reporter.Report(new BackgroundWorkProgress<T,TValue, TProgress> (progress));
        }

        private void InternalProgress(BackgroundWorkProgress<T, TValue, TProgress> state)
        {
            try
            {
                if (state.Finished)
                {
                    WorkFinished?.Invoke(state.Result);
                }
                else { OnProgress?.Invoke(state.Progress); }
            }
            catch (Exception ex)
            {
                ThrowUnhandledException(ex);
            }
            if (state.Finished)
            {
                InternalWorkFinished();
                task = null;
            }
        }
    }
}
