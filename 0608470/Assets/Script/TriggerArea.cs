using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [Header("數量")]
    public GameObject[] bbb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "箱子")
        {
            bbb[0].SetActive(false);
        }
    }
}
