using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Canvas CanvasObject;
    public void StartGame()
    {
        Debug.Log("works");
        CanvasObject.enabled = false;
    }
    public void QuitGame()
    {
        Debug.Log("works");
        Application.Quit();
    }

}
