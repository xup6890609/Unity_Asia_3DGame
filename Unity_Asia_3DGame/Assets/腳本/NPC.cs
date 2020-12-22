using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class NPC : MonoBehaviour
{
[Header("NPC資料")]
public NPCData data;

[Header("對話框")]
public GameObject dialouge;
 
[Header("對話內容")]
public Text textContent;
 
[Header("對話者名稱")]
public Text textName;

[Header("對話時間間隔")]
public float interval = 0.2f;

/// <summary>
/// 判斷玩家是否進入感應區
/// </summary>


 public bool playerInArea;
    /*協同程序test
    private void Start()
    {   
        // 啟動協程
        StartCoroutine(Test());
    }
    
    private IEnumerator Test()
    { print("hi~");
      yield return new WaitForSeconds(1f);
      print("hi~一秒後");
    }
    */

    public enum NPCState
    {
        FirstDialouge,Missioning,Finish
    }

    public NPCState state = NPCState.FirstDialouge;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="羅伯特")
        { playerInArea =true;
          StartCoroutine(Dialouge());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "羅伯特")
        {
            playerInArea = false;
            StopDialouge();
        }
    }
    /// <summary>
    /// 關閉對話框
    /// </summary>
    private void StopDialouge()
    {
        dialouge.SetActive(false);
        StopAllCoroutines();
    }
    /// <summary>
    /// 啟動對話框
    /// </summary>
        private IEnumerator Dialouge()
        {
        /**
        // print(data.dialougeA);      // 取得字串全部資料
        // print(data.dialouge[0]);    // 取字串局部資料[編號]，從0始算

        /// for 迴圈:重複字串資料,i是代稱

        /// 語法：
        //  for (int i = 0; i < 10; i++)
        //  {
        //    print("我是迴圈：" + i);
        //  }
        **/
        //顯示對話框
        dialouge.SetActive(true);
        // =""：清空文字
        textContent.text = "";
        
        // 指定對話者名稱
        textName.text = name;

        // 要說的話
        string dialougeString = data.dialougeA;
        switch (state)
        {
            case NPCState.FirstDialouge:
                dialougeString = data.dialougeA;
                 break;
            case NPCState.Missioning:
                dialougeString = data.dialougeB;
                 break;
            case NPCState.Finish:
                dialougeString = data.dialougeC;
                 break;
        
               
        }

        // 字串(dialougeA).長度
        for (int i = 0; i < dialougeString.Length; i++)
        {
            // +:串聯
            textContent.text += dialougeString [i] + "";
            yield return new WaitForSeconds(interval);
        }
        }
    }

