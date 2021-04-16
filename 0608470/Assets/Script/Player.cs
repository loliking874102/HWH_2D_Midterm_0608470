using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [Header("速度"),Range(0,10),Tooltip("調整角色速度")]
    public float speed = 10.5f;
    [Header("攻擊"), Tooltip("調整角色攻擊傷害")]
    public float attack = 10;
    [Header("金幣"),Tooltip("獲得金幣數量")]
    public int coin = 0;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形元件")]
    public Transform tra;
    [Header("動畫元件")]
    public Animator ani;
    [Header("偵測範圍")]
    public float rangeAttack = 2.5f;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("攻擊音效")]
    public AudioClip soundAttack;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        print("移動");
        float h = joystick.Horizontal;
        print("水平 =" + h);
        float v = joystick.Vertical;
        print("垂直 =" + v);
        transform.Translate(h * speed * Time.deltaTime,0 ,0);
        ani.SetFloat("水平", h);
        ani.SetFloat("垂直", v);
    }
    public void Att()
    {
        aud.PlayOneShot(soundAttack, 0.5f);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, rangeAttack, -transform.up,  0,1 << 8);
        
        if (hit && hit.collider.tag == "道具") hit.collider.GetComponent<Item>().Dropprop();
    }
    private void Hit()
    {

    }
    private void Dead()
    {

    }
    private void Start()
    {
          
    }
    private void Update()
    {
        
        Move();
    }
    [Header("吃金幣音效")]
    public AudioClip eatsound;
    [Header("金幣數量")]
    public Text GetCoin ;
    private int Coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin++;
        print(collision.gameObject);
        aud.PlayOneShot(eatsound);
        Destroy(collision.gameObject);
        GetCoin.text = "金幣:" + Coin;
    }
}
