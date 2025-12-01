using UnityEngine;

public class HazardScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float spd;
    Rigidbody2D rb;
    GameManagerScript2 gameManagerScript2;
    public float rotation = 0;
    public bool counterclockwise = true;
    public int rotatspd;

    public float objectdamage;
    public bool heavyobject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManagerScript2 = FindFirstObjectByType<GameManagerScript2>();

        //randomize and change object size
        int objectsize = Random.Range(1, 3);
        transform.localScale = new Vector3(transform.localScale.x * objectsize, transform.localScale.y * objectsize, 1);
        if (objectsize >= 2) { heavyobject = true; }
        else { heavyobject = false; }

        //randomize and change object rotation direction
        if (Random.Range(1, 3) == 1) { counterclockwise = true; }
        else { counterclockwise = false; }

        rotatspd = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //object is moving "upwards" while falling, speed based on the GameManager's "velocity".
        rb.linearVelocityY += (gameManagerScript2.velocity * gameManagerScript2.velocity / 10) * Time.deltaTime; //NOTE: Transition to ADDFORCE

        if (transform.position.y > 6) { Destroy(gameObject); }

        //either rotate in one direction or rotate in another direction
        if (counterclockwise == true) { rotation += 3 * rotatspd; }
        else { rotation -= 3 * rotatspd; }
        transform.rotation = Quaternion.Euler(0, 0, rotation);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if colliding with player, check the tag of the object of player, player -1 hp, destroy object
        if (other.gameObject.CompareTag("Player"))
        {
            NinjaPlayerScript ninjaPlayerScript = FindFirstObjectByType<NinjaPlayerScript>();
            if (gameObject.transform.localScale.y == 2) { ninjaPlayerScript.ninjahp -= 1; }
            ninjaPlayerScript.ninjahp -= 1;
            Destroy(gameObject);
        }
        
    }

}
