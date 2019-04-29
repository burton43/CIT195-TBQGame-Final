using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    interface ILook
    {
        List<string> Sights { get; set; }

        string Look();
    }
}
