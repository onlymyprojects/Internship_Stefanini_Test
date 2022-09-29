using System.Collections.Generic;

namespace Internship_Stefanini
{
     public class Dish
     {
          public string name { get; set; }
          public string description { get; set; }
          public float price { get; set; } = 0;
          public int estimateCookingTime { get; set; }
          public List<Ingredient> ingredients { get; set; } = new List<Ingredient>();

          public Dish(string name, string description, int estimateCookingTime, params Ingredient[] ingredients)
          {
               this.name = name;
               this.description = description;
               this.estimateCookingTime = estimateCookingTime;

               for (int i = 0; i < ingredients.Length; i++)
               {
                    this.ingredients.Add(ingredients[i]);
               }
               
               // sum of all ingredients
               for (int i = 0; i < this.ingredients.Count; i++)
               {
                    price += ingredients[i].price;
               }

               // sum of all ingredients + 20%
               price = price * 1.2f;
          }
     }
}
