using System;
using System.Threading;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerProgressAbstract<TValue, TProgress> : BackgroundWorker
    {
        public BackgroundWorkerProgressAbstract(SynchronizationContext synchronizationContext) : base(synchronizationContext)
        {
            base.postCallback = new SendOrPostCallback(InternalProgress);
        }

        public Action<TProgress> OnProgress { get; set; }

        public Action<BackgroundWorkResult<TValue>> WorkFinished { get; set; }

        protected void InternalProgress(TProgress progress)
        {
            synchronizationContext.Post(postCallback, new BackgroundWorkProgress<TValue, TProgress>(progress));
        }

        private void InternalProgress(object stateObject)
        {
            BackgroundWorkProgress<TValue, TProgress> state = (BackgroundWorkProgress<TValue, TProgress>)stateObject;
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
