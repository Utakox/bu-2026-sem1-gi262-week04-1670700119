using System.Collections.Generic;
using UnityEngine;

namespace Solution {
    public class Inventory : MonoBehaviour
    {
        public Dictionary<string, int> inventory = new Dictionary<string, int>();

        // เพิ่มไอเท็ม
        public void AddItem(string item, int amount)
        {
            // 1. ตรวจสอบว่ามีไอเท็มนี้ในคลังแล้วหรือยัง
            if (inventory.ContainsKey(item))
            {
                inventory[item] += amount; // เพิ่มจำนวนไอเท็มที่มีอยู่แล้ว
            }
            else
            {
                inventory.Add(item, amount); // เพิ่มไอเท็มใหม่
            }
           

            Debug.Log("Added " + amount + " " + item + ". Total: " + inventory[item]);
        }

        // ลบไอเท็ม
        public void RemoveItem(string item, int amount)
        {
            //4. ตรวจสอบว่ามีไอเท็มนี้ในคลังหรือไม่

            if (inventory.ContainsKey(item))
            {
                if (inventory[item] >= amount)
                {
                    inventory[item] -= amount; // ลบจำนวนไอเท็มที่ต้องการ
                }
                else
                {
                    Debug.Log("Not enough " + item + " to remove. Current amount: " + inventory[item]);
                }
            }
            
        }
        public bool HasItem(string item, int amount)
        {
            //2. ตรวจสอบว่ามีไอเท็มนี้ในคลังหรือไม่ และมีจำนวนเพียงพอหรือไม่
            if (inventory.ContainsKey(item) && inventory[item] >= amount)
            {
                return true; // มีไอเท็มและจำนวนเพียงพอ
           }
           
            return false; // ไม่มีไอเท็มหรือจำนวนไม่เพียงพอ
            
        }
        // ตรวจสอบจำนวนไอเท็ม
        public int GetItemCount(string item)
        {
            //3. ตรวจสอบว่ามีไอเท็มนี้ในคลังหรือไม่ ถ้ามีให้คืนค่าจำนวนไอเท็มนั้น
            if (inventory.ContainsKey(item))
            {
                return inventory[item];
            }

            else
            {
              return 0; // ถ้าไม่มีไอเท็มนี้ในคลัง ให้คืนค่าเป็น 0 
            }
        }

        // แสดงรายการทั้งหมดในคลัง
        public void PrintInventory()
        {
            Debug.Log("--- Inventory Content ---");
            if (inventory.Count == 0)
            {
                Debug.Log("Inventory is empty.");
                return;
            }

            foreach (var itemEntry in inventory)
            {
                Debug.Log(itemEntry.Key + ": " + itemEntry.Value);
            }
        }
    }
}

