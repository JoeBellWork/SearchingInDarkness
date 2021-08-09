using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public EnvironmentSwitch ES;
    public Material powerOff, powerOn;
    public Material[] curMat;
    public GameObject[] lightUp;
    public GameObject generator, powerCore,decerativePowerCore, sideLight;
    public FuelConsole fuelConsole;
    public PowerCoreConsole pcConsole;
    // Start is called before the first frame update
    void Start()
    {
        //powerCore.gameObject.GetComponent<MeshRenderer>().material = powerOff;
        foreach( GameObject details in lightUp)
        {
            if (details.gameObject.name == "PowerCore")
            {
                curMat = details.GetComponent<MeshRenderer>().materials;
                curMat[0] = powerOff;
                details.GetComponent<MeshRenderer>().materials = curMat;
            }
            else
            {
                curMat = details.GetComponent<MeshRenderer>().materials;
                curMat[1] = powerOff;
                details.GetComponent<MeshRenderer>().materials = curMat;
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {   
        if(fuelConsole.fuelAmount == 100)
        {
            curMat = lightUp[0].GetComponent<MeshRenderer>().materials;
            curMat[1] = powerOn;
            lightUp[0].GetComponent<MeshRenderer>().materials = curMat;
        }
    }

    public void powerCoreOn()
    {
        //powerCore.gameObject.GetComponent<MeshRenderer>().material = powerOn;

        foreach (GameObject details in lightUp)
        {
            if(details.gameObject.name == "PowerCore")
            {
                curMat = details.GetComponent<MeshRenderer>().materials;
                curMat[0] = powerOn;
                details.GetComponent<MeshRenderer>().materials = curMat;
            }
            else
            {
                curMat = details.GetComponent<MeshRenderer>().materials;
                curMat[1] = powerOn;
                details.GetComponent<MeshRenderer>().materials = curMat;
            }
            
        }
    }
}
