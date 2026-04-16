using UnityEngine;

public class GraveSpotScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameManager4Script gameManager;
    public GameObject Grave;
    public bool gravepresent = true;
    void Start()
    {
        Instantiate(Grave, transform.position, Quaternion.identity);
        gameManager = FindFirstObjectByType<GameManager4Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.ZombieCount >= 3 && Input.GetKeyDown(KeyCode.Space))
        {

            gameManager.ZombieCount -= 3;
            //destroy grave, then:
            Instantiate(Grave, transform.position, Quaternion.identity);

            //is it possible to destroy child object, then re-instantiate it back as a child
        }
    }
}
