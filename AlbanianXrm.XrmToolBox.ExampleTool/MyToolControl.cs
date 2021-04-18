using AlbanianXrm.XrmToolBox.Shared;
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

        private BackgroundWorkHandler AsyncWorkHandler;
        private ToolViewModel toolViewModel;
        private int numberOfClicks = 0;


        public MyToolControl()
        {
            InitializeComponent();
            toolViewModel = new ToolViewModel();
            AsyncWorkHandler = new BackgroundWorkHandler(this, toolViewModel);
        }

        private void btnSyncI0R0W_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueWork<string>($"Working Async {++numberOfClicks}", Work, Progress, WorkEnded);
        }

        private void btnSyncI1R0W_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueWork<string, string>($"Working Async {++numberOfClicks}", Work, "input", Progress, WorkEnded2);
        }

        private void Work(Reporter<string> reporter)
        {          
            reporter.ReportProgress("started");
            Thread.Sleep(5000);
            reporter.ReportProgress("ending");
        }

        private void Work(string arg, Reporter<string> reporter)
        {
            System.Diagnostics.Debug.WriteLine("background " + arg);
            reporter.ReportProgress("started");
            Thread.Sleep(5000);
            reporter.ReportProgress("ending");
        }

        private void WorkEnded2(BackgroundWorkResult<string, object> result)
        {
            System.Diagnostics.Debug.WriteLine(result.Argument);
            listBox1.Items.Add("ended");
        }

        private void WorkEnded(BackgroundWorkResult result)
        {
            listBox1.Items.Add("ended");
        }

        private async Task WorkAsync(Reporter<string> reporter)
        {
            reporter.ReportProgress("started");
            await Task.Delay(5000);
            reporter.ReportProgress("ending");
        }

        private void Progress(string progress)
        {
            listBox1.Items.Add(progress);
        }

        private void btnAsyncI0R0W_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.EnqueueAsyncWork<string>($"Working Async {++numberOfClicks}", WorkAsync, Progress);
        }

       
    }
}
