using System;
using System.Collections.Generic;
using Nancy;
using Tamagotchies.Objects;

namespace Tamagotchies
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/homes"] = _ => {
        List<TamagotchiHome> home = TamagotchiHome.GetAll();
        return View["homes.cshtml", home];
      };
      Get["/homes/new"] = _ => {
        return View["home_form.cshtml"];
      };
      Post["/create_home"] = _ => {
        TamagotchiHome newHome = new TamagotchiHome(Request.Form["home-name"]);
        List<TamagotchiHome> home = TamagotchiHome.GetAll();
        return View["homes.cshtml", home];
      };
      Get["/homes/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedHome = TamagotchiHome.Find(parameters.id);
        var homePets = selectedHome.GetTamagotchies();
        List<Tamagotchi> allPets = Tamagotchi.GetAllPets();
        model.Add("home", selectedHome);
        model.Add("pets", allPets);
        Console.WriteLine(homePets.Count);
        //THERE ARE NO TAMAGOTCHIES IN THE HOME, WHY?
        return View["home.cshtml", model];
      };
      Get["/homes/{id}/pets"] = parameters => {
        List<Tamagotchi> allPets = Tamagotchi.GetAllPets();
        return View["show_home_pets.cshtml", allPets];
      };
      Get["/homes/{id}/pets/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        TamagotchiHome selectedHome = TamagotchiHome.Find(parameters.id);
        List<Tamagotchi> allPets = selectedHome.GetTamagotchies();
        model.Add("home", selectedHome);
        model.Add("pets", allPets);
        return View["add_pet.cshtml", model];
      };
      Post["/add_pet"] = _ => {
        Tamagotchi pet = new Tamagotchi(Request.Form["TamagotchiName"]);
        List<Tamagotchi> allPets = Tamagotchi.GetAllPets();
        return View["show_home_pets.cshtml", allPets];
      };
      Get["/show_home_pets"] = _ => {
        List<Tamagotchi> allPets = Tamagotchi.GetAllPets();
        return View["show_home_pets.cshtml", allPets];
      };
      Get["/pet_care"] = _ => View["pet_care.cshtml"];

      Post["/show_pet"] = _ =>{
        Tamagotchi pet = Tamagotchi.GetPet();
        pet.TakeCare(Request.Form["care"]);
        pet.Death();
        return View["show_tamagotchi.cshtml", pet];
      };
      Get["/show_pet"] = _ => {
        Tamagotchi pet = Tamagotchi.GetPet();
        return View["show_tamagotchi.cshtml", pet];
      };
    }
  }
}
