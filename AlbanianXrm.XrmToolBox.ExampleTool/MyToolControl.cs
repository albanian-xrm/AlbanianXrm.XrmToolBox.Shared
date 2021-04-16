using AlbanianXrm.XrmToolBox.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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

        private void btnSyncAction_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.QueueWork<string>($"Working Async {++numberOfClicks}" , Work, Progress, WorkEnded);
        }

        private void Work(Reporter<string> reporter)
        {
            reporter.ReportProgress("started");
            Thread.Sleep(5000);
            reporter.ReportProgress("ending");
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

        private void btnAsyncAction_Click(object sender, EventArgs e)
        {
            AsyncWorkHandler.QueueWork<string>($"Working Async {++numberOfClicks}", WorkAsync, Progress);
        }
    }
}
