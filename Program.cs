using System;
using Model;
using System.Threading;

public class Program
{
    public static string[] plantAscii = {@"
         ,
     /\^/`\
    | \/   |
    | |. . |
    \ \ v  /
     '\\//'
       ||
       ||
       ||
       ||  ,
   |\  ||  |\
   | | ||  | |
   | | || / /
    \ \||/ /
     `\\//`
    ^^^^^^^^",@"
            ,
        /\^/`\
       | \/   |
       | | ^ ^|
       \ \  - /
       '\\//'
         //
        //
       ||
       ||  ,
   |\  ||  |\
   | | ||  | |
   | | || / /
    \ \||/ /
     `\\//`
    ^^^^^^^^", @"

             ,
         /\^/`\
        | \/   |  ___________________
        | |^ ^ | |                   |
        \ \ O /  |      OH YOU!      |
        '\\//'   |                   |
          //     |  -----------------
         //      / /
        //       /
   |\  ||   __
   | | ||  / \|
   | | || / /
    \ \||/ /
     `\\//`
    ^^^^^^^^"};
  public static void Main()
  {
    Thread ta = new Thread(new ThreadStart(DecrementPlants));
    Thread tb = new Thread(new ThreadStart(Controller));
    Plant.WaterLevel = 100;
    Plant.SunLevel = 100;
    Plant.FoodLevel = 100;
    ta.Start();
    tb.Start();
  }
  public static void Controller()
  {
    while(true)
    {
      if (Console.KeyAvailable)
      {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.W) HelpPlant("water");
        else if (keyInfo.Key == ConsoleKey.F) HelpPlant("feed");
        else if (keyInfo.Key == ConsoleKey.S) HelpPlant("sun");
        else if (keyInfo.Key == ConsoleKey.Q) Environment.Exit(0);  
      }
    }
  }

  public static void DecrementPlants()
  {
    Plant.PlantIndex = 0;
    bool alive = true;
    while(alive)
    {
      Console.Clear();
      Console.WriteLine(plantAscii[Plant.PlantIndex]);
      if(Plant.PlantIndex < 2)
      {
        Plant.PlantIndex++;
      }
      else
      {
        Plant.PlantIndex = 0;
      }
      Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");

      Plant.Drought();
      Plant.WindStorm();
      Plant.CloudyWeather();

      if(Plant.WaterLevel <= 0 || Plant.SunLevel <= 0 || Plant.FoodLevel <= 0)
      {
        Console.Clear();
        Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");
        alive = false;
        Console.WriteLine("Your Plant has died. You have a brown thumb...");
        Environment.Exit(0);
      }
      Thread.Sleep(1000);
    }
  }

// Good Actions
  public static void HelpPlant(string action)
  {
    if(action == "water")
    {
      Plant.WaterPlant();
    }
    else if(action == "feed")
    {
      Plant.FeedPlant();
    }
    else if(action == "sun")
    {
      Plant.SunPlant();
    }
    Console.Clear();
    Console.WriteLine(plantAscii[Plant.PlantIndex]);
    Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");
  }
}