using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskGiver : MonoBehaviour
{
    public Task task;

    public Player player;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;


    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = task.title;
        descriptionText.text = task.wordReward.ToString();
        goldText.text = quest.goldReward.ToString();

    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.task = task;
    }
}

