using System.Collections.Generic;

namespace DojoLeague.Models
{
    public class NinjaIndex
    {
        public Ninja NewNinja {get;set;}
        public List<Ninja> Ninjas {get;set;}
        public List<Dojo> Dojos {get;set;}
        public NinjaIndex()
        {
            Ninjas = new List<Ninja>();
            Dojos = new List<Dojo>();
        }
    }
    public class DojoIndex
    {
        public Dojo NewDojo {get;set;}
        public List<Dojo> Dojos {get;set;}
        public DojoIndex()
        {
            Dojos = new List<Dojo>();
        }
    }
    public class ShowDojo
    {
        public Dojo Dojo {get;set;}
        public List<Ninja> RogueNinjas {get;set;}
    }
}