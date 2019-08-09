
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTheHero.Models
{
    public enum ActionType
    {
        Attack,
        Heal
    }
    class Action
    {
        public string NameOfAction { get; set; }
        public ActionType ActionType { get; set; }
    }
}
