using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Image fader;
    public GameObject thanks;
    public TaskBar taskbar;

    public MouseControl mouseCon;
    public CharacterController playerMove;
    

    public void Start()
    {
        fader.gameObject.SetActive(false);
        thanks.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && taskbar.TurnOnDoor == true)
        {
            mouseCon.enabled = false;
            playerMove.enabled = false;
            
            fader.gameObject.SetActive(true);
            fader.canvasRenderer.SetAlpha(0.0f);
            fader.CrossFadeAlpha(1.0f, 2f, false);


            StartCoroutine(wait());           
            
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.0f);
        thanks.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        Application.Quit();
    }

}
