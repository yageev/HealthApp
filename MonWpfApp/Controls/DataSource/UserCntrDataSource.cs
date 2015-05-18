using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using MonWpfApp.Annotations;

namespace MonWpfApp.Controls.DataSource
{
    public class SiteMap : INotifyPropertyChanged, ISupportInitialize
    {
        #region Variables

        #region const

        private readonly SolidColorBrush ActiveBrush = new SolidColorBrush(Colors.Red);
        private readonly SolidColorBrush InActiveBrush = new SolidColorBrush(Colors.Black);

        #endregion

        #region Private

        private readonly ICommand _selectNextPage = null;
        private readonly ICommand _selectPreviousPage = null;
        private readonly ICommand _selectLastOpenedPage = null;

        private SitePage _selectedPage;
        private SitePage _lastOpenedPage;

        private readonly ObservableCollection<SitePage> _pages;
        private readonly ObservableCollection<Path> _pases;
        private readonly Random _randomizer = new Random();
        #endregion

        #region Properties


        /// <summary>
        /// Next page
        /// </summary>
        public ICommand SelectNextPage
        {
            get
            {
                return _selectNextPage;
            }
        }

        /// <summary>
        /// Previous page
        /// </summary>
        public ICommand SelectPreviousPage
        {
            get
            {
                return _selectPreviousPage;
            }
        }


        /// <summary>
        /// Open last selected page
        /// </summary>
        public ICommand SelectLastOpenedPage
        {
            get
            {
                return _selectLastOpenedPage;
            }
        }

        /// <summary>
        /// Current page
        /// </summary>
        public SitePage SelectedPage
        {
            get
            {
                return _selectedPage;
            }
            set
            {
                if (_selectedPage == value) return;
                _lastOpenedPage = SelectedPage;

                _selectedPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Index selected element
        /// </summary>
        public int SelectedPageIndex
        {
            get
            {
                return Pages.IndexOf(SelectedPage);
            }
        }

        /// <summary>
        /// List of pages
        /// </summary>
        public ObservableCollection<SitePage> Pages
        {
            get
            {
                return _pages;
            }
        }

        /// <summary>
        /// Collection of passes
        /// </summary>
        public ObservableCollection<Path> Pases
        {
            get
            {
                return _pases;
            }
        }
        /// <summary>
        /// Conteiner of pages
        /// </summary>
        public SiteMap PagesPanel { get; set; }

        #endregion

        #endregion


        public SiteMap()
        {
            _pages = new ObservableCollection<SitePage>();
            _pases = new ObservableCollection<Path>();
        }

        #region public


        public void InitData(List<String> data)
        {
            if (data == null) return;
            if (data.Count == 0) return;

            Pages.Clear();
            foreach (var element in data)
            {
                Pages.Add(
                    new SitePage { PageUri = new Label 
                    { 
                        Content = element, 
                        Foreground = new SolidColorBrush(Colors.White), 
                        FontSize = 20, 
                        FontFamily = new FontFamily("SourceSansPro-Regular"), 
                        HorizontalAlignment = HorizontalAlignment.Center, 
                        VerticalAlignment = VerticalAlignment.Center,
                        MinWidth=260,
                        HorizontalContentAlignment= HorizontalAlignment.Center,
                        Margin = new Thickness(element.Length >= 13?0:12, 4, 0, 0),
                    } });
            }
            SelectedPage = Pages[0];
        }

        public void SelectLastOpenedPageAction(object param = null)
        {
            SelectedPage = _lastOpenedPage;
        }

        public void SelectNextPageAction(object param = null)
        {
            int index = Pages.IndexOf(SelectedPage) + 1;
            SelectedPage = index >= Pages.Count() ? Pages.FirstOrDefault() : Pages[index];


            SetColor();
        }

        public void SelectPreviousPageAction(object param = null)
        {
            int index = Pages.IndexOf(SelectedPage) - 1;
            SelectedPage = index <= -1 ? Pages.LastOrDefault() : Pages[index];
            SetColor();
        }

        public bool SetSelectedPage(Type neededType)
        {

            foreach (SitePage page in Pages.Where(page => page.PageUri.GetType() == neededType))
            {
                SelectedPage = page;
                return true;
            }
            return false;
        }

        public void SelectRandomPage()
        {
            if (Pages.Count == 0) return;

            SelectedPage = Pages[_randomizer.Next(Pages.Count)];
            SetColor();
        }

        public void SetColor()
        {
            if (Pases == null) return;
            if (Pases.Count == 0) return;
            for (int i = 0; i < Pases.Count; i++)
            {
                Pases[i].Fill = i == SelectedPageIndex ? ActiveBrush : InActiveBrush;
            }
        }
        #endregion


        #region ISupportInitialize


        public void BeginInit()
        {
        }

        public void EndInit()
        {
            SelectedPage = Pages.FirstOrDefault();
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


