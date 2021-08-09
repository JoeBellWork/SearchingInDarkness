using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCoreConsole : MonoBehaviour
{
    public Material consoleOn, consoleOff;
    public Material[] curMat;
    public GameObject Spotlight;
    public GameObject console;
    public FuelConsole fuelConsole;
    public Fuel fuel;
    private bool inside;
    public bool turnedOn;


    private bool firstTime, firsttime2,firstTime3;
    public TaskBar taskBar;
    private AudioSource audioS;



    // Start is called before the first frame update
    void Start()
    {
        audioS = this.GetComponent<AudioSource>();
        firstTime = false;
        firsttime2 = false;
        firstTime3 = false;

        curMat = console.GetComponent<MeshRenderer>().materials;
        curMat[1] = consoleOff;
        console.GetComponent<MeshRenderer>().materials = curMat;

        inside = false;
        turnedOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            curMat = console.GetComponent<MeshRenderer>().materials;
            curMat[1] = consoleOn;
            console.GetComponent<MeshRenderer>().materials = curMat;

            if(firstTime == false)
            {
                taskBar.FollowWires = true;
                taskBar.completeTask1();
                firstTime = true;
                taskBar.changeTask();
            }

            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            curMat = console.GetComponent<MeshRenderer>().materials;
            curMat[1] = consoleOff;
            console.GetComponent<MeshRenderer>().materials = curMat;
            inside = false;
        }               
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inside == true)
            {
                audioS.Play();
                if (firsttime2 == false)
                {
                    taskBar.TestPC = true;
                    taskBar.completeTask2();
                    firsttime2 = true;
                    taskBar.changeTask();
                }

                if (fuelConsole.fuelAmount == 100)
                {
                    Spotlight.GetComponent<MeshRenderer>().material = fuel.powerOn;
                    fuel.powerCoreOn();
                    turnedOn = true;

                    if(firstTime3 == false)
                    {
                        taskBar.TurnOnPC = true;
                        taskBar.completeTask2();
                        firstTime3 = true;
                        taskBar.changeTask();
                    }
                }
            }
        }
    }
}
