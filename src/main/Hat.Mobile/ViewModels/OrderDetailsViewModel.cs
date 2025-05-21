using CommunityToolkit.Maui.Core.Extensions;
using Hat.Domain.Repositories;
using Hat.Model;
using Hat.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
  
    public class OrderDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<TrackOrderModel> _TrackData = [];
        public ObservableCollection<TrackOrderModel> TrackData
        {
            get => _TrackData;
            set => SetProperty(ref _TrackData, value);
        }

        private bool _IsLoaded;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand BackCommand { get; }
        public ICommand SelectOrderCommand { get; }

        private readonly ITrackRepository _trackRepository;
        public OrderDetailsViewModel(bool emptyGroups = false, ITrackRepository trackRepository = null)
        {
            BackCommand = new Command<object>(GoBack);
            SelectOrderCommand = new Command<object>(TrackCommand);
            _ = InitializeAsync();
            _trackRepository = trackRepository;
        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        private async void TrackCommand(object obj)
        {
           // await MauiApp.Current.MainPage.Navigation.PushAsync(new TrackOrderView((TrackViewModel)obj));
        }
        private async void GoBack(object obj)
        {
            await MauiApp.Current.MainPage.Navigation.PopModalAsync();
        }
        async Task PopulateDataAsync()
        {
            var storedTracks= await _trackRepository.GetTracks();
            var tracks= storedTracks.Select(x=> new TrackViewModel(x)).ToList();
            TrackData = storedTracks.Select(x => new TrackOrderModel("Sept 23", tracks)).ToObservableCollection();
            IsLoaded = true;
        }

    }
}
