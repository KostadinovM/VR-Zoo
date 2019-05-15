using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AnimalBehaviour : MonoBehaviour
{
    
    
    AnimalMood animMood;

    [SerializeField]
    string animalID;
    
    Animator myAnim;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GameObject.Find(animalID).GetComponent<Animator>();
        animMood = new AnimalMood();
    }

    // Update is called once per frame
    void Update()
    {
        animMood.MoodCheck();

        if(animMood.activity == AnimalMood.Activity.Walking)
        {  
            myAnim.SetBool("isWalking", true);
        }
        else if(animMood.activity == AnimalMood.Activity.Running)
        {
             myAnim.SetBool("isRunning", true);
        }
        else if(animMood.activity == AnimalMood.Activity.Hitting)
        {
             myAnim.SetBool("isHitting", true);
        }
        else
        {
            return;
        }
    }


    
}
