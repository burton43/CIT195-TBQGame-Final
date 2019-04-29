using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows;
using TBQuestGame.DataLayer;




namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        private Player _player;
        public string _messages;
        private Location[,] _gameMap;
        private Map _Map;
        private int _maxRows, _maxColumns;
        private GameMapCoordinates _currentLocationCoordinates;
        private Location _currentLocation;
        private Location _alphaLocation, _betaLocation, _gammaLocation, _deltaLocation;
        private GameItemQuantity _currentGameItem;


        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            
                get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged(nameof(MessageDisplay));
            }

        }

        public GameSessionViewModel()
        {

        }
        public Map Map
        {
            get { return _Map; }
            set { _Map = value; }
        }
        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// 
        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.RemoveGameItemQuantityFromLocation(selectedGameItemQuantity);
                _player.AddGameItemQuantityToInventory(selectedGameItemQuantity);

                
            }
        }


        /// <summary>
        /// travel east (beta)
        /// </summary>
        public void BetaTravel()
        {
            Location nextBetaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];
            if (HasBetaLocation && nextBetaLocation.Accessible == true)
            {
                _currentLocationCoordinates.Column++;
                CurrentLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column];
                UpdateAvailableTravelPoints();
                _player.GetFear += _currentLocation.FearPoints;
            }
            else
            {
                
                    MessageDisplay = "The way is blocked";
            }
        }

       

        /// <summary>
        /// travel west (delta)
        /// </summary>
        public void DeltaTravel()
        {
            Location nextDeltaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];
            if (HasDeltaLocation && nextDeltaLocation.Accessible == true)
            {
                _currentLocationCoordinates.Column--;
                CurrentLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column];
                UpdateAvailableTravelPoints();
                _player.GetFear += _currentLocation.FearPoints;
            }
            else
            {
                MessageDisplay = ("The way is blocked");
            }
        }

       

        public Location[,] GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        //
        // expose information about travel points from current location
        //
        public Location AlphaLocation
        {
            get { return _alphaLocation; }
            set
            {
                _alphaLocation = value;
                OnPropertyChanged(nameof(AlphaLocation));
                OnPropertyChanged(nameof(HasAlphaLocation));
            }
        }

        public Location BetaLocation
        {
            get { return _betaLocation; }
            set
            {
                _betaLocation = value;
                OnPropertyChanged(nameof(BetaLocation));
                OnPropertyChanged(nameof(HasBetaLocation));
            }
        }

        public Location GammaLocation
        {
            get { return _gammaLocation; }
            set
            {
                _gammaLocation = value;
                OnPropertyChanged(nameof(GammaLocation));
                OnPropertyChanged(nameof(HasGammaLocation));
            }
        }

        public Location DeltaLocation
        {
            get { return _deltaLocation; }
            set
            {
                _deltaLocation = value;
                OnPropertyChanged(nameof(DeltaLocation));
                OnPropertyChanged(nameof(HasDeltaLocation));
            }
        }

        public bool HasAlphaLocation { get { return AlphaLocation != null; } }
        public bool HasBetaLocation { get { return BetaLocation != null; } }
        public bool HasGammaLocation { get { return GammaLocation != null; } }
        public bool HasDeltaLocation { get { return DeltaLocation != null; } }

        private void UpdateAvailableTravelPoints()
        {
            //
            // reset travel location information
            //
            AlphaLocation = null;
            BetaLocation = null;
            GammaLocation = null;
            DeltaLocation = null;
            if (_currentLocationCoordinates.Column > 0)
            {
                Location nextDeltaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];
                if (nextDeltaLocation != null && nextDeltaLocation.GetReachable == true) // location exists
                {
                    DeltaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];
                }
            }


            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                Location nextBetaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];
                if (nextBetaLocation != null && nextBetaLocation.GetReachable == true) // location exists
                {
                    BetaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];
                }
            }
        }
        public GameSessionViewModel(
           Player player,
           string initialMessages,
           Location[,] gameMap,
            GameMapCoordinates currentLocationCoordinates)
        {
            _player = player;
            _messages = initialMessages;

            _gameMap = gameMap;
            _maxRows = _gameMap.GetLength(0);
            _maxColumns = _gameMap.GetLength(1);

            _currentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column];
            UpdateAvailableTravelPoints();
        }
        public void OnUseGameItem()
        {
            switch (_currentGameItem.GameItem)
            {
                case Items items:
                    ProcessItemsUse(items);
                    UpdateAvailableTravelPoints();
                    MessageDisplay = _currentGameItem.GameItem.UseMessage;
                    break;
                
                default:
                    break;
            }
        }
        private void ProcessItemsUse(Items items)
        {
            

            switch (items.UseAction)
            { 
                case Items.UseActionType.OPENLOCATION:
                    Location nextDeltaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];
                    Location nextBetaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];
                    if (HasDeltaLocation == true && nextDeltaLocation.GetID == 1)
                    { nextDeltaLocation.Accessible = true;
                        _currentLocationCoordinates.Column--;
                        UpdateAvailableTravelPoints();
                        CurrentLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column];
                    }

                    else if (HasBetaLocation == true && nextBetaLocation.GetID == 1)
                            {
                        nextBetaLocation.Accessible = true;
                        _currentLocationCoordinates.Column++;
                        UpdateAvailableTravelPoints();
                        CurrentLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column];
                    }
                        break;
                case Items.UseActionType.PRYOPEN:
                    Location nxtDeltaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];
                    Location nxtBetaLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];
                    if (HasDeltaLocation == true && nxtDeltaLocation.GetID == 12)
                    {
                        nxtDeltaLocation.Accessible = true;
                        _currentLocationCoordinates.Column--;
                        UpdateAvailableTravelPoints();
                        CurrentLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column];
                    }

                    else if (HasBetaLocation == true && nxtBetaLocation.GetID == 12)
                    {
                        nxtBetaLocation.Accessible = true;
                        _currentLocationCoordinates.Column++;
                        UpdateAvailableTravelPoints();
                        CurrentLocation = _gameMap[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column];
                    }
                    break;

                default:
                    break;
            }
        }
        private string _currentLocationInformation;
        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }
        public void OnPlayerTalkTo()
        {
            if (CurrentNpc != null && CurrentNpc is ISpeak)
            {
                ISpeak speakingNpc = CurrentNpc as ISpeak;
                speakingNpc.Speak();
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = GameData.GameItemById(4002);
                newGameItemQuantity.Quantity = 1;

                Player._inventory.Add(newGameItemQuantity);

                Player.Items.Clear();


                foreach (var gameItemQuantity in Player._inventory)
                {
                    if (gameItemQuantity.GameItem is Items) Player.Items.Add(gameItemQuantity);

                }
            }
        }
        public void OnPlayerLookAt()
        {
            if (CurrentNpc != null && CurrentNpc is ILook)
            {
                ILook viewedNpc = CurrentNpc as ILook;
                CurrentLocationInformation = viewedNpc.Look();
            }
        }
        private NPC _currentNpc;
        public NPC CurrentNpc
        {
            get { return _currentNpc; }
            set
            {
                _currentNpc = value;
                OnPropertyChanged(nameof(CurrentNpc));
            }
        }
    }
}
