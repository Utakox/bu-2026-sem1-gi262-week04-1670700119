using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            // LCT01_SyntaxList();
            // LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
            LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_SyntaxLinkedList()
        {
            LinkedList<string> linkedlist = new LinkedList<string>();
            linkedlist.AddLast("Node 1");

            linkedlist.AddLast("Node 2");

            linkedlist.AddFirst("Node 0");

            LinkedListNode<string> node1 = linkedlist.Find("Node 1");
            Debug.Log(node1.Value); // 1
            Debug.Log(node1.Previous.Value); // 0
            Debug.Log(node1.Next.Value); // 2

            var firsstNode = linkedlist.First;
            var lastNode = linkedlist.Last;
            Debug.Log(firsstNode.Next); // 0
            Debug.Log(lastNode.Next); // 2

            linkedlist.AddAfter(node1, "Node 1.5");

            linkedlist.AddBefore(node1, "Node 0.5");

            linkedlist.RemoveFirst();
            linkedlist.RemoveLast();
            linkedlist.Remove("Node 1.5");

            linkedlist.Clear(); // null

            Debug.Log("--------------------");

            foreach (var item in linkedlist)
            {
                Debug.Log(item);
            }

            
        }

        public void LCT03_SyntaxHashTable()
        {
            // Hashtable table = new Hashtable();
            // table.Add("Potion", 5);
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<string, int> inventory = new Dictionary<string, int>();
            // var inventory = new Dictionary<string, int>();

            inventory.Add("Potion", 5);
            inventory.Add("Banana", 1);
            inventory.Add("Apple", 10);

            inventory["Potion"] = 10; // update value
            inventory["Banana"] = 2; // update value
            inventory["Apple"] = 15; // update value

            inventory.Add("Apple1", 15); // add new value incase of typing error

            int potion = inventory["Potion"];
            Debug.Log("potion: " + potion);

            // if อ้างอิง key ที่ไม่มีใน dictionary จะเกิด error
            int test = inventory["Potion1"];

            // ตรวจสอบว่ามี key อยู่ใน dictionary หรือไม่
            bool hasPotion = inventory.ContainsKey("Potion");
            Debug.Log("hasPotion: " + hasPotion);  
            
            inventory.Remove("Potion");

            foreach (KeyValuePair<string, int> item in inventory)
            {
                var key = item.Key;
                var value = item.Value;
                Debug.Log(key + ": " + value);
                
            }

            inventory.Clear(); // null
        }

        #endregion
    }
}
