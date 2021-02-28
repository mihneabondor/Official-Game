using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public int tasksDone = 0;
    public int currentTask = 1;
    public int currentTaskOK = 0;

    public int codeWords = 0;

    public HealthBar healthBar;
    
    public Task task;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        tasksDone = 0;
    }

    float bb8x = 5, bby = 5;
    int coffeeX = 6, coffeeY = 6;

    void Update()
    {
        movement(0.1f);
    }

    void movement(float speedMultiplier)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 verticalMovement = Vector3.up * verticalInput;
        Vector3 horizontalMovement = Vector3.right * horizontalInput;

        this.transform.position += Vector3.ClampMagnitude(verticalMovement + horizontalMovement, 1) * speedMultiplier;

        Debug.Log(verticalInput);
        Debug.Log(horizontalInput);
    }

    public void DoTasks()
    {
        if (task.isActive)
        {
            task.goal.taskToDo();
            if (task.goal.IsReached())
            {
                inventory += task.wordReward;
                task.Complete();
            }
        }
    }

    void TakeDamage()
    {
        if(currentTaskOK==0)
            currentHealth -= 33.4;
        healthBar.SetHealth(currentHealth);
    }

}

