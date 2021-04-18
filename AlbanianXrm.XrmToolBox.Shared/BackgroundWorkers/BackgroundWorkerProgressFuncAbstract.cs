using System;
using System.Threading;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerProgressFuncAbstract<T, TValue, TProgress> : BackgroundWorker
    {
        public BackgroundWorkerProgressFuncAbstract(SynchronizationContext synchronizationContext) : base(synchronizationContext)
        {
            base.postCallback = new SendOrPostCallback(InternalProgress);
        }

        public Action<TProgress> OnProgress { get; set; }

        public Action<BackgroundWorkResult<T, TValue>> WorkFinished { get; set; }

        protected void InternalProgress(TProgress progress)
        {
            synchronizationContext.Post(postCallback, new BackgroundWorkProgress<T, TValue, TProgress>(progress));
        }

        private void InternalProgress(object stateObject)
        {
            BackgroundWorkProgress<T, TValue, TProgress> state = (BackgroundWorkProgress<T, TValue, TProgress>)stateObject;
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
