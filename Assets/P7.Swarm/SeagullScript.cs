using UnityEngine;

public class SeagullScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    PlayerManager playerManager;
    public float InterestMeter = 10;
    public float Aggressiveness = 0;

    void Start()
    {
        playerManager=FindFirstObjectByType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        InterestMeter -= 1 * Time.deltaTime; // framerate will run faster but also interval will be smaller

        if (InterestMeter <= 5) {
            Aggressiveness += 1 * Time.deltaTime;
        }
        else if (InterestMeter <= 0 && Aggressiveness >= 5) 
        {
        playerManager.Hp -= 1;
        playerManager.SeagullSpawnCD += .1f;
        Destroy(gameObject);
        }
        else
        {
            playerManager.SeagullSpawnCD += .1f;
            Destroy(gameObject);
        }

        //figure out how to raise interest meter when crumb spawns
    }
}
