namespace MVC
{
    public class Dojodachi
    {
        public int Happiness {get;set;}
        public int Fullness {get;set;}
        public int Energy {get;set;}
        public int Meals {get;set;}

        public Dojodachi()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
        }
    }
}