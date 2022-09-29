namespace Internship_Stefanini
{
     public class Ingredient
     {
          public string name { get; set; }
          public float price { get; set; }

          public Ingredient(string name, float price)
          {
               this.name = name;
               this.price = price;
          }
     }
}
