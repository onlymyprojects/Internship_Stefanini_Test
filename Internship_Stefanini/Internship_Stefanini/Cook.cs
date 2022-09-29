using System.Collections.Generic;

namespace Internship_Stefanini
{
     public class Cook
     {
          private string _name;
          public int numberOfDishes { get; set; } = 0;
          public List<Dish> dishes { get; set; } = new List<Dish>();
          public int estimateCookingFinishTime { get; set; } = 0;

     public Cook(string name)
          {
               _name = name;
          }
     }
}
