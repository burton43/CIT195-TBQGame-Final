using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    class Habitants : NPC, ISpeak, ILook
    {
        Random r = new Random();

        public ObservableCollection<GameItemQuantity> Messages { get; set; }
        public List<string> Sights { get; set; }

        protected override string InformationText()
        {
            return $"{GetName} - {Description}";
        }

        public Habitants()
        {

        }

        public Habitants(int id, string name, string description, ObservableCollection<GameItemQuantity> messages, List<string> sights)
            : base(name, id,  description)
        {
            Messages = messages;
            Sights = sights;
        }

        /// <summary>
        /// generate a message or use default
        /// </summary>
        /// <returns>message text</returns>
        public GameItemQuantity Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return GetMessage();
            }

            
        }
        public string Look()
        {
            if (this.Sights != null)
            {
                return GetSights();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        private GameItemQuantity GetMessage()
        {
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
        private string GetSights()
        {
            int sightIndex = r.Next(0, Sights.Count());
            return Sights[sightIndex];
        }
    }
}
