using System;

namespace AlbanianXrm.XrmToolBox.Shared
{
    internal class BackgroundWorkProgressBase
    {
        public BackgroundWorkProgressBase() : this(null)
        {
        }

        public BackgroundWorkProgressBase(Exception exception)
        {
            this.Result = new BackgroundWorkResult(exception);
            this.Finished = true;
        }

        public bool Finished { get; set; }

        public BackgroundWorkResult Result { get; set; }
    }

    internal class BackgroundWorkProgress<TProgress> : BackgroundWorkProgressBase
    {
        public BackgroundWorkProgress() : base() { }
        public BackgroundWorkProgress(Exception exception) : base(exception) { }

        public BackgroundWorkProgress(TProgress progress)
        {
            this.Progress = progress;
            this.Finished = false;
        }

        public TProgress Progress { get; set; }
    }

    internal class BackgroundWork2Base<T>
    {
        public BackgroundWork2Base() : this(null)
        {
        }

        public BackgroundWork2Base(Exception exception)
        {
            this.Result = new BackgroundWorkResult<T>(exception);
            this.Finished = true;
        }

        public BackgroundWork2Base(T value)
        {
            this.Result = new BackgroundWorkResult<T>(value);
            this.Finished = true;
        }

        public bool Finished { get; set; }

        public BackgroundWorkResult<T> Result { get; set; }
    }

    internal class BackgroundWork2Progress<T, TProgress> : BackgroundWork2Base<T>
    {
        public BackgroundWork2Progress(): base() { }

        public BackgroundWork2Progress(Exception e): base(e) { }

        public BackgroundWork2Progress(T value) : base(value) { }

        public BackgroundWork2Progress(TProgress progress)
        {
            this.Progress = progress;
            this.Finished = false;
        }

        public TProgress Progress { get; set; }
    }
}
