using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

using App4CD.Core.Models;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App4CD.Views
{
    public sealed partial class MasterCDPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Cd> _source;
        private CdContext context = new CdContext();
        public ObservableCollection<Cd> Source {
            get => _source;
            set => Set(ref _source, value);
        }

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on MasterCDPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public MasterCDPage()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            _source = new ObservableCollection<Cd>(context.Cd.ToList());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
