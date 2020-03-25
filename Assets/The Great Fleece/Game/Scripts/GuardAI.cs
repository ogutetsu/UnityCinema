using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    public Transform currentTarget;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (wayPoints.Count > 0)
        {
            if (wayPoints[0] != null)
            {
                currentTarget = wayPoints[0];
                agent.SetDestination(currentTarget.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.position);
            if (distance < 1.0f)
            {
                if (IsWaypoint(1) && currentTarget != wayPoints[1])
                {
                    currentTarget = wayPoints[1];
                    agent.SetDestination(currentTarget.position);
                }
                else if (IsWaypoint(2))
                {
                    currentTarget = wayPoints[2];
                    agent.SetDestination(currentTarget.position);
                }
            }
        }
    }

    bool IsWaypoint(int index)
    {
        if (wayPoints.Count > index)
        {
            if (wayPoints[index] != null)
            {
                return true;
            }
        }

        return false;
    }
    
    
}
