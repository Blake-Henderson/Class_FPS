using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    int numHits = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("bullet"))
        {
            ++numHits;

            if (numHits >= health)
            {
                Destroy(gameObject);
            }
        }
    }
}
