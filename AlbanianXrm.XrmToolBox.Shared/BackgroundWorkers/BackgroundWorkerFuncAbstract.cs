using System;
using System.Threading;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerFuncAbstract<T, TResult> : BackgroundWorker
    {
        public Action<BackgroundWorkResult<T, TResult>> WorkFinished { get; set; }

        public BackgroundWorkerFuncAbstract(SynchronizationContext synchronizationContext) : base(synchronizationContext)
        {
            base.postCallback = new SendOrPostCallback(InternalProgress);
        }

        private void InternalProgress(object stateObject)
        {
            BackgroundWorkBase<T, TResult> state = (BackgroundWorkBase<T, TResult>)stateObject;
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
