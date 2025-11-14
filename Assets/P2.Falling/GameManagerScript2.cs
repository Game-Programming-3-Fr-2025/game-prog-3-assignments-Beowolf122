using UnityEngine;

public class GameManagerScript2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocity = 5;
    public float maxvelocity = 20;
    public float minvelocity = 5;
    public float acceleration = 2;
    public float depth = 0;
    public float maxdepth = -500;
    public GameObject Stone;
    public GameObject Plank;
    public float spawntimer = 4;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration * Time.deltaTime;//should always be continuously accelerating to max spd
        if (velocity > maxvelocity) { velocity = maxvelocity; }//terminal velocity
        if (velocity < minvelocity) { velocity = minvelocity; }//minimal velocity

        if (Input.GetKey(KeyCode.DownArrow)) { velocity += acceleration * Time.deltaTime; }//increase velocity
        if (Input.GetKey(KeyCode.UpArrow)) { velocity -= 2 * acceleration * Time.deltaTime; }//decrease velocity
        depth -= velocity * Time.deltaTime;


        if (depth <= maxdepth) { Debug.Log("You win!"); }


        //instantiate a random hazard prefabs on the bottom of the screen (x:-10 to 10, y=-6, 0)
        spawntimer -= Time.deltaTime * velocity / 10;
        if (spawntimer < 0)
        {
            int B = Random.Range(-7, 8);
            Vector3 Xspawner = new Vector3(B, -6, 0);
            if (Random.Range(1, 3) == 1) //random range always cuts off the 2nd number
            {
                Instantiate(Stone, transform.position = Xspawner, Quaternion.identity);
            }// maybe make the rotation randomized
            else { Instantiate(Plank, transform.position = Xspawner, Quaternion.identity); }
            spawntimer = 3; //reset the timer
        }

        //future ideas: add a combo meter that can be displayed when parrying/destroying.
        //and differing win conditions in doc. and sfx/visuals
    }

}
