using System;
using System.Collections.Generic;

namespace Hungry_Ninja
{
    class Ninja
{
    private int CalorieIntake { get; set; }
    
    public List<Food> FoodHistory;

    public Ninja()
    {
        CalorieIntake = 0;
        FoodHistory = new List<Food>();
        
    }

    public bool IsFull
    {
        get
        {
            if (this.CalorieIntake > 1200)
            {
                Console.WriteLine("Is FULL");
                return true;
            }
            else 
            {
                Console.WriteLine("Still Hungry");
                return false;
            }
        }
    }

    
    
    public void Eat(Food item)
    {
        if (!IsFull)
        {
        CalorieIntake += item.Calories;
        FoodHistory.Add(item);
        Console.WriteLine($"You just ate {item.Name} and it has {item.Calories} calories");
        Console.WriteLine($"You've eaten {this.CalorieIntake}");
        }

        else
        {
            Console.WriteLine("You ate too much!");
        }
    }


}


}