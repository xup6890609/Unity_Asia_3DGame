
using UnityEngine;

[ CreateAssetMenu(fileName="NPC資料" ,menuName="選單/NPC資料")]

public class NPCData : ScriptableObject
{
    [Header("第一段對話"),TextArea(1,6)]
    public string dialougeA;
    [Header("第二段對話"), TextArea(1, 6)]
    public string dialougeB;
    [Header("第三段對話"), TextArea(1, 6)]
    public string dialougeC;
    [Header("任務項目需求數量")]
    public int count;
    [Header("已取得的項目數量")]
    public int countCurrent;

}
