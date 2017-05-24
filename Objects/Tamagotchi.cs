using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tamagotchi.Objects
{
  //TRY INHERITED CLASSES???????
  public class TamagotchiCat
  {
    private static List<TamagotchiCat> _pets = new List<TamagotchiCat> {};
    private string _name;
    private int _hungry;
    private int _sleepy;
    private int _happy;
    private int _size;
    private bool _alive;


    public TamagotchiCat(string name)
    {
      _name = name;
      _hungry = 5;
      _sleepy = 5;
      _happy = 5;
      _size = 0;
      _alive = true;
      _pets.Add(this);
    }
    public static TamagotchiCat GetPet()
    {
      return _pets[0];
    }
    public void SetName(string name)
    {
      _name = name;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetHungry(int hungry)
    {
      _hungry = hungry;
    }
    public int GetHungry()
    {
      return _hungry;
    }
    public void SetSleepy(int sleepy)
    {
      _sleepy = sleepy;
    }
    public int GetSleepy()
    {
      return _sleepy;
    }
    public void SetHappy(int happy)
    {
      _happy = happy;
    }
    public int GetHappy()
    {
      return _happy;
    }
    public void SetSize(int size)
    {
      _size = size;
    }
    public int GetSize()
    {
      return _size;
    }
    // public TamagotchiCat GetPet()
    // {
    //   return this;
    // }
    public void TakeCare (string name)
    {
    // Debugger.Log(1, "help", "whydoesntthiswork");
      if (name[0] == 'f') {
        Console.WriteLine("Hunger Level: + " + _hungry);
        _hungry -= (int)Char.GetNumericValue(name[2]);
        _happy--;
        _sleepy++;
      } else if (name[0] == 's') {
        Console.WriteLine("Sleepy Level: + " + _sleepy);
        _sleepy -= (int)Char.GetNumericValue(name[2]);
        _hungry++;
        _happy--;
      } else if (name[0] == 'h') {
        Console.WriteLine("Happy Level: + " + _happy);
        _happy += (int)Char.GetNumericValue(name[2]);
        _sleepy++;
        _hungry++;
      } else {
        _happy--;
        _hungry++;
        _sleepy++;
      }
    }
    public void Death()
    {
      if ((_happy <= 0) || (_sleepy >= 10) || (_hungry >= 10)) {
        _alive =  false;
      }
      else{
        _alive = true;
      }
    }
    public bool GetAlive()
    {
      return _alive;
    }
  }
}
