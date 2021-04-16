﻿using System;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal abstract class BackgroundWorkerAbstract<TResult> : BackgroundWorkerBase
    {
        protected readonly IProgress<BackgroundWorkBase<TResult>> progress;
        public Action<BackgroundWorkResult<TResult>> WorkFinished { get; set; }

        public BackgroundWorkerAbstract()
        {
            progress = new Progress<BackgroundWorkBase<TResult>>(InternalProgress);
        }

        private void InternalProgress(BackgroundWorkBase<TResult> state)
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
