using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource source;
    public bool keepPlaying = true;
    public int waitSec = 16;
     
    void Start () 
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundIn());
    }
     
    IEnumerator PlaySoundIn()
    {
        while (keepPlaying){
            source.Play(); 
            yield return new WaitForSeconds(waitSec);
        }
    }
}
