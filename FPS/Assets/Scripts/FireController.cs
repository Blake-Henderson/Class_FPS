using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileLifespan = 5.0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            Destroy(projectile, projectileLifespan);
        }
    }
}
