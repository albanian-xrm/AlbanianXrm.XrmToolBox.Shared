using System;
using System.Threading;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerAbstract<TResult> : BackgroundWorker
    {
        public Action<BackgroundWorkResult<TResult>> WorkFinished { get; set; }

        public BackgroundWorkerAbstract(SynchronizationContext synchronizationContext) : base(synchronizationContext)
        {
            this.postCallback = new SendOrPostCallback(InternalProgress);
        }

        private void InternalProgress(object stateObject)
        {
            BackgroundWorkBase<TResult> state = (BackgroundWorkBase<TResult>)stateObject;
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
