using System;
using System.Collections.Generic;

namespace Hungry_Ninja
{

class Buffet
{
    public List<Food> Menu;
    
    
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Lobster", 1000, false, false),
            new Food("Chicken Wings", 300, true, false),
            new Food("Sushi", 400, false, false),
            new Food("Bacon", 600, false, false),
            new Food("Pasta", 300, true, false),
            new Food("Shrimp", 500, false, true),
            new Food("Cheesecake", 900, false, true)
        };
    }
    
    public Food Serve()
    {
        Random random = new Random();
        int randFood = random.Next(Menu.Count);
        return Menu[randFood];
    }
}



    
}





