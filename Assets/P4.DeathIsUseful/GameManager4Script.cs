using UnityEngine;

public class GameManager4Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Lives = 3;
    public int ZombieCount = 0;
    public float TimerTillDay = 60f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerTillDay -= Time.deltaTime;
        if (Lives <= 0)
        {
            Debug.Log("You fail");
        }
        if (ZombieCount >= 30)
        {
            Debug.Log("You win");
        }

        //Action 1: Scout. -1zombie, to check if it is a bomb or not
        //Action 3: Reset. -3 zombies to -10 secs to the timer of each grave
        //Action4: halve the current amount of zombies, rounding up, to extend the night by another 10

    }
}
