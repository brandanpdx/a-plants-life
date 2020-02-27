using System;
using Model;
using System.Threading;

public class Program
{
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
        else break;
      }
    }
  }

  public static void DecrementPlants()
  {
    bool alive = true;
    while(alive)
    {
      Console.Clear();
      Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");

      Drought();
      WindStorm();
      CloudyWeather();

      if(Plant.WaterLevel <= 0 || Plant.SunLevel <= 0 || Plant.FoodLevel <= 0)
      {
        alive = false;
        Console.WriteLine("Your Plant has died. You have a brown thumb...");
      }
      Thread.Sleep(3000);
    }
  }

// Good Actions
  public static void WaterPlant()
  {
    Plant.WaterLevel += 10; 
    Console.Clear();
    Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");
  }

  public static void OpenBlinds()
  {
    Plant.SunLevel += 10;
    Console.Clear();
    Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");
  }

  public static void FeedPlant()
  {
    Plant.FoodLevel += 10;
    Console.Clear();
    Console.WriteLine($"Plant Stats:\nFood Level [f]: {Plant.FoodLevel}\nWater Level [w]: {Plant.WaterLevel}\nSun Level [s]: {Plant.SunLevel}\ntype [q] to quit.");
  }

  // Bad Actions

  public static void Drought()
  {
    Plant.WaterLevel -= 5;
  }

  public static void WindStorm()
  {
    Plant.FoodLevel -= 5;
  }

  public static void CloudyWeather()
  {
    Plant.SunLevel -= 5;
  }
}