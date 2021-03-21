using UnityEngine;

public class ProjectileHitController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);  
    }
}
