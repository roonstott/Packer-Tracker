using System;
using System.Collections.Generic;


namespace PackerTracker.Models
{
  public class Item
  {
    public string Name { get; set; }
    private static List<Item> _allItems = new List<Item> { };
    private static List<Item> _shoppingList = new List<Item> { };
    private static List<Item> _packed = new List<Item> { };

    public int Id { get; }
    public static int IdCounter = 1;

    public Item(string name) 
    {
      Id = IdCounter++;
      Name = name;
      _allItems.Add(this);
      
    }
    public static List<Item> GetAllItems()
    {
      return _allItems;
    }

    public static void ClearAll()
    {
      _allItems = new List<Item> {};
      _shoppingList = new List<Item> {};
      _packed = new List<Item> {};
      IdCounter = 1;
    }

    public List<Item> AddToShopList()
    {
      _shoppingList.Add(this);
      return _shoppingList;
    }
    public List<Item> RemoveFromShopList()
    {
      _shoppingList.Remove(this);
      return _shoppingList;
    }
    public static List<Item> GetShoppingList()
    {
      return _shoppingList;
    }

    public List<Item> AddToPackedList()
    {
      _packed.Add(this);
      return _packed;
    }
    public List<Item> RemoveFromPackedList()
    {
      _packed.Remove(this);
      return _packed;
    }
    public static List<Item> GetPackedList()
    {
      return _packed;
    }
    public static Item Find(int id)
    {
      for (int i = 0; i < _allItems.Count; i++)
      {
        if (_allItems[i].Id == id)
        {
          return _allItems[i];
        }
      }
      return _allItems[1];
    }
    public static int FindId(int id)
    {
      for (int i = 0; i < _allItems.Count; i++)
      {
        if (_allItems[i].Id == id)
        {
          return i;
        }
      }
      return -1;
    }
  }
}
// Item backback = new Item(backpack)
// backpack.AddToShopList(); 
// brainstorm session
// Item
// name
// price?
// packed or not packed
// shopping list
// all items list
// move to packed list when checked off