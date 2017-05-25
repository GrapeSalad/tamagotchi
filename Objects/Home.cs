using System.Collections.Generic;
namespace Tamagotchies.Objects
{
  public class TamagotchiHome
  {
    private static List<TamagotchiHome> _homes = new List<TamagotchiHome> {};
    private int _id;
    private string _homeName;
    private List<Tamagotchi> _pets;
    // private int _homeSize;

    public TamagotchiHome (string homeName)
    {
      _homeName = homeName;
      _homes.Add(this);
      _id = _homes.Count;
      _pets = new List<Tamagotchi>{};
    }

    public string GetHomeName()
    {
      return _homeName;
    }
    public int GetId()
    {
      return _id;
    }
    public List<Tamagotchi> GetTamagotchies()
    {
      return _pets;
    }
    public void AddTamagotchi(Tamagotchi pet)
    {
      _pets.Add(pet);
    }
    public static List<TamagotchiHome> GetAll()
    {
      return _homes;
    }
    public static void Clear()
    {
      _homes.Clear();
    }
    public static TamagotchiHome Find(int searchId)
    {
      return _homes[searchId-1];
    }

  }
}
