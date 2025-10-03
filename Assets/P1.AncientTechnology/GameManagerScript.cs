using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Fog;
    public int destroyedtemples = 0; //idea: make this a static variable so player/enemy scripts can access it..?
    public bool breakingPoint = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (destroyedtemples == 5)
        {
            Destroy(Fog);
            breakingPoint = true;

            //communicate to player/enemy to set their BP's to true
            PlayerScript ps = FindFirstObjectByType<PlayerScript>();
            ps.PlayerBP = true;
            EnemyScript enemyScript = FindFirstObjectByType<EnemyScript>();
            enemyScript.EnemyBP = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)
            || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5))
        { destroyedtemples += 1; }


    }
}
