using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 2f;

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
            }
        }
    }
}
