using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared
{
    public abstract partial class BackgroundWorker
    {
        protected Task task;
        protected readonly SynchronizationContext synchronizationContext;
        protected  SendOrPostCallback postCallback;
        public static event EventHandler<Exception> UnhandledException;

        protected BackgroundWorker(SynchronizationContext synchronizationContext)
        {
            this.synchronizationContext = synchronizationContext;          
        }

        internal string Message { get; set; }
        internal Action InternalWorkFinished { get; set; }

        internal abstract void DoWork();

        protected void ThrowUnhandledException(Exception exception)
        {
            UnhandledException?.Invoke(this, exception);
        }
    }
}
