using System;
using Model;
using System.Threading;

public class Program
{
    public static string[] plantAscii = {@"
         ,
     /\^/`\
    | \/   |
    | |    |
    \ \    /
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
       | |    |
       \ \    /
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
        if (keyInfo.Key == ConsoleKey.W) WaterPlant();
        else if (keyInfo.Key == ConsoleKey.F) FeedPlant();
        else if (keyInfo.Key == ConsoleKey.S) OpenBlinds();
        else if (keyInfo.Key == ConsoleKey.Q) Environment.Exit(0);  
      }
    }
  }

  public static void DecrementPlants()
  {
    int plantIndex = 0;
    bool alive = true;
    while(alive)
    {
      Console.Clear();
      Console.WriteLine(plantAscii[plantIndex]);
      if(plantIndex == 0)
      {
        plantIndex = 1;
      }
      else
      {
        plantIndex = 0;
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
  public static void WaterPlant()
  {
    Plant.WaterPlant();
    Console.Clear();
    Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");
  }

  public static void OpenBlinds()
  {
    Plant.SunPlant();
    Console.Clear();
    Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");
  }

  public static void FeedPlant()
  {
    Plant.FeedPlant();
    Console.Clear();
    Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");
  }
}