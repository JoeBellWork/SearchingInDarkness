using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPortal : MonoBehaviour
{
    public FuelConsole fuelConsole;
    GameObject heldTank;
    Pickupable pickUpScript;

    private bool firstTime;
    public TaskBar taskBar;
    private AudioSource audio;

    private void Start()
    {
        audio = this.GetComponent<AudioSource>();
        firstTime = false;        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tank") && other.isTrigger == false)
        {
            audio.Play();
            pickUpScript = other.GetComponent<Pickupable>();
            heldTank = other.gameObject;
            

            fuelConsole.fuelAmount += 50;
            pickUpScript.outsideAccess = true;
            pickUpScript.trigger.enabled = true;
            pickUpScript.dropObject();
            heldTank.SetActive(false);
            change();
            
        }        
    }

    void change()
    {
        if(firstTime == false && fuelConsole.fuelAmount == 100)
        {
            taskBar.GatherBarrels = true;
            taskBar.completeTask2();
            firstTime = true;
            taskBar.changeTask();
        }
    }
}
