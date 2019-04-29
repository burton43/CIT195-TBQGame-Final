using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Items : GameItem
    {
        public enum UseActionType
        {
            OPENLOCATION,
            PRYOPEN,
            HACKDOWN,
            PUTIN
        }

        public UseActionType UseAction { get; set; }

        public Items(int id, string name, string description, string useMessage, UseActionType useAction)
            : base(id, name,  description,  useMessage)
        {
            UseAction = useAction;
            UseMessage = useMessage;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}";
        }
    }
}
