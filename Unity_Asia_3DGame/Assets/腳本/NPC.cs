using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
 [Header("NPC資料")]
 public NPCData data;
 [Header("對話框")]
 public GameObject dialouge;
 [Header("對話內容")]
 public Text textContent;

 //<Summary> 判斷玩家是否進入感應區
 public bool playerInArea;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="羅伯特")
        { playerInArea =true;
          Dialouge();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "羅伯特")
        {
            playerInArea = false;
        }
    }
        private void Dialouge()
        {
        // print(data.dialougeA);      // 取得字串全部資料
        // print(data.dialouge[0]);    // 取字串局部資料[編號]，從0始算

        /// for 迴圈:重複字串資料,i是代稱

        /// 語法：
        //  for (int i = 0; i < 10; i++)
        //  {
        //    print("我是迴圈：" + i);
        //  }
        
        // 字串(dialougeA).長度
        for (int i = 0; i < data.dialougeA.Length; i++)
        {
            print(data.dialougeA[i]);
        }
        }
    }

