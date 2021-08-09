using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorConsole : MonoBehaviour
{
    public Material consoleOn, consoleOff;
    public Material[] curMat;
    public PowerCoreConsole PC;
    public GameObject console;

    public GameObject endPortal;
    public Material doorOn, doorOff;
    private bool inside = false;

    private bool firstTime;
    public TaskBar taskBar;
    private AudioSource audio;


    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        firstTime = false;
        curMat = endPortal.gameObject.GetComponent<MeshRenderer>().materials;
        curMat[1] = doorOff;
        endPortal.gameObject.GetComponent<MeshRenderer>().materials = curMat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            curMat = console.GetComponent<MeshRenderer>().materials;
            curMat[1] = consoleOn;
            console.GetComponent<MeshRenderer>().materials = curMat;

            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            curMat = console.GetComponent<MeshRenderer>().materials;
            curMat[1] = consoleOff;
            console.GetComponent<MeshRenderer>().materials = curMat;
            inside = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inside == true)
            {
                audio.Play();
                if (PC.turnedOn == true)
                { 
                    curMat = endPortal.gameObject.GetComponent<MeshRenderer>().materials;
                    curMat[0] = doorOn;
                    endPortal.gameObject.GetComponent<MeshRenderer>().materials = curMat;

                    if(firstTime == false)
                    {
                        taskBar.TurnOnDoor = true;
                        taskBar.completeTask1();
                        firstTime = true;
                        taskBar.changeTask();
                    }
                }
            }
        }
    }
}
