using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{    
    public GameObject mainMenu;
    public GameObject startMenu;
    public GameObject controlsMenu;
    public GameObject quitMenu;

    public Image fader;


    public void Start()
    {
        fader.canvasRenderer.SetAlpha(1.0f);
        fader.CrossFadeAlpha(0.0f, 2f, false);

        Cursor.lockState = CursorLockMode.Confined;
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
        controlsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }


    public void mainMenuButton()
    {
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
        controlsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }


    public void startMenuButton()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void startMenuFunction()
    {
        fader.CrossFadeAlpha(1.0f, 2f, false);
        startMenu.SetActive(false);
        StartCoroutine(fadeWaiter());
        
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
        Application.Quit();
    }

    IEnumerator fadeWaiter()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
