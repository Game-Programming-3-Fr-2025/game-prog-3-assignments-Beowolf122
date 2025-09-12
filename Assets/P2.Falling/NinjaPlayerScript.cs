using UnityEngine;

public class NinjaPlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed = 5;
    public int ninjahp = 10;
    public Vector3 vel; //used to store the gameobject's literal velocity. It's current velocity
    public GameObject rangeRadius;
    Rigidbody2D rb;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (ninjahp<=0) { Destroy(gameObject); }

        rb.linearVelocity=vel;

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
        vel.y= Mathf.Lerp(vel.y, desiredY, 0.3f);

        //stop player from going out of bounds
        Vector3 pos = transform.position; //set this vector3= player position
        if (transform.position.x >= 7.5) {
            pos.x = 7.5f; ;
        }
        if (transform.position.y >= 5) {
            pos.y = 5f;
        }
        if (transform.position.x <= -7.5) {
            pos.x = -7.5f;
        }
        if (transform.position.y <= -5) {
            pos.y = -5f;
        }
        transform.position = pos;

        //Ontrigger stay stuff;

        
        //upon object in trigger area, check all objects around the player and select the closest one (marked as "chosen")
        //maybe also check the enemy tagging
        //if chosen's X is more than the players, pressing downright will destroy object+dash/teleport
        //if less than X, same but down left.
        //if difference of X value of the object is +- 1 , press only down.

        //future ideas: parryable objects
        //some objects cant be destroyed if sturdy/large enough.
        //in that case, press up to parry. up left will add force to the left, up right will add force to right

        //maybe keybind for up/down too? 

        //diff aspect ratio 16:9, 7.5 width
    }

}
