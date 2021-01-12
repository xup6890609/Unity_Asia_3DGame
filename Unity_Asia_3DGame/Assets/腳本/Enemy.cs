using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 2f;
    [Header("攻擊冷卻時間"), Range(0, 50)]
    public float cd = 2f;
    [Header("攻擊中心點")]
    public Transform Attackpoint;
    [Header("攻擊長度"), Range(0f, 5f)]
    public float attackLength;
    [Header("攻擊力度"), Range(0, 500)]
    public float attack=30;
    

    public float CD = 2f;
    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();                 // 取得身上元件<代理器>
        ani = GetComponent<Animator>();

        player = GameObject.Find("羅伯特").transform;       // 尋找其他遊戲物件("物件名稱").變形元件

        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }
    /// <summary>
    /// 追蹤系統、攻擊系統
    /// </summary>
    private void Update()
    {
        Track();
        Attack();
    }

    /// <summary>
    /// 射線擊中的物件
    /// </summary>
    private RaycastHit hit;

    /// <summary>
    /// 繪製圖示事件 (只在Unity內顯示)
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;                                                       //圖示.顏色 = 紅色
        Gizmos.DrawRay(Attackpoint.position, Attackpoint.forward * attackLength);       //(攻擊中心點座標,攻擊中心點前方*攻擊長度)
    }

    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {
        nav.SetDestination(player.position);                                //代理器.設定的目的地(玩家座標)
        // print("剩餘的距離" + nav.remainingDistance); //
        ani.SetBool("走路開關", nav.remainingDistance > stopDistance);      //動畫控制器.設定布林值,剩餘的距離 > 停止距離)

    }
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        if (nav.remainingDistance < stopDistance)
        {
            timer += Time.deltaTime;                // 累加時間(一幀的時間)
            Vector3 pos = player.position;          // 取得玩家座標
            pos.y = transform.position.y;           // 將玩家y軸指定成本物件y軸
            transform.LookAt(pos);                  //看向玩家
            
    /// <summary>
    ///如果計時器 >= 冷卻時間，就攻擊且計時器歸零
    /// </summary>

            if (timer >= CD)
            {
                ani.SetTrigger("攻擊觸發");
                timer = 0;
                if (Physics.Raycast(Attackpoint.position, Attackpoint.forward, out hit, attackLength, 1 << 8))    //物理.射線碰撞(攻擊中心點座標,攻擊中心點前方,攻擊長度,圖層)  //圖層：1<<圖層編號
                {
                    hit.collider.GetComponent<Robot>().Damage(attack);           //碰撞物件.取得物件<玩家>().受傷();
                } 
            }
        }
    }
}
