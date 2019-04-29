using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Map
    {
        private Location[,] _locations;
        private int _maxRows, _maxColumns;

        public Location[,] GetLocations
        {
            get { return _locations; }
            set { _locations = value; }
        }
        

        private Location _currentLocation;

        public Location CurrentLocations
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }
        private List<GameItem> _standardGameItems;
        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }

        public Map(int rows, int columns)
        {
            _maxRows = rows;
            _maxColumns = columns;
            _locations = new Location[rows, columns];
        }
        public GameItem GameItemById(int gameItemId)
        {
            return StandardGameItems.FirstOrDefault(i => i.Id == gameItemId);
        }
        public string OpenLocationsByItems(int itemId)
        {
            string message = "The relic did nothing.";
            Location mapLocation = new Location();

            for (int row = 0; row < _maxRows; row++)
            {
                for (int column = 0; column < _maxColumns; column++)
                {
                    mapLocation = _locations[row, column];

                    if (mapLocation != null && mapLocation.RequiredItemsId == itemId)
                    {
                        mapLocation.GetReachable = true;
                        message = $"{mapLocation.GetName} is now accessible.";
                    }
                }
            }

            return message;
        }
    }

}
