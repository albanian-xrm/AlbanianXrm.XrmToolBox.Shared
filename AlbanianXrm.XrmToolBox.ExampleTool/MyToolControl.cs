using AlbanianXrm.BackgroundWorker;
using AlbanianXrm.XrmToolBox.Shared;
using AlbanianXrm.XrmToolBox.Shared.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace AlbanianXrm.XrmToolBox.ExampleTool
{
    public partial class MyToolControl : PluginControlBase, IGitHubPlugin, IPrivatePlugin
    {
        public string RepositoryName => throw new NotImplementedException();

        public string UserName => throw new NotImplementedException();

        private readonly BackgroundWorkHandler AsyncWorkHandler;
        private readonly ToolViewModel toolViewModel;
        private int numberOfClicks = 0;

        public MyToolControl()
        {
            InitializeComponent();
            toolViewModel = new ToolViewModel();
            AsyncWorkHandler = new BackgroundWorkHandler();
        }

        private void BtnSyncI0R0W_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueBackgroundWork(
                BackgroundWorkerFactory
                    .NewWorker<string>(Work, Progress, WorkEnded)
                    .WithMessage(this, $"Working Async {++numberOfClicks}")
                    .WithViewModel(toolViewModel)
                );
        }

        private void Work(Reporter<string> reporter)
        {
            reporter.ReportProgress("started");
            Thread.Sleep(5000);
            reporter.ReportProgress("ending");
        }

        private void BtnSyncI1R0W_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueBackgroundWork(
              BackgroundWorkerFactory
                  .NewWorker<string, string>(Work, "input", Progress, WorkEndedArgument)
                  .WithMessage(this, $"Working Async {++numberOfClicks}")
              );
        }

        private void Work(string arg, Reporter<string> reporter)
        {
            System.Diagnostics.Debug.WriteLine("background " + arg);
            reporter.ReportProgress("started");
            Thread.Sleep(5000);
            reporter.ReportProgress("ending");
        }

        private void BtnSyncI0R1W_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueBackgroundWork(
                  BackgroundWorkerFactory
                      .NewWorker<string, string>(Work2, Progress, WorkEnded)
                      .WithMessage(this, $"Working Async {++numberOfClicks}")
                  );
        }

        private string Work2(Reporter<string> reporter)
        {
            reporter.ReportProgress("started");
            Thread.Sleep(5000);
            reporter.ReportProgress("ending");
            return "result";
        }

        private void BtnSyncI1R1W_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueBackgroundWork(
               BackgroundWorkerFactory
                   .NewWorker<string, string, string>(Work2, "argument", Progress, WorkEnded)
                   .WithMessage(this, $"Working Async {++numberOfClicks}")
               );
        }

        private string Work2(string argument, Reporter<string> reporter)
        {
            reporter.ReportProgress("started");
            Thread.Sleep(5000);
            reporter.ReportProgress("ending");
            return "result";
        }

        private void BtnAsyncI0R0W_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueBackgroundWork(
            BackgroundWorkerFactory
                .NewAsyncWorker<string>(WorkAsync, Progress, WorkEnded)
                .WithMessage(this, $"Working Async {++numberOfClicks}")
            );
        }

        private async Task WorkAsync(Reporter<string> reporter)
        {
            reporter.ReportProgress("started");
            await Task.Delay(5000);
            reporter.ReportProgress("ending");
        }

        private void BtnAsyncI1R0W_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueBackgroundWork(
          BackgroundWorkerFactory
              .NewAsyncWorker<string, string>(WorkAsync, "argument", Progress, WorkEnded)
              .WithMessage(this, $"Working Async {++numberOfClicks}")
          );
        }

        private async Task WorkAsync(string argument, Reporter<string> reporter)
        {
            reporter.ReportProgress("started");
            await Task.Delay(5000);
            reporter.ReportProgress("ending");
        }

        private void Progress(string progress)
        {
            listBox1.Items.Add(progress);
        }

        private void BtnSyncI0R0_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueBackgroundWork(
                BackgroundWorkerFactory
                    .NewWorker(Work, WorkEnded)
                    .WithMessage(this, $"Working No Input, No Output Async {++numberOfClicks}")
            );
        }

        private void Work()
        {
            Thread.Sleep(5000);
        }

        private void BtnSyncI1R0_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueBackgroundWork(
             BackgroundWorkerFactory
                 .NewWorker(Work, "argument", WorkEndedArgument)
                 .WithMessage(this, $"Working With Input, No Output Async {++numberOfClicks}")
            );
        }

        private void Work(string argument)
        {
            Thread.Sleep(5000);
        }

        private void WorkEnded(Exception exception)
        {
            listBox1.Items.Add("ended");
        }

        private void WorkEndedArgument(string arg, Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(arg);
            listBox1.Items.Add("ended");
        }

        private void WorkEnded(string value, Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(value);
            listBox1.Items.Add("ended");
        }

        private void WorkEnded(string arg, string value, Exception exception)
        {
            listBox1.Items.Add("ended");
        }

      
    }
}
