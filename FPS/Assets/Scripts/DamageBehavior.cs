using UnityEngine;

public class DamageBehavior : MonoBehaviour
{
    public int damageInflicted = 1;

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SendMessage("ApplyDamage", damageInflicted);
        }
    }
}
