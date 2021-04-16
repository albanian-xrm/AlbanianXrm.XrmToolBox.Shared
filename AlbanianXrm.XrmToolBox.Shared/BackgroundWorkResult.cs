using System;

namespace AlbanianXrm.XrmToolBox.Shared
{
    public class BackgroundWorkResult
    {
        public BackgroundWorkResult(Exception exception)
        {
            this.Exception = exception;
        }
        public Exception Exception { get; internal set; }
    }

    public class BackgroundWorkResult<T> : BackgroundWorkResult
    {
        public BackgroundWorkResult(Exception exception) : base(exception) { }

        public BackgroundWorkResult(T value) : base(null)
        {
            this.Value = value;
        }
        public T Value { get; internal set; }
    }
}
