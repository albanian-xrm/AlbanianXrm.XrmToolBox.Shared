﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    internal class BackgroundWorkerProgressAsync<TValue, TProgress> : BackgroundWorkerAbstractProgress<TValue, TProgress>
    {
        public Func<Reporter<TProgress>, Task<TValue>> Work { get; internal set; }

        internal override void DoWork()
        {
            task = Task.Factory.StartNew(InternalDoWork, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
        }

        private async Task InternalDoWork()
        {
            TValue value;
            try
            {
                value = await Work(new Reporter<TProgress>(InternalProgress));
            }
            catch (Exception e)
            {
                reporter.Report(new BackgroundWork2Progress<TValue, TProgress>(e));
                return;
            }
            reporter.Report(new BackgroundWork2Progress<TValue, TProgress>(value));
            return;
        }
    }
}
