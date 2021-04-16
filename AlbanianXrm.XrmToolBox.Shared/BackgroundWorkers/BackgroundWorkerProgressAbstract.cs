using System;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerProgressAbstract<TValue, TProgress> : BackgroundWorkerBase
    {
        protected readonly IProgress<BackgroundWorkProgress<TValue, TProgress>> reporter;

        public Action<TProgress> OnProgress { get; set; }

        public Action<BackgroundWorkResult<TValue>> WorkFinished { get; set; }

        public BackgroundWorkerProgressAbstract()
        {
            reporter = new Progress<BackgroundWorkProgress<TValue, TProgress>>(InternalProgress);
        }

        protected void InternalProgress(TProgress progress)
        {
            reporter.Report(new BackgroundWorkProgress<TValue, TProgress> (progress));
        }

        private void InternalProgress(BackgroundWorkProgress<TValue, TProgress> state)
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
