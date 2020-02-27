namespace Model 
{
  public class Plant
  {
    public static int WaterLevel { get; set; } = 100;
    public static int SunLevel { get; set; } = 100;
    public static int FoodLevel { get; set;} = 100;
    public static void Drought()
    {
      WaterLevel -= 5;
    }

    public static void WindStorm()
    {
      FoodLevel -= 5;
    }

    public static void CloudyWeather()
    {
      SunLevel -= 5;
    }
    public static void WaterPlant()
    {
      WaterLevel += 10; 
    }
    public static void SunPlant()
    {
      SunLevel += 10;
    }
    public static void FeedPlant()
    {
      FoodLevel += 10;
    }
  }
}