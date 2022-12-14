using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackerTracker.Models;
using System;
using System.Collections.Generic;

namespace PackerTracker.Tests
{
  [TestClass]
  public class ItemTests : IDisposable
  {

    public void Dispose()
    {
      Item.ClearAll();
    }

    [TestMethod]
    public void ItemConstructor_InstancesOfItemWithProperties_ItemProperty()
    {
      Item newItem = new Item("backpack");
      Assert.AreEqual("backpack", newItem.Name);
    }
    [TestMethod]
    public void GetAllItems_ReturnsItems_ItemList()
    {
      Item newItem1 = new Item("backpack");
      Item newItem2 = new Item("flashlight");
      List<Item> allItemsList = new List<Item> { newItem1, newItem2 };
      List<Item> methodTestList = Item.GetAllItems();
      CollectionAssert.AreEqual(methodTestList, allItemsList);
    }
    [TestMethod]
    public void AddToShopList_AddsItemToShoppingList_ShoppingList()
    {
      Item newItem1 = new Item("backpack");
      List<Item> result = newItem1.AddToShopList();
      List<Item> expected = new List<Item> { newItem1 };
      CollectionAssert.AreEqual(expected, result);
    }
    [TestMethod]
    public void RemoveFromShopList_RemovesItem_ShoppingList()
    {
      Item newItem1 = new Item("backpack");
      Item newItem2 = new Item("flashlight");
      newItem1.AddToShopList();
      newItem2.AddToShopList();
      List<Item> expected = new List<Item> { newItem2 };
      List<Item> result = newItem1.RemoveFromShopList();
      CollectionAssert.AreEqual(expected, result);
    }
    [TestMethod]
    public void GetShoppingList_ReturnsItems_ItemList()
    {
      Item newItem1 = new Item("backpack");
      Item newItem2 = new Item("flashlight");
      newItem1.AddToShopList();
      newItem2.AddToShopList();
      List<Item> expected = new List<Item> { newItem1, newItem2 };
      List<Item> result = Item.GetShoppingList();
      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void PackedList_AddsRemovesAndGetsPackedListItems_ItemList()
    {
      Item newItem1 = new Item("backpack");
      Item newItem2 = new Item("flashlight");
      Item newItem3 = new Item("stereo");
      newItem1.AddToPackedList();
      newItem2.AddToPackedList();
      newItem3.AddToPackedList();
      int result1 = Item.GetPackedList().Count;
      int expected1 = 3;
      List<Item> result2 = newItem3.RemoveFromPackedList();
      List<Item> expected2 = new List<Item> { newItem1, newItem2 };    
      Assert.AreEqual(expected1, result1);
      CollectionAssert.AreEqual(expected2, result2);
    }
    [TestMethod]
    public void GetId_ReturnsId_Int()
    {
      Item newItem1 = new Item("backpack");
      Item newItem2 = new Item("flashlight");
      int result1 = newItem1.Id;
      int result2 = newItem2.Id;
      Assert.AreEqual(1, result1);
      Assert.AreEqual(2, result2);
    }
  }
}
