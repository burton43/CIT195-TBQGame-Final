using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public abstract class GameItem
    {
        //
        // auto implemented properties are used for 
        //
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string UseMessage { get; set; }

        public string Information
        {
            get
            {
                return InformationString();
            }
        }

        public GameItem(int id, string name, string description, string useMessage = "")
        {
            Id = id;
            Name = name;
            
            Description = description;
            
            UseMessage = useMessage;
        }

        public abstract string InformationString();
    }
}
