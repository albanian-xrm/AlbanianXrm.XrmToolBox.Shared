using AlbanianXrm.BackgroundWorker;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace AlbanianXrm.XrmToolBox.Shared.Extensions
{
    public static class BackgroundWorkerExtensions
    {
        public static T WithMessage<T>(this T backgroundWorker, Control control, string message, int width = 340, int height = 150) where T : AlBackgroundWorker
        {
            backgroundWorker.OnBeforeStart += () =>
            {
                var infoPanel = InformationPanel.GetInformationPanel(control, message, width, height);
                backgroundWorker.OnAfterEnd += () =>
                {
                    if (control.Controls.Contains(infoPanel))
                    {
                        control.Controls.Remove(infoPanel);
                        infoPanel.Dispose();
                    }
                };
            };
            return backgroundWorker;
        }

        public static T WithViewModel<T>(this T backgroundWorker, ToolViewModelBase viewModelBase) where T : AlBackgroundWorker
        {
            backgroundWorker.OnBeforeStart += () =>
            {
                viewModelBase.AllowRequests = false;
            };
            backgroundWorker.OnAfterEnd += () =>
            {
                viewModelBase.AllowRequests = true;
            };
            return backgroundWorker;
        }
    }
}
