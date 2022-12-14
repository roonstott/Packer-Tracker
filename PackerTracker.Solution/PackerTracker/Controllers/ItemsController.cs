using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PackerTracker.Models;

namespace PackerTracker.Controllers
{
    public class ItemsController : Controller
    {

      [HttpGet("/items")]
      public ActionResult Index()
      {
        List<Item> allItems = Item.GetAllItems();
        List<Item> packedItems = Item.GetPackedList();
        List<Item> shoppingList = Item.GetShoppingList();
        List<Item> [] array = {allItems, shoppingList, packedItems};
        return View(array);
      }

      [HttpGet("/items/new")]
      public ActionResult New()
      {
        return View();
      }
      [HttpPost("/items")]
      public ActionResult Create(string name)
      {
        Item newItem = new Item(name);
        return RedirectToAction("Index");
      }
      [HttpPost("/items/addToPackedList")]
      public ActionResult AddToPack(int id)
      { 
        Item.GetItem(id).AddToPackedList();
        return RedirectToAction("Index");
      }

      [HttpPost("/items/addToShoppingList")]
      public ActionResult AddToShop(int id)
      {
        Item.GetItem(id).AddToShopList();
        return RedirectToAction("Index");
      }
      [HttpPost("/items/remove")]
      public ActionResult Remove(int id)
      {
        Item.GetItem(id).RemoveFromShopList();
        return RedirectToAction("Index");
      }
      [HttpGet("/items/{id}")]
      public ActionResult Show(int id)
      {
        Item foundItem = Item.GetItem(id);
        return View(foundItem);
      }

    }
}