using Bridges.ApplicationServices.GetBridgesPointListUseCase;
using Bridges.ApplicationServices.Ports;
using Bridges.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Bridges.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetBridgesPointListUseCase _getBridgesPointListUseCase;

        public MainViewModel(IGetBridgesPointListUseCase getBridgesPointListUseCase)
            => _getBridgesPointListUseCase = getBridgesPointListUseCase;

        private Task<bool> _loadingTask;
        private BridgesPoint _currentBridgesPoint;
        private ObservableCollection<BridgesPoint> _bridgespoints;

        public event PropertyChangedEventHandler PropertyChanged;

        public BridgesPoint CurrentBridgesPoint
        {
            get => _currentBridgesPoint; 
            set
            {
                if (_currentBridgesPoint != value)
                {
                    _currentBridgesPoint = value;
                    OnPropertyChanged(nameof(CurrentBridgesPoint));
                }
            }
        }

        private async Task<bool> LoadBridgesPoints()
        {
            var outputPort = new OutputPort();
            bool result = await _getBridgesPointListUseCase.Handle(GetBridgesPointListUseCaseRequest.CreateAllBridgesPointsRequest(), outputPort);
            if (result)
            {
                BridgesPoints = new ObservableCollection<BridgesPoint>(outputPort.BridgesPoints);
            }
            return result;
        }

        public ObservableCollection<BridgesPoint> BridgesPoints
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadBridgesPoints();
                }
                
                return _bridgespoints; 
            }
            set
            {
                if (_bridgespoints != value)
                {
                    _bridgespoints = value;
                    OnPropertyChanged(nameof(BridgesPoints));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetBridgesPointListUseCaseResponse>
        {
            public IEnumerable<BridgesPoint> BridgesPoints { get; private set; }

            public void Handle(GetBridgesPointListUseCaseResponse response)
            {
                if (response.Success)
                {
                    BridgesPoints = new ObservableCollection<BridgesPoint>(response.BridgesPoints);
                }
            }
        }
    }
}
