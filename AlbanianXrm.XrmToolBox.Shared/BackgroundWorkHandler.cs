﻿using AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace AlbanianXrm.XrmToolBox.Shared
{
    public class BackgroundWorkHandler
    {
        private Panel infoPanel;
        private readonly Queue<BackgroundWorker> queue;
        private readonly ToolViewModelBase toolViewModel;
        private readonly PluginControlBase myPluginControl;
        private readonly SynchronizationContext synchronizationContext;
        private readonly SendOrPostCallback postCallback;
        private readonly int UIThread;

        public BackgroundWorkHandler(PluginControlBase myPluginControl, ToolViewModelBase toolViewModel)
        {
            this.queue = new Queue<BackgroundWorker>();
            this.myPluginControl = myPluginControl;
            this.toolViewModel = toolViewModel;
            synchronizationContext = SynchronizationContext.Current;
            this.postCallback = new SendOrPostCallback(EnqueueBackgroundWork);
            UIThread = Thread.CurrentThread.ManagedThreadId;
        }

        public void EnqueueWork(string message, Action work, Action<BackgroundWorkResult> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorker<object>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Message = message,
                Work = () => { work(); return null; },
                WorkFinished = workFinished
            });
        }
        public void EnqueueWork<TResult>(string message, Func<TResult> work, Action<BackgroundWorkResult<TResult>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorker<TResult>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Message = message,
                Work = work,
                WorkFinished = workFinished
            });
        }
        public void EnqueueWork<T>(string message, Action<T> work, T argument, Action<BackgroundWorkResult<T, object>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerFunc<T, object>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Argument = argument,
                Message = message,
                Work = (arg) => { work(arg); return null; },
                WorkFinished = workFinished
            });
        }
        public void EnqueueWork<T, TResult>(string message, Func<T, TResult> work, T argument, Action<BackgroundWorkResult<T, TResult>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerFunc<T, TResult>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Argument = argument,
                Message = message,
                Work = work,
                WorkFinished = workFinished
            });
        }

        public void EnqueueWork<TProgress>(string message, Action<Reporter<TProgress>> work, Action<TProgress> progress, Action<BackgroundWorkResult> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerProgress<object, TProgress>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Message = message,
                Work = (reporter) => { work(reporter); return null; },
                OnProgress = progress,
                WorkFinished = workFinished
            });
        }
        public void EnqueueWork<TResult, TProgress>(string message, Func<Reporter<TProgress>, TResult> work, Action<TProgress> progress, Action<BackgroundWorkResult<TResult>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerProgress<TResult, TProgress>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Message = message,
                Work = work,
                OnProgress = progress,
                WorkFinished = workFinished
            });
        }
        public void EnqueueWork<T, TProgress>(string message, Action<T, Reporter<TProgress>> work, T argument, Action<TProgress> progress, Action<BackgroundWorkResult<T, object>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerProgressFunc<T, object, TProgress>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Argument = argument,
                Message = message,
                Work = (arg, reporter) => { work(arg, reporter); return null; },
                OnProgress = progress,
                WorkFinished = workFinished
            });
        }
        public void EnqueueWork<T, TResult, TProgress>(string message, Func<T, Reporter<TProgress>, TResult> work, T argument, Action<TProgress> progress, Action<BackgroundWorkResult<T, TResult>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerProgressFunc<T, TResult, TProgress>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Argument = argument,
                Message = message,
                Work = work,
                OnProgress = progress,
                WorkFinished = workFinished
            });
        }

        public void EnqueueAsyncWork(string message, Func<Task> work, Action<BackgroundWorkResult> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerAsync<object>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Message = message,
                Work = async () => { await work(); return null; },
                WorkFinished = workFinished
            });
        }
        public void EnqueueAsyncWork<TResult>(string message, Func<Task<TResult>> work, Action<BackgroundWorkResult<TResult>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerAsync<TResult>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Message = message,
                Work = work,
                WorkFinished = workFinished
            });
        }
        public void EnqueueAsyncWork<T>(string message, Func<T, Task> work, T argument, Action<BackgroundWorkResult<T, object>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerFuncAsync<T, object>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Argument = argument,
                Message = message,
                Work = async (arg) => { await work(arg); return null; },
                WorkFinished = workFinished
            });
        }
        public void EnqueueAsyncWork<T, TResult>(string message, Func<T, Task<TResult>> work, T argument, Action<BackgroundWorkResult<T, TResult>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerFuncAsync<T, TResult>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Argument = argument,
                Message = message,
                Work = work,
                WorkFinished = workFinished
            });
        }

        public void EnqueueAsyncWork<TProgress>(string message, Func<Reporter<TProgress>, Task> work, Action<TProgress> progress, Action<BackgroundWorkResult> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerProgressAsync<object, TProgress>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Message = message,
                Work = async (reporter) => { await work(reporter); return null; },
                OnProgress = progress,
                WorkFinished = workFinished
            });
        }
        public void EnqueueAsyncWork<TResult, TProgress>(string message, Func<Reporter<TProgress>, Task<TResult>> work, Action<TProgress> progress, Action<BackgroundWorkResult<TResult>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerProgressAsync<TResult, TProgress>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Message = message,
                Work = work,
                OnProgress = progress,
                WorkFinished = workFinished
            });
        }
        public void EnqueueAsyncWork<T, TProgress>(string message, Func<T, Reporter<TProgress>, Task> work, T argument, Action<TProgress> progress, Action<BackgroundWorkResult<T, object>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerProgressFuncAsync<T, object, TProgress>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Argument = argument,
                Message = message,
                Work = async (arg, reporter) => { await work(arg, reporter); return null; },
                OnProgress = progress,
                WorkFinished = workFinished
            });
        }
        public void EnqueueAsyncWork<T, TResult, TProgress>(string message, Func<T, Reporter<TProgress>, Task<TResult>> work, T argument, Action<TProgress> progress, Action<BackgroundWorkResult<T, TResult>> workFinished = null)
        {
            EnqueueBackgroundWork(new BackgroundWorkerProgressFuncAsync<T, TResult, TProgress>(synchronizationContext)
            {
                InternalWorkFinished = BackgroundWorkEnded,
                Argument = argument,
                Message = message,
                Work = work,
                OnProgress = progress,
                WorkFinished = workFinished
            });
        }

        private void EnqueueBackgroundWork(object work)
        {
            EnqueueBackgroundWork((BackgroundWorker)work);
        }

        private void EnqueueBackgroundWork(BackgroundWorker work)
        {
            if (UIThread != Thread.CurrentThread.ManagedThreadId)
            {
                synchronizationContext.Post(postCallback, work);
                return;
            }
            if (!queue.Any())
            {
                infoPanel = InformationPanel.GetInformationPanel(myPluginControl, work.Message, 340, 150);
                toolViewModel.AllowRequests = false;
                work.DoWork();
            }
            queue.Enqueue(work);
        }

        private void BackgroundWorkEnded()
        {
            queue.Dequeue();
            if (queue.Any())
            {
                var work = queue.Peek();
                InformationPanel.ChangeInformationPanelMessage(infoPanel, work.Message);
                work.DoWork();
            }
            else
            {
                if (myPluginControl.Controls.Contains(infoPanel))
                {
                    myPluginControl.Controls.Remove(infoPanel);
                    infoPanel.Dispose();
                }
                toolViewModel.AllowRequests = true;
            }
        }
    }
}
