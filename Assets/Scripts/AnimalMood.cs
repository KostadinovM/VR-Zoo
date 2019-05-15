using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMood : MonoBehaviour
{
    public enum Mood  {Calm, Angry, Happy}
    public enum Activity {Idle, Walking, Running, Hitting}
    public Mood mood {get; set;}
    public Activity activity{get; set;}

    // Start is called before the first frame update
    void Start()
    {
        mood = Mood.Happy;
    }

    // Update is called once per frame
    void Update()
    {
        MoodCheck();
    }

    public void MoodCheck()
    {
        if (mood==Mood.Calm)
        {
            activity = Activity.Walking;
        }
        else if(mood == Mood.Angry)
        {
            activity = Activity.Hitting;
        }
        else if(mood == Mood.Happy)
        {
            activity = Activity.Running;
        }

        else{return;}
    }
}

