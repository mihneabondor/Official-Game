using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void taskToDo()
    {
        if (goalType == GoalType.Easy)
            currentAmmount += 3;
        if (goalType == GoalType.Hard)
            currentAmmount += 7;
        if (goalType == GoalType.Medium)
            currentAmmount += 5;
    }

    public void ItemCollected()
    {
        if (goalType == GoalType.Easy)
            currentAmmount += 3;
        if (goalType == GoalType.Hard)
            currentAmmount += 7;
        if (goalType == GoalType.Medium)
            currentAmmount += 5;
    }
}

public enum GoalType
{
    Easy, Medium, Hard
}