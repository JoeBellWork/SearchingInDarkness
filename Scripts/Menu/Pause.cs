using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Image MenuButton;
    public Color Off, On;
    public static bool paused;
    public static bool controlsDisplay;

    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject restartMenu;
    public GameObject controlsMenu;
    public GameObject quitMenu;

    public GameObject TaskMenu;
    
    public MouseControl mouseCon;
    public Movement playerMove;

    public Image fader;

    public void Start()
    {
        fader.gameObject.SetActive(true);


        fader.canvasRenderer.SetAlpha(1.0f);
        fader.CrossFadeAlpha(0.0f, 2f, false);
        StartCoroutine(wait2Seconds());


        paused = false;
        TaskMenu.SetActive(true);

        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        restartMenu.SetActive(false);
        controlsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == false)
            {
                pause();
            }
            else
            {
                resume();
            }            
        }
    }







    public void pause()
    {
        if(paused == false)
        {
            MenuButton.color = On;
            paused = true;

            restartMenu.SetActive(false);
            controlsMenu.SetActive(false);
            quitMenu.SetActive(false);
            TaskMenu.SetActive(false);

            pauseMenu.SetActive(true);
            mainMenu.SetActive(true);

            mouseCon.enabled = false;
            playerMove.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
                
        restartMenu.SetActive(false);
        controlsMenu.SetActive(false);
        quitMenu.SetActive(false);
        TaskMenu.SetActive(false);

        pauseMenu.SetActive(true);
        mainMenu.SetActive(true);        
    }

    public void resume()
    {
        MenuButton.color = Off;
        paused = false;

        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        restartMenu.SetActive(false);
        controlsMenu.SetActive(false);
        quitMenu.SetActive(false);

        TaskMenu.SetActive(true);

        mouseCon.enabled = true;
        playerMove.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }





    public void restartButton()
    {        
        mainMenu.SetActive(false);        

        restartMenu.SetActive(true);
    }

    public void restartFunction()
    {
        fader.gameObject.SetActive(true);
        StartCoroutine(restartWaitSeconds());
        fader.CrossFadeAlpha(1.0f, 2f, false);
    }




    public void controlsButton()
    {
        mainMenu.SetActive(false);

        controlsMenu.SetActive(true);
    }




    public void quitButton()
    {
        mainMenu.SetActive(false);

        quitMenu.SetActive(true);
    }

    public void quitFunction()
    {
        fader.gameObject.SetActive(true);
        fader.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(quitWaitSeconds());        
        fader.CrossFadeAlpha(1.0f, 2f, false);
    } 

    IEnumerator wait2Seconds()
    {
        yield return new WaitForSeconds(2f);
        fader.gameObject.SetActive(false);
    }

    IEnumerator quitWaitSeconds()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
        Debug.Log("quit");
    }


    IEnumerator restartWaitSeconds()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }    
}
