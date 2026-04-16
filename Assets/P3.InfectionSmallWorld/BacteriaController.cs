using UnityEngine;

public class BacteriaController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed = 5;
    public Vector3 vel; //used to store the gameobject's literal velocity. It's current velocity
    public GameObject rangeRadius;
    Rigidbody2D rb;
    public GameObject BacteriaPrefab;
    VirusScriptThing VirusScriptThing;
    public float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        VirusScriptThing = FindFirstObjectByType<VirusScriptThing>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = vel;

        float desiredX; //what the current velocity should lerp to

        //If we're hitting keys we move in that direction
        if (Input.GetKey(KeyCode.RightArrow))
        {
            desiredX = Speed; //set the desired velocity= to speed
            if (vel.x < 0) vel.x = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            desiredX = -Speed;
            if (vel.x > 0) vel.x = 0;
        }
        else //If we're not hitting keys, come to stop
        {
            desiredX = 0;
        }
        vel.x = Mathf.Lerp(vel.x, desiredX, 0.3f); //lerps the current velocity to the desiered velocity


        float desiredY;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            desiredY = Speed; //set the desired velocity= to speed
            if (vel.y < 0) vel.y = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            desiredY = -Speed;
            if (vel.y > 0) vel.y = 0;
        }
        else { desiredY = 0; }
        vel.y = Mathf.Lerp(vel.y, desiredY, 0.3f);

        //stop player from going out of bounds
        Vector3 pos = transform.position; //set this vector3= player position
        if (transform.position.x >= 7.5)
        {
            pos.x = 7.5f; ;
        }
        if (transform.position.y >= 5)
        {
            pos.y = 5f;
        }
        if (transform.position.x <= -7.5)
        {
            pos.x = -7.5f;
        }
        if (transform.position.y <= -5)
        {
            pos.y = -5f;
        }
        transform.position = pos;

        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timer <= -3)
        {
            Instantiate(BacteriaPrefab, pos, Quaternion.identity);
            timer = 0;
            VirusScriptThing.bacteriaCount += 1;

        }

    }
}
