using UnityEngine;

public class GraveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float decider;
    public float gravetimer = 0f;
    GameManager4Script gameManager;
    void Start()
    {
        decider = Random.value;
        //sets the object it is when created
        gameManager = FindFirstObjectByType<GameManager4Script>();


    }

    // Update is called once per frame
    void Update()

    {
        gravetimer -= Time.deltaTime;

        //if clicked, does this depending on which number it is
        if (gravetimer < 0 && Input.GetMouseButtonDown(0))
        {
            Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hitSomething = Physics2D.Raycast(mouseposition, Vector2.zero);
            if (hitSomething.collider != null && hitSomething.collider.gameObject == gameObject)
            {

                if (decider <= .2f)
                {
                    //explode, taking one life, destroying grave
                    gameManager.Lives -= 1;
                    Destroy(gameObject);
                    Debug.Log("kaboom.");
                }
                if (decider <= .8f && decider >= .2f)
                {
                    //increase zombies by 1
                    gameManager.ZombieCount += 1;
                    //reset cooldown
                    gravetimer = 10;
                    Debug.Log("1 zombie gained");

                }
                if (decider >= .8f)
                {
                    //same but 2
                    gameManager.ZombieCount += 2;
                    //reset cooldown. maybe half?
                    gravetimer = 5;
                    Debug.Log("2 zombies gained");
                }
                //reset the timer back to cooldown
            }
            //if gravetimer<=0, turn gray. If still in CD, turn Dark Gray
        }

    }

}

