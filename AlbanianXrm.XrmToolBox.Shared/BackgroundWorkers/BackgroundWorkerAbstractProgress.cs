using System;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerAbstractProgress<TValue, TProgress> : BackgroundWorkerBase
    {
        protected readonly IProgress<BackgroundWork2Progress<TValue, TProgress>> reporter;

        public Action<TProgress> OnProgress { get; set; }

        public Action<BackgroundWorkResult<TValue>> WorkFinished { get; set; }

        public BackgroundWorkerAbstractProgress()
        {
            reporter = new Progress<BackgroundWork2Progress<TValue, TProgress>>(InternalProgress);
        }

        protected void InternalProgress(TProgress progress)
        {
            reporter.Report(new BackgroundWork2Progress<TValue, TProgress> (progress));
        }

        private void InternalProgress(BackgroundWork2Progress<TValue, TProgress> state)
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
