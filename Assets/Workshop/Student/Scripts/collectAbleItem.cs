using UnityEngine;

namespace Solution
{
    public class CollectAbleItem : Identity
    {
        public override bool Hit()
        {
            Debug.Log("Item: " + Name + " has been picked up.");
            // ทำลายไอเท็มออกจากฉาก
            Destroy(gameObject);
            // mapGenerator.player.Inventory.AddItem(Name, 1); // เพิ่มไอเท็มลงในคลังของผู้เล่น
            return true;
        }
    }
}

