using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            if (words != null)
            {
                foreach (string word in words)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount[word] = 1;
                    }
                }
            }
           
            
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            
            // 1. สร้าง Dictionary ว่างสำหรับเก็บตัวเลขและจำนวนครั้งที่พบ
            Dictionary<int, int> numberCount = new Dictionary<int, int>();

            // ตรวจสอบว่า array ไม่เป็น null
            if (numbers != null)
            {
                // 2. วนลูปผ่านตัวเลขแต่ละตัว
                foreach (int number in numbers)
                {
                    // 3 & 4. ตรวจสอบว่ามีตัวเลขนี้ใน Dictionary แล้วหรือยัง
                    if (numberCount.ContainsKey(number))
                    {
                        numberCount[number]++; // ถ้ามีแล้ว ให้บวกจำนวนเพิ่ม 1
                    }
                    else
                    {
                        numberCount.Add(number, 1); // ถ้ายังไม่มี ให้เพิ่มตัวเลขนี้ลงไปโดยมีค่าเริ่มต้นที่ 1
                    }
                }

                foreach (KeyValuePair<int, int> kvp in numberCount)
                {
                    Debug.Log($"Number: {kvp.Key}, Count: {kvp.Value}");
                }


            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            
            // 1. สร้าง Dictionary จับคู่วงเล็บเปิด (Key) และวงเล็บปิด (Value)
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            // สร้าง LinkedList ว่าง ทำหน้าที่เสมือน Stack
            LinkedList<char> stack = new LinkedList<char>();

            if (input == null) input = "";

            // 2. วนอ่านตัวอักษรทีละตัวใน input
            foreach (char c in input)
            {
                // 3. หากเป็นวงเล็บเปิด (เป็น Key ใน Dictionary) ให้เก็บลงท้ายลิสต์ (Stack)
                if (bracketPairs.ContainsKey(c))
                {
                    stack.AddLast(c);
                }
                // 4. หากเป็นวงเล็บปิด (เป็น Value ใน Dictionary)
                else if (bracketPairs.ContainsValue(c))
                {
                    // ตรวจสอบก่อนว่า Stack ว่างหรือไม่ ถ้าว่างแปลว่ามีวงเล็บปิดโผล่มาโดยไม่มีวงเล็บเปิด -> Invalid
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return; // จบการทำงานทันที
                    }

                    // 5. เปรียบเทียบวงเล็บเปิดตัวล่าสุด (ท้ายลิสต์) กับวงเล็บปิดที่พบ
                    char lastOpenBracket = stack.Last.Value;
                    if (bracketPairs[lastOpenBracket] == c)
                    {
                        stack.RemoveLast(); // คู่ถูกต้อง นำวงเล็บเปิดออกจาก Stack
                    }
                    else
                    {
                        Debug.Log("Invalid"); // วงเล็บผิดคู่ -> Invalid
                        return; // จบการทำงานทันที
                    }
                }
                // ตัวอักษรอื่นๆ (เช่น a, b, c) จะไม่เข้าเงื่อนไขใดเลยและถูกข้ามไปอย่างปลอดภัย
            }

            // 6. หลังอ่านครบทุกตัวอักษร ถ้า Stack ว่างแสดงว่าจับคู่ครบพอดี -> Valid
            if (stack.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid"); // มีวงเล็บเปิดค้างอยู่แต่ไม่มีตัวปิด -> Invalid
            }
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            if (list == null)
            {
                Debug.Log("List is null");
                return;
            }

            LinkedListNode<int> currentNode = list.Last;
            while (currentNode != null)
            {
                Debug.Log(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            
            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty or null");
                return;
            }

            LinkedListNode<string> slowPointer = list.First;
            LinkedListNode<string> fastPointer = list.First;

            while (fastPointer != null && fastPointer.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;
            }

            Debug.Log(slowPointer.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            
            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>();

            foreach (KeyValuePair<string, int> kvp in dict2)
            {
                if (mergedDictionary.ContainsKey(kvp.Key))
                {
                    mergedDictionary[kvp.Key] += kvp.Value;
                }
                else
                {
                    mergedDictionary[kvp.Key] = kvp.Value;
                }
            }

            foreach (KeyValuePair<string, int> kvp in dict1)
            {
                Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

       public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();

            // 1. ตรวจสอบว่าลิสต์เป็น null หรือไม่มีสมาชิก
            if (list == null || list.Count == 0)
            {
                return;
            }

            // 2. สร้าง Dictionary เพื่อใช้บันทึกตัวเลขที่เคยพบแล้ว
            Dictionary<int, bool> seenNumbers = new Dictionary<int, bool>();

            // 3. เริ่มต้นที่โหนดแรกของลิสต์
            LinkedListNode<int> current = list.First;

            // วนลูปตราบใดที่โหนดปัจจุบันยังไม่เป็น null
            while (current != null)
            {
                // 4. สำรองโหนดถัดไปไว้ก่อนเสมอ เพราะโหนดปัจจุบันอาจถูกลบออก
                LinkedListNode<int> nextNode = current.Next;

                // 5. หากตัวเลขนี้เคยอยู่ใน Dictionary แล้ว ให้ลบโหนดปัจจุบันออกจากลิสต์
                if (seenNumbers.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    // หากยังไม่เคยพบ ให้เพิ่มตัวเลขนี้ลงใน Dictionary
                    seenNumbers.Add(current.Value, true);
                }

                // 6. เลื่อนไปทำงานกับโหนดถัดไปที่สำรองไว้
                current = nextNode;
            }

            // วนลูปแสดงผลลัพธ์ของสมาชิกที่เหลือหลังลบข้อมูลซ้ำ
            foreach (int value in list)
            {
                Debug.Log(value);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Numbers array is null or empty");
                return;
            }

            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            foreach (int number in numbers)
            {
                if (frequencyMap.ContainsKey(number))
                {
                    frequencyMap[number]++;
                }
                else
                {
                    frequencyMap[number] = 1;
                }
            }

            int maxFrequency = 0;
            int TopFrequentNumber = numbers[0];
            foreach (int number in numbers)
            {
                if (frequencyMap[number] > maxFrequency)
                {
                    maxFrequency = frequencyMap[number];
                    TopFrequentNumber = number;
                }

                Debug.Log($"Number: {number}, Frequency: {frequencyMap[number]}");
            }
            Debug.Log($"Top Frequent Number: {TopFrequentNumber}, Frequency: {maxFrequency}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;

            // 1. ตรวจสอบป้องกันกรณี inventory เป็น null
            if (inventory == null)
            {
                inventory = new Dictionary<string, int>();
            }

            // 2 & 3. หากมีไอเท็มนี้อยู่แล้ว ให้บวกจำนวนเพิ่ม
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            // 4. หากยังไม่มีไอเท็มนี้ ให้สร้าง key ใหม่และใส่จำนวนเริ่มต้น
            else
            {
                inventory.Add(itemName, quantity);
            }

            // 5. วนลูปแสดงผลรายการไอเท็มทั้งหมดใน inventory
            foreach (KeyValuePair<string, int> item in inventory)
            {
                Debug.Log($"{item.Key}: {item.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

       public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();

            // 1. ตรวจสอบว่าคิวเป็น null หรือไม่มี event หรือไม่
            if (eventQueue == null || eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            // 2. ใช้ลูป while ทำงานตราบใดที่ยังมี event เหลือในคิว
            while (eventQueue.Count > 0)
            {
                // 3. อ่าน event ตัวแรกจากหัวคิว
                GameEvent currentEvent = eventQueue.First.Value;

                // 4. ลบ event ตัวแรกออกจากคิว (FIFO)
                eventQueue.RemoveFirst();

                // *หากเป็น name ตัวพิมพ์เล็ก ให้เปลี่ยน .Name เป็น .name ครับ
                string eventName = currentEvent.Name; 

                // แสดงข้อความ event ที่กำลังประมวลผล
                Debug.Log($"Processing event: {eventName}");

                // 5. แสดงจำนวน event ที่เหลือในคิวหลังถูกลบออก
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                // 6. ตรวจสอบ EventType แล้วแสดงข้อความผลลัพธ์ตามประเภท event
                string type = currentEvent.EventType != null ? currentEvent.EventType.ToLower() : "";
                
                if (type == "enemy")
                {
                    Debug.Log($"Enemy event processed - {eventName}");
                }
                else if (type == "powerup")
                {
                    Debug.Log($"Power-up event processed - {eventName}");
                }
                else if (type == "level")
                {
                    Debug.Log($"Level event processed - {eventName}");
                }
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;

            // 1. ตรวจสอบป้องกันกรณี playerStats เป็น null
            if (playerStats == null)
            {
                playerStats = new Dictionary<string, int>();
            }

            // 2 & 3. หากมี stat นี้อยู่แล้ว ให้นำค่าปัจจุบันมาบวกเพิ่ม
            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            // 4. หากยังไม่มี stat นี้ ให้เพิ่ม key ใหม่พร้อมค่าเริ่มต้น
            else
            {
                playerStats.Add(statName, value);
            }

            // 5. แสดงข้อความสรุปการอัปเดต และแสดงรายการสถิติทั้งหมด
            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");

            foreach (KeyValuePair<string, int> pair in playerStats)
            {
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }

        #endregion
    }
}
