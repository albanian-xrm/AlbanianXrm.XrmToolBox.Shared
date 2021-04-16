using System;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerFuncAbstract<T, TResult> : BackgroundWorkerBase
    {
        protected readonly IProgress<BackgroundWorkBase<T, TResult>> progress;
        public Action<BackgroundWorkResult<T,TResult>> WorkFinished { get; set; }

        public BackgroundWorkerFuncAbstract()
        {
            progress = new Progress<BackgroundWorkBase<T, TResult>>(InternalProgress);
        }

        private void InternalProgress(BackgroundWorkBase<T, TResult> state)
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
