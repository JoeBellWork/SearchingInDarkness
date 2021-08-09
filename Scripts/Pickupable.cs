using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance = 1f;
    public float smooth = 1f;
    public bool outsideAccess = false;

    public GameObject thisObject;
    public Material[] curMat;
    public Material lightUpBarrel, normalBarrel;
    public bool inside;
    public Collider trigger;
    public Collider sphereCol, boxCol;

    private AudioSource audioS;


    
    void Start()
    {
        audioS = this.GetComponent<AudioSource>();
        sphereCol.enabled = false;
        boxCol.enabled = true;

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        inside = false;

        thisObject = this.gameObject;

        switchToNormal();
    }    


    void Update()
    {
        if (carrying)
        {
            carry(carriedObject);
            checkDrop();
        }
        else
        {
            pickup();
        }        
    }


    void carry(GameObject o)
    {        
        Vector3 playerPosition = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - 0.35f, mainCamera.transform.position.z);
        o.transform.position = Vector3.Lerp(o.transform.position, playerPosition + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }

    void pickup()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Tank"))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                GameObject g = p.gameObject;
                if(p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    audioS.Play();
                    boxCol.enabled = false;
                    sphereCol.enabled = true;

                    trigger.enabled = false;
                    if(this.gameObject == g)
                    {
                        switchToLight();
                    }
                    
                }
            }
        }
    }

    void checkDrop()
    {
        if(Input.GetKeyDown(KeyCode.E) || outsideAccess == true)
        {
            switchToNormal();

            inside = false;            
            dropObject();            
        }

    }
    public void dropObject()
    {
        this.trigger.enabled = true;

        carrying = false;  
        
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;  
        
        carriedObject = null;

        outsideAccess = false;
        sphereCol.enabled = false;
        boxCol.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switchToLight();

            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switchToNormal();
            inside = false;
        }
    }


    public void switchToNormal()
    {
        curMat = thisObject.GetComponent<MeshRenderer>().materials;
        curMat[1] = normalBarrel;
        thisObject.GetComponent<MeshRenderer>().materials = curMat;
    }

    public void switchToLight()
    {
        curMat = thisObject.GetComponent<MeshRenderer>().materials;
        curMat[1] = lightUpBarrel;
        thisObject.GetComponent<MeshRenderer>().materials = curMat;
    }
}
