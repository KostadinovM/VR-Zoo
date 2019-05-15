using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class AnimalPatrol : MonoBehaviour
{
    //Dictates whether the agent waits on each node.
    [SerializeField]
    bool patrolWating;
   
    //The total time we wait at each node.
    [SerializeField]
    float waitingTime = 3f;
 
    //The probability of switching direction.
    [SerializeField]
    float directionChangeProbability = 0.2f;
 
    //The list of all patrol nodes to visit.
    [SerializeField]
    List<GameObject> _patrolPoints;
 
    //Private variables for base behaviour.
    NavMeshAgent navMeshAgent;
    int currentPatrolPoint;
    bool travelling;
    bool waiting;
    bool patrolForward;
    float waitTimer;
 
    // Use this for initialization
    public void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
 
        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            if(_patrolPoints != null && _patrolPoints.Count >= 2)
            {
                currentPatrolPoint = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patrolling behaviour.");
            }
 
        }
    }
 
    public void Update()
    {
        //Check if we're close to the destination.
        if(travelling && navMeshAgent.remainingDistance <= 1.0f)
        {
            travelling = false;
           
            //If we're going to wait, then wait.
            if(patrolWating)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }
 
        //Instead if we're waiting.
        if(waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitingTime)
            {
                waiting = false;
 
                ChangePatrolPoint();
                SetDestination();
            }
        }
    }
   
    private void SetDestination()
    {
        if (_patrolPoints != null)
        {
            Vector3 targetVector = _patrolPoints[currentPatrolPoint].transform.position;
            navMeshAgent.SetDestination(targetVector);
            travelling = true;
        }
    }
 
    /// <summary>
    /// Selects a new patrol point in the available list, but
    /// also with a small probability allows for us to move forward or backwards.
    /// </summary>
    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= directionChangeProbability)
        {
            patrolForward = !patrolForward;
        }
 
        if (patrolForward)
        {
            currentPatrolPoint = (currentPatrolPoint + 1) % _patrolPoints.Count;
        }
        else
        {
            if (--currentPatrolPoint < 0)
            {
                currentPatrolPoint = _patrolPoints.Count - 1;
            }
        }
    }
}