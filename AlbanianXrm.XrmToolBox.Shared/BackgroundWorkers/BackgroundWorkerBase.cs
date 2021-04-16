using System;
using System.Threading.Tasks;

namespace AlbanianXrm.XrmToolBox.Shared.BackgroundWorkers
{
    public abstract partial class BackgroundWorkerBase
    {
        protected Task task;
        public static event EventHandler<Exception> UnhandledException;
        internal string Message { get; set; }
        internal Action InternalWorkFinished { get; set; }

        internal abstract void DoWork();

        protected void ThrowUnhandledException(Exception exception)
        {
            UnhandledException?.Invoke(this, exception);    
        }
    }
}
