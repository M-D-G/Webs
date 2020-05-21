using NarushPDD.ApplicationServices.GetRoadPDDListUseCase;
using NarushPDD.ApplicationServices.Ports;
using NarushPDD.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NarushPDD.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetRoadPDDListUseCase _getRoadPDDListUseCase;

        public MainViewModel(IGetRoadPDDListUseCase getRoadPDDListUseCase)
            => _getRoadPDDListUseCase = getRoadPDDListUseCase;

        private Task<bool> _loadingTask;
        private RoadPDD _currentRoadPDD;
        private ObservableCollection<RoadPDD> _roadpdds;

        public event PropertyChangedEventHandler PropertyChanged;

        public RoadPDD CurrentRoadPDD
        {
            get => _currentRoadPDD; 
            set
            {
                if (_currentRoadPDD != value)
                {
                    _currentRoadPDD = value;
                    OnPropertyChanged(nameof(CurrentRoadPDD));
                }
            }
        }

        private async Task<bool> LoadRoadPDDs()
        {
            var outputPort = new OutputPort();
            bool result = await _getRoadPDDListUseCase.Handle(GetRoadPDDListUseCaseRequest.CreateAllRoadPDDsRequest(), outputPort);
            if (result)
            {
                RoadPDDs = new ObservableCollection<RoadPDD>(outputPort.RoadPDDs);
            }
            return result;
        }

        public ObservableCollection<RoadPDD> RoadPDDs
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadRoadPDDs();
                }
                
                return _roadpdds; 
            }
            set
            {
                if (_roadpdds != value)
                {
                    _roadpdds = value;
                    OnPropertyChanged(nameof(RoadPDDs));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetRoadPDDListUseCaseResponse>
        {
            public IEnumerable<RoadPDD> RoadPDDs { get; private set; }

            public void Handle(GetRoadPDDListUseCaseResponse response)
            {
                if (response.Success)
                {
                    RoadPDDs = new ObservableCollection<RoadPDD>(response.RoadPDDs);
                }
            }
        }
    }
}
