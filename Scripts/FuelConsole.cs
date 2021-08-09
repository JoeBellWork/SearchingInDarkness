using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelConsole : MonoBehaviour
{
    public Material consoleOn, consoleOff;
    public Material[] curMat;    
    public GameObject fuelText;
    public Collider fuelConsole;
    public int fuelAmount = 0;
    private bool inside = false;


    private bool firstTime, firstTime2;
    public TaskBar taskBar;
    private AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        firstTime = false;
        firstTime2 = false;

        curMat = fuelConsole.gameObject.GetComponent<MeshRenderer>().materials;
        curMat[1] = consoleOff;
        fuelConsole.gameObject.GetComponent<MeshRenderer>().materials = curMat;
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inside = true;
            curMat = fuelConsole.gameObject.GetComponent<MeshRenderer>().materials;
            curMat[1] = consoleOn;
            fuelConsole.gameObject.GetComponent<MeshRenderer>().materials = curMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inside = false;
            curMat = fuelConsole.gameObject.GetComponent<MeshRenderer>().materials;
            curMat[1] = consoleOff;
            fuelConsole.gameObject.GetComponent<MeshRenderer>().materials = curMat;

            fuelText.SetActive(false);
        }
        
    }

    void change1()
    {
        taskBar.TestGenerator = true;
        taskBar.completeTask1();
        firstTime = true;
        taskBar.changeTask();
    }

    void change2()
    {        
        taskBar.TestGeneratorSecondTime = true;
        taskBar.completeTask1();
        firstTime2 = true;
        taskBar.changeTask();
    }

    public  void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inside == true)
        {
            audio.Play();
            if (firstTime == false)
            {
                change1();
            }

            if (fuelConsole.gameObject.GetComponent<MeshRenderer>().materials[1] = consoleOn)
            {                

                fuelText.GetComponent<TextMesh>().text = "Fuel Is: " + fuelAmount +"%";
                fuelText.SetActive(true);

                if(fuelAmount == 100)
                {
                    if (firstTime2 == false)
                    {
                        change2();
                    }
                }

            }
        }
        
    }
}


