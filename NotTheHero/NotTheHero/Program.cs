using NotTheHero.Controller;
using System;

namespace NotTheHero
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameController gc = new GameController();
            gc.InitForTest();
            gc.EnterDungeonRoom();
            //When we go back to a gui, go into properties and change the output type and startup object
        }
    }
}
