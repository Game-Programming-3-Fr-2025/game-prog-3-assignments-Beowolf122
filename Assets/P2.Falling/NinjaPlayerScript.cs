using System.Runtime.CompilerServices;
using UnityEngine;

public class NinjaPlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed = 5;
    public int ninjahp = 10;
    public Vector3 vel; //used to store the gameobject's literal velocity. It's current velocity
    Rigidbody2D rb;
    GameManagerScript2 gamemanager;
    public float SpecialmaxCD = 1;
    public float SpecialCD = 1;
    public bool Dodgestance = false;
    

    public float detectionRadius = 3f;
    public LayerMask targetLayers; // Specify which layers to detect
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gamemanager = FindFirstObjectByType<GameManagerScript2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ninjahp <= 0) { Destroy(gameObject); }
        {
            /*            rb.linearVelocity = vel;
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
                                    vel.y = Mathf.Lerp(vel.y, desiredY, 0.3f);*/

            if (Input.GetKeyDown(KeyCode.LeftArrow)) { rb.linearVelocityX = -Speed; }
            if (Input.GetKey(KeyCode.LeftArrow)) { rb.AddForceX(-Speed * Time.deltaTime); }
            if (Input.GetKeyUp(KeyCode.LeftArrow)) { rb.linearVelocityX = 0; }

            if (Input.GetKeyDown(KeyCode.RightArrow)) { rb.linearVelocityX = Speed; }
            if (Input.GetKey(KeyCode.RightArrow)) { rb.AddForceX(Speed * Time.deltaTime); }
            if (Input.GetKeyUp(KeyCode.RightArrow)) { rb.linearVelocityX = 0; }

            if (Input.GetKeyDown(KeyCode.DownArrow)) { rb.linearVelocityY = -Speed; }
            if (Input.GetKey(KeyCode.DownArrow)) { rb.AddForceY(-Speed * Time.deltaTime); }
            if (Input.GetKeyUp(KeyCode.DownArrow)) { rb.linearVelocityY = 0; }

            if (Input.GetKeyDown(KeyCode.UpArrow)) { rb.linearVelocityY = Speed; }
            if (Input.GetKey(KeyCode.UpArrow)) { rb.AddForceY(Speed * Time.deltaTime); }
            if (Input.GetKeyUp(KeyCode.UpArrow)) { rb.linearVelocityY = 0; }

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
        } //movement code

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, targetLayers);
        Debug.Log("OPTS: " + hitColliders.Length);
        Collider2D closestcollider = null; //the label to the closest collider
        float lastdistance = float.MaxValue; //The link to the "closest distance". always going to be true for the first object until switched. 
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("Detected object within range: " + hitCollider.gameObject.name);
            float distance = Vector2.Distance(hitCollider.transform.position, gameObject.transform.position);

            if (distance < lastdistance) //in going through each of them, if the current last distance is closer than the next one
            {
                lastdistance = distance; //set that object to the closest distance
                closestcollider = hitCollider; //the label, closest collider, is set to that object which is the closest at the moment
            }
        }

        SpecialCD-=Time.deltaTime;

        if (closestcollider != null && SpecialCD <= 0)
        {
            //dodge code:
            if (Input.GetKeyDown(KeyCode.RightShift)|| Input.GetKey(KeyCode.LeftShift)&&Dodgestance==false)
            {
                Dodgestance = true;
                //gives 2 combo? One for dodge, one for counter
                gamemanager.combometer += 1;
                Vector2 direction = (closestcollider.transform.position - transform.position).normalized;
                rb.AddForce(-direction*100);
                SpecialCD=SpecialmaxCD;
            }
            
            //Parry code:
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 direction = (closestcollider.transform.position - transform.position).normalized;
                closestcollider.attachedRigidbody.AddForce(direction * 2000);//make sure to knock it away
                rb.AddForce(-direction*100);
                gamemanager.combometer += 1;
                Debug.Log("Parry Performed");
                SpecialCD = SpecialmaxCD;
                //gives 1 combo
                if (gamemanager.combometer > 10)
                {
                    ninjahp += 1;
                }
            }
            if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)&& Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow)) 
            {
                //Dash Attack. Shud give 1 combo
                closestcollider.gameObject.SetActive(false);
                Vector2 direction = (closestcollider.transform.position - transform.position).normalized;
                rb.AddForce(direction);
                Destroy(closestcollider.gameObject);
                gamemanager.combometer += 1;
                gamemanager.depth -= 10;
                SpecialCD = SpecialmaxCD;
                if (gamemanager.combometer > 10)
                {
                    gamemanager.maxvelocity += 10;
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) && Dodgestance == true)
        {
            //Dodgecounter
            closestcollider.gameObject.SetActive(false);
            transform.position = closestcollider.transform.position;
            Destroy(closestcollider.gameObject);
            Debug.Log("dodge performed");
            Dodgestance = false;
            gamemanager.combometer += 1;
            if (gamemanager.combometer > 10)
            {
                gamemanager.depth -= gamemanager.combometer;
            }

        }
    }
    //3 moves: Dodge/Dodge Counter (shift), Dash Attack (up/down & right/left), Parry (Space)
        //Parry= up+right/left. Knocks away the object if light, if heavy, both player and object will be displaced
        //if object is light, dodge attack becomes a dash attack: teleports behind object and -depth,. If heavy, destroy the object and -velocity
        //
    }
