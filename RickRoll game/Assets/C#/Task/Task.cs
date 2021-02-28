using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    public bool isActive = false;

    public string title;
    public int wordReward;

    public TaskGoal task;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title = "was completed!");
    }

}

