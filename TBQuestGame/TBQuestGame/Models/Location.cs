using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Location
    {
        public string _name;

        public string GetName
        {
            get { return _name; }
            set { _name = value; }
        }

        public int _id;

        public int GetID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string _desc;

        public string GetDescription
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public bool _reach;

        public bool GetReachable
        {
            get { return _reach; }
            set { _reach = value; }
        }
        public int _fear;

        public int FearPoints
        {
            get { return _fear; }
            set { _fear = value; }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private ObservableCollection<GameItemQuantity> _gameItems;
        public ObservableCollection<GameItemQuantity> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }
        private bool _accessible;
        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }
        private int _requiredItemsId;
        public int RequiredItemsId
        {
            get { return _requiredItemsId; }
            set { _requiredItemsId = value; }
        }



        public void RemoveGameItemQuantityFromLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _gameItems.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateLocationGameItems();
        }
        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItemQuantity> updatedLocationGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (GameItemQuantity gameItemQuantity in _gameItems)
            {
                updatedLocationGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (GameItemQuantity gameItemQuantity in updatedLocationGameItems)
            {
                GameItems.Add(gameItemQuantity);
            }
        }
        private ObservableCollection<NPC> _npcs;
        public ObservableCollection<NPC> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }
        public void AddGameItemQuantityToLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
            
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _gameItems.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateLocationGameItems();
        }
    }

}
