using UnityEngine;
using Invector.vCharacterController;

public class Robot : MonoBehaviour
{
    private float hp = 100;
    private Animator ani;
    /// <summary>
    /// 連擊次數
    /// </summary>
    private int AttackCount;

    private float timer;
    [Header("連擊間隔時間"), Range(0, 3)]
    public float interval = 1;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    
    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        
        if (timer < interval)
        {
            timer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AttackCount++;
                timer = 0;
                ani.SetInteger("連擊", AttackCount);
            }
        }
        else
        {
            timer = 0;
        }
    }
    /// <summary>
    /// 受傷
    /// </summary>
    ///<param name="damage"></param>        //接收傷害值
    public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("受傷觸發");
        if (hp <= 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        ani.SetTrigger("死亡觸發");
        vThirdPersonController vt = GetComponent<vThirdPersonController>();
        vt.lockMovement = true;
        vt.lockRotation = true;
    }
}
