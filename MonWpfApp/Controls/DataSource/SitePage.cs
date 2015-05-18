using System.ComponentModel;
using System.Runtime.CompilerServices;
using MonWpfApp.Annotations;

namespace MonWpfApp.Controls.DataSource
{
    /// <summary>
    /// Display data
    /// </summary>
    public class SitePage : INotifyPropertyChanged
    {
        #region private

        private string _displayName;
        private object _pageUri;
        
        #endregion

        #region Properties
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                if (_displayName == value) return;
                _displayName = value;
                OnPropertyChanged("DisplayName");
            }
        }

        public object PageUri
        {
            get
            {
                return _pageUri;
            }
            set
            {
                if (_pageUri == value) return;
                _pageUri = value;
                OnPropertyChanged("PageUri");
            }
        }
        #endregion

        #region InotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
