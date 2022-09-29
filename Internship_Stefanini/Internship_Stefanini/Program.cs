// In this console application I added 3 cooks, 9 ingredients and 4 dishes

// If you want to see how the app works till the end,
// you need to order 16 dishes: 15 dishes will be ordered successfully,
// but the 16th will not be ordered, because a cook can't be assigned with more than 5 dishes,
// and if we have 3 cooks, we cannot order more than 15 dishes at the same time

using System;
using System.Collections.Generic;

namespace Internship_Stefanini
{
     class Program
     {
          static void Main(string[] args)
          {
               var Cooks = new List<Cook>()
               {
                    // name
                    new Cook("Vasea"),
                    new Cook("Petru"),
                    new Cook("Andrei")
               };

               var Ingredients = new List<Ingredient>()
               {
                    // name, price
                    new Ingredient("Tomatoes", 2.50f),
                    new Ingredient("Meat", 5.75f),
                    new Ingredient("Cheese", 3.25f),
                    new Ingredient("Dough", 2.15f),
                    new Ingredient("Pasta", 2.30f),
                    new Ingredient("Sausage", 4.00f),
                    new Ingredient("Onion", 2.30f),
                    new Ingredient("Sauce", 1.50f),
                    new Ingredient("Bread", 1.75f)
               };

               var Dishes = new List<Dish>()
               {
                    // name, description, estimateCookingTime, ingredients
                    new Dish("Pizza", "Very tasty", 25, Ingredients[0], Ingredients[1], Ingredients[2], Ingredients[3], Ingredients[6], Ingredients[7]),
                    new Dish("Burger", "Better than McDonalds", 20, Ingredients[0], Ingredients[1], Ingredients[2], Ingredients[6], Ingredients[7], Ingredients[8]),
                    new Dish("Spaghetti", "Popular italian food", 15, Ingredients[1], Ingredients[4], Ingredients[7]),
                    new Dish("Hotdog", "It's not made from real dog :D", 10, Ingredients[5], Ingredients[7], Ingredients[8])
               };

               // <----show menu---->
               Console.WriteLine("<<<<Menu>>>>\n");

               for (int i = 0; i < Dishes.Count; i++)
               {
                    Console.WriteLine("Name: " + Dishes[i].name);
                    Console.WriteLine("Description: " + Dishes[i].description);

                    Console.Write("Ingredients: ");

                    for (int j = 0; j < Dishes[i].ingredients.Count; j++)
                    {
                         string temp = ", ";

                         // condition for not showing the ", " after the last ingredient of a dish
                         if (j == Dishes[i].ingredients.Count - 1)
                         {
                              temp = "";
                         }

                         Console.Write(Dishes[i].ingredients[j].name + temp);
                    }

                    Console.WriteLine("\nPretul: " + Math.Round(Dishes[i].price, 2) + "$");

                    // condition for not showing the "----" after the last dish
                    if (i < Dishes.Count - 1)
                    {
                         Console.WriteLine("----");
                    }
               }

               // <----order dish---->
               string nameOfDish;
               int leastNumberOfDishes = 0;
               int CookIndex = 0;

               while (true)
               {
                    Console.WriteLine("\n<<<<Order dish>>>>");

                    nameOfDish = Console.ReadLine();

                    // finding the cook with least number of dishes
                    for (int i = 0; i < Cooks.Count - 1; i++)
                    {
                         if (Cooks[i].numberOfDishes < Cooks[i + 1].numberOfDishes)
                         {
                              leastNumberOfDishes = Cooks[i].numberOfDishes;
                              CookIndex = i;
                         }
                         else if (Cooks[i].numberOfDishes > Cooks[i + 1].numberOfDishes)
                         {
                              leastNumberOfDishes = Cooks[i + 1].numberOfDishes;
                              CookIndex = i + 1;
                         }
                         else if (Cooks[i].numberOfDishes == Cooks[i + 1].numberOfDishes)
                         {
                              if (i == Cooks.Count - 2)
                              {
                                   leastNumberOfDishes = Cooks[i].numberOfDishes;
                                   CookIndex = i;
                              }
                              else
                              {
                                   continue;
                              }
                         }

                         break;
                    }

                    // condition when no cooks available
                    if (leastNumberOfDishes == 5)
                    {
                         Console.WriteLine("\nNo cooks available");
                         break;
                    }
                    else
                    {
                         // temp - temporary variable used for finding the case when ordered dish doesn't exist

                         // it tracks how many times the name of dish was not found in the list

                         // for example: if we have a list of 10 dishes, and we found the ordered dish,
                         // then the temp variable will be equal to 9, and the message "Such dish does't exist." will not be shown
                         // but if the ordered dish will not be found in the list, then the temp variable will be equal to 10,
                         // that is the number of dishes, so, we will see the message "Such dish does't exist."
                         int temp = 0;

                         // assignment of the ordered dish and increment the number of dishes to the cook
                         for (int i = 0; i < Dishes.Count; i++)
                         {
                              // using ToLower() allow users to introduce the name of dish in lower or upper case
                              if (nameOfDish.ToLower() == Dishes[i].name.ToLower())
                              {
                                   Cooks[CookIndex].dishes.Add(Dishes[i]);
                                   Cooks[CookIndex].numberOfDishes++;

                                   // calculate the estimate cooking finish time
                                   Cooks[CookIndex].estimateCookingFinishTime += Dishes[i].estimateCookingTime;

                                   Console.WriteLine("Estimate cooking finish time: " + Cooks[CookIndex].estimateCookingFinishTime + " minutes");
                              }
                              else
                              {
                                   if (temp == Dishes.Count - 1)
                                   {
                                        Console.WriteLine("Such dish does't exist.");
                                   }

                                   temp++;
                              }
                         }
                    }
               }

               Console.ReadKey();
          }
     }
}
