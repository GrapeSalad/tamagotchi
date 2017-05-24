using System;
using Nancy;
using Tamagotchi.Objects;

namespace Tamagotchi
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Post["/"] = _ => {
        TamagotchiCat cat = new TamagotchiCat(Request.Form["TamagotchiName"]);
        return View["show_tamagotchi.cshtml", cat];
      };
      Get["/pet_care"] = _ => View["pet_care.cshtml"];
      Post["/show_pet"] = _ =>{
        TamagotchiCat cat = TamagotchiCat.GetPet();
        cat.TakeCare(Request.Form["care"]);
        return View["show_tamagotchi.cshtml", cat];
      };
      Get["/show_pet"] = _ => {
        TamagotchiCat cat = TamagotchiCat.GetPet();
        return View["show_tamagotchi.cshtml", cat];
      };
    }
  }
}
