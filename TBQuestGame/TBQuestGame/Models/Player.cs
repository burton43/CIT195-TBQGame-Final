using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        public bool _scared;

        public bool GetScared
        {
            get { return _scared; }
            set { _scared = value;
                OnPropertyChanged(nameof(GetScared));
            }
        }

        public int _fear;

        public int GetFear
        {
            get { return _fear; }
            set
            {
                _fear = value;
                OnPropertyChanged(nameof(GetFear));
            }
        }
        public ObservableCollection<GameItemQuantity> _inventory;
        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        private ObservableCollection<GameItemQuantity> _items;
        public ObservableCollection<GameItemQuantity> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public Player()
        {
            _inventory = new ObservableCollection<GameItemQuantity>();
            _items = new ObservableCollection<GameItemQuantity>();
        }


        public override string Greeting()
        {
            

            return $"My name is {_name} and I don't remember how I got here.";
        }
        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventoryCategories();
        }
        public void UpdateInventoryCategories()
        {
            Items.Clear();
            

            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity.GameItem is Items) Items.Add(gameItemQuantity);
                
            }
        }

    }
}
