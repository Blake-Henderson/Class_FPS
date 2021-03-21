using UnityEngine;
using UnityEngine.AI;

public class SeekBehavior : MonoBehaviour
{
    public Transform target;

    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();        
    }

    void Update()
    {
        navMeshAgent.SetDestination(target.position);    
    }
}
