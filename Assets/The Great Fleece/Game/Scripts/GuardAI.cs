using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    [SerializeField]
    private int currentTarget;

    private bool reverse;
    private bool targetReached;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null)
        {
            agent.SetDestination(wayPoints[currentTarget].position);
            float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);
            if ((distance < 1.0f) && targetReached == false)
            {
                if (currentTarget == 0 || currentTarget == wayPoints.Count - 1)
                {
                    targetReached = true;
                    StartCoroutine(WaitBeforMoving());
                }
                else
                {
                    if (reverse == true)
                    {
                        currentTarget--;
                        if (currentTarget < 0)
                        {
                            reverse = false;
                            currentTarget = 0;
                        }
                    }
                    else
                    {
                        currentTarget++;
                    }
                }
            }
            
        }
    }


    IEnumerator WaitBeforMoving()
    {
        if(currentTarget == 0)
        {
            yield return new WaitForSeconds(2.0f);
        }
        else if (currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(2.0f);
        }
        else
        {
            yield return null;
        }
        
        if (reverse)
        {
            currentTarget--;
            if (currentTarget < 0)
            {
                reverse = false;
                currentTarget = 0;
            }
        }
        else
        {
            currentTarget++;
            if (currentTarget == wayPoints.Count)
            {
                reverse = true;
                currentTarget--;
            }
        }
        targetReached = false;
    }

    
}
