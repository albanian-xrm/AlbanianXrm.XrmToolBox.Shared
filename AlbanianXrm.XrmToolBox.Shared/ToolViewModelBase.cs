using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlbanianXrm.XrmToolBox.Shared
{
    public class ToolViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool _AllowRequests = true;
        public bool AllowRequests
        {
            get { return _AllowRequests; }
            set
            {
                if (_AllowRequests == value) return;
                _AllowRequests = value;
                AllowRequestsChanged();
                NotifyPropertyChanged();
            }
        }

        protected virtual void AllowRequestsChanged() { }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
