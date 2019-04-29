using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public abstract class NPC : Character
    {
        public string Description { get; set; }
        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }

        public NPC()
        {

        }

        public NPC(string name, int id,  string description)
            : base(name, id)
        {
            GetID = id;
            GetName = name;
            
            Description = description;
        }

        protected abstract string InformationText();
    }
}
