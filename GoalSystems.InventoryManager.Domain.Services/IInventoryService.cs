using System;
using System.Collections.Generic;
using GoalSystems.InventoryManager.Domain.Entities;

namespace GoalSystems.InventoryManager.Domain.Services
{
    public interface IInventoryService: IDisposable
    {
        event Notify ElementExpired;
        event Notify ElementRemoved;
        Element AddElement(Element e);
        IEnumerable<Element> GetAll();
        Element GetElementByName(string name);
        void RemoveElement(Element e);
        void RemoveElement(string name);
    }
}