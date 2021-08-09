using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskBar : MonoBehaviour
{
    public Text Escape;
    public Text Task1UI, Task2UI;

    public Color escapeIncomplete, taskIncomplete, complete;
    bool switchTasks;

    public bool TurnOnFlashlight;
    public bool FindEscapeDoor;
    public bool FollowWires;
    public bool TestPC;
    public bool TestGenerator;
    public bool GatherBarrels;
    public bool TestGeneratorSecondTime;
    public bool TurnOnPC;
    public bool TurnOnDoor;

    private string escapeTask, task1, task2, task3, task4, task5, task6, task7, task8, task9, empty;




    void Start()
    {
        Escape.GetComponent<Shadow>().effectColor = escapeIncomplete;
        Task1UI.GetComponent<Shadow>().effectColor = taskIncomplete;
        Task2UI.GetComponent<Shadow>().effectColor = taskIncomplete;
        switchTasks = false;

        escapeTask = "Escape";
        task1 = "Activate Flashlight";
        task2 = "Find Escape Door";
        task3 = "Follow Power Cables";
        task4 = "Test PowerCore";
        task5 = "Test Generator";
        task6 = "Place Fuel Barrels in Receptical";
        task7 = "Test fueled generator";
        task8 = "Activate PowerCore";
        task9 = "Activate Escape Door";
        empty = "";



        Escape.text = escapeTask;
        Task1UI.text = task1;
        Task2UI.text = task2;



        TurnOnFlashlight = false;
        FindEscapeDoor = false;
        FollowWires = false;
        TestPC = false;
        TestGenerator = false;
        GatherBarrels = false;
        TestGeneratorSecondTime = false;
        TurnOnPC = false;
        TurnOnDoor = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            changeTask();
        }
    }

    public void changeTask()
    {
        
        if(TurnOnDoor == true)
        {           
           
            if(switchTasks == true)
            {
                Escape.GetComponent<Shadow>().effectColor = complete;
                Task1UI.text = empty;
                switchTasks = false;
                
            }
            else
            {
                StartCoroutine(waitingTime());
            }           

        }

        else if(TestGeneratorSecondTime == true && TurnOnPC == true)
        {
            if (switchTasks == true)
            {
                Task1UI.text = task9;
                incompleteTask1();
                Task2UI.text = empty;
                switchTasks = false;
                TestGeneratorSecondTime = false;
                TurnOnPC = false;
            }
            else
            {
                StartCoroutine(waitingTime());
            }
        }

        else if(TestGenerator == true && GatherBarrels == true)
        {
            if (switchTasks == true)
            {
                Task1UI.text = task7;
                incompleteTask1();
                Task2UI.text = task8;
                incompleteTask2();
                switchTasks = false;
                TestGenerator = false;
                GatherBarrels = false;
            }
            else
            {
                StartCoroutine(waitingTime());
            }
        }

        else if(FollowWires == true && TestPC == true)
        {
            if (switchTasks == true)
            {
                Task1UI.text = task5;
                incompleteTask1();
                Task2UI.text = task6;
                incompleteTask2();
                switchTasks = false;
                FollowWires = false;
                TestPC = false;
            }
            else
            {
                StartCoroutine(waitingTime());
            }
        }

        else if(TurnOnFlashlight == true && FindEscapeDoor == true)
        {
            if (switchTasks == true)
            {
                Task1UI.text = task3;
                incompleteTask1();
                Task2UI.text = task4;
                incompleteTask2();
                switchTasks = false;
                TurnOnFlashlight = false;
                FindEscapeDoor = false;
            }
            else
            {
                StartCoroutine(waitingTime());
            }
        }

    }






    public void completeTask1()
    {
        Task1UI.GetComponent<Shadow>().effectColor = complete;
    }

    public void incompleteTask1()
    {
        Task1UI.GetComponent<Shadow>().effectColor = taskIncomplete;
    }

    public void completeTask2()
    {
        Task2UI.GetComponent<Shadow>().effectColor = complete;
    }

    public void incompleteTask2()
    {
        Task2UI.GetComponent<Shadow>().effectColor = taskIncomplete;
    }





    IEnumerator waitingTime()
    {
        yield return new WaitForSeconds(2f);
        switchTasks = true;
        changeTask();
    }
}
