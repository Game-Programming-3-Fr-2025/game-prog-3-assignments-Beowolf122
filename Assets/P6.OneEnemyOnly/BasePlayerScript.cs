using UnityEngine;

public class BasePlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float MaxHP = 1000f;
    public float currentHP = 1000f;
    public float Atk = 100f;
    public float Def = 50f;
    public float spd = 2f;
    public float atkspd = 2;
    public float detectionradius = 1;
    public Vector3 vel; //used to store the gameobject's literal velocity. It's current velocity

    public GameObject Boss;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0) { Destroy(gameObject); }
        //focus on one class for now:

        rb.linearVelocity = vel;

        float desiredX; //what the current velocity should lerp to

        //If we're hitting keys we move in that direction
        if (Input.GetKey(KeyCode.RightArrow))
        {
            desiredX = spd; //set the desired velocity= to speed
            if (vel.x < 0) vel.x = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            desiredX = -spd;
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
            desiredY = spd; //set the desired velocity= to speed
            if (vel.y < 0) vel.y = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            desiredY = -spd;
            if (vel.y > 0) vel.y = 0;
        }
        else { desiredY = 0; }
        vel.y = Mathf.Lerp(vel.y, desiredY, 0.3f);

        //Click to attack, hold to charge atk
    }
}
