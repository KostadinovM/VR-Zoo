using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    public ParticleSystem ps;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Food")
        {
            Destroy(col.gameObject);
            ps.Play();
        }
    }
}
