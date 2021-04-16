using System;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerAbstract<TResult> : BackgroundWorkerBase
    {
        protected readonly IProgress<BackgroundWork2Base<TResult>> progress;
        public Action<BackgroundWorkResult<TResult>> WorkFinished { get; set; }

        public BackgroundWorkerAbstract()
        {
            progress = new Progress<BackgroundWork2Base<TResult>>(InternalProgress);
        }

        private void InternalProgress(BackgroundWork2Base<TResult> state)
        {
            if (state.Finished)
            {
                try
                {
                    WorkFinished?.Invoke(state.Result);
                }
                catch (Exception ex)
                {
                    ThrowUnhandledException(ex);
                }
                InternalWorkFinished();
                task = null;
            }
        }
    }
}
