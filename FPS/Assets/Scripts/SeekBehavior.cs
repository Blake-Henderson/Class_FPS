using UnityEngine;
using UnityEngine.AI;

public class SeekBehavior : MonoBehaviour
{
    public float knockbackTime = 1.0f;
    public float kick = 1.8f;

    bool hit = false;
    ContactPoint contact;
    float timer = 0.0f;

    Transform target = null;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

        timer = knockbackTime;
    }

    void Update()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        if (hit)
        {
            rb.isKinematic = false;
            navMeshAgent.isStopped = true;
            rb.AddForceAtPosition(Camera.main.transform.forward * kick, contact.point, ForceMode.Impulse);
            timer = 0.0f;
            hit = false;
        }
        else
        {
            timer += Time.deltaTime;

            if (knockbackTime < timer)
            {
                rb.isKinematic = true;
                navMeshAgent.isStopped = false;

                if (target != null)
                {
                    navMeshAgent.SetDestination(target.position);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("bullet"))
        {
            contact = collision.contacts[0];
            hit = true;
        }
    }
}
