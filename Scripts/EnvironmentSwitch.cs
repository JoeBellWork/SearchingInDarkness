using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSwitch : MonoBehaviour
{
    bool lightIsOn;
    public GameObject[] LightObj;
    public GameObject[] DarkObj;
    public int i = 0;
    public GameObject target;
    

    private bool firstTime;
    public TaskBar taskBar;
    void Start()
    {
        firstTime = false;
        lightIsOn = false;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            lightIsOn = !lightIsOn;                     
        }
    }


    

    public void OnTriggerStay(Collider other)
    {
        if(lightIsOn == true)
        {
            if(other.CompareTag("AwakeInLight"))
            {
                other.GetComponent<MeshRenderer>().enabled = true;                
                other.GetComponent<MeshCollider>().isTrigger = false;

                if(other.gameObject.name == "Door" && firstTime == false)
                {
                    taskBar.FindEscapeDoor = true;
                    taskBar.completeTask2();
                    firstTime = true;
                    taskBar.changeTask();
                }
            }
            else if(other.CompareTag("AwakeInDark"))
            {
                other.GetComponent<MeshRenderer>().enabled = false;                
                other.GetComponent<MeshCollider>().isTrigger = true;
            }
        }
        else
        {
            foreach (GameObject AwakeInDark in DarkObj)
            {
                AwakeInDark.GetComponent<MeshRenderer>().enabled = true;                
                AwakeInDark.GetComponent<MeshCollider>().isTrigger = false;
            }

            foreach (GameObject AwakeInLight in LightObj)
            {
                AwakeInLight.GetComponent<MeshRenderer>().enabled = false;                
                AwakeInLight.GetComponent<MeshCollider>().isTrigger = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {

        
        if (lightIsOn == true)
        {
            
            if (other.CompareTag("AwakeInLight"))
            {
                other.GetComponent<MeshRenderer>().enabled = false;                
                other.GetComponent<MeshCollider>().isTrigger = true;
            }
            else if (other.CompareTag("AwakeInDark"))
            {
                other.GetComponent<MeshRenderer>().enabled = true;                
                other.GetComponent<MeshCollider>().isTrigger = false;
            }
        }
        else
        {
            foreach (GameObject AwakeInDark in DarkObj)
            {
                AwakeInDark.GetComponent<MeshRenderer>().enabled = true;               
                AwakeInDark.GetComponent<MeshCollider>().isTrigger = false;
            }

            foreach (GameObject AwakeInLight in LightObj)
            {
                AwakeInLight.GetComponent<MeshRenderer>().enabled = false;                
                AwakeInLight.GetComponent<MeshCollider>().isTrigger = true;
            }
        }
    }
}
