using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("掉落物品")]
    public GameObject prop;
    [Header("掉落機率"), Range(0f, 1f)]
    public float cent = 0.5f ;
    /// <summary>
    /// 隨機掉落
    /// </summary>
    public void Dropprop() 
    {
        float f = Random.Range(0f, 1f);
        if (f <= cent)
        {
            Instantiate(prop,transform.position,transform.rotation);
        }
        Destroy(gameObject);
    }
}
