using System.Collections.Generic;
using UnityEngine;

public class RewindTimeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isrewinding = false;
    List<Vector3> Positions;
    Rigidbody2D rb;
    void Start()
    {
        Positions = new List<Vector3>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StopRewind();
        }
    }
    void FixedUpdate()
    {
        if (isrewinding) { Rewind(); }
        else { Record(); }


    }
    void Record()
    {
        //if you only want to record and keep track of the last couple frames
        //(because it'd be extremely intensive to do as objects and stuff get more per frame)
        //, you can set a limit, like:
        //if pointsInTime.Count> 50 (fixed updates run 50 frames a second, so this checks if 1 second has gone by)
        //devices and stuff may still run on a different fixed update

        //thus, instead of 50: you can do "1f/Time.fixedDeltaTime" to get the
        //*fixeddeltatime=the amount of time that runs between frames. or time per frame. doing above will get frame per time
        //then youd multiply this by however many seconds you want to rewind by.

        //you also need to make sure what comes out is an integer, so do a Mathf.Round() the entire value.
        //finally, inside this if statement, List.RemoveAt(List.Count-1)
        //because oldest entries are at the bottom of the list

        // you can also do positions.add which will add newest entries towards last index
        Positions.Insert(0, transform.position); //inserts it where, and whatever we're inserting
                                                 //you can also record the objects rotation, scale, and even their velocity,



    }
    void Rewind()
    {
        if (Positions.Count > 0) //so we dont get an error from removing list

        {
            transform.position = Positions[0];
            Positions.RemoveAt(0);
        }
        else { StopRewind(); }
    }
    public void StartRewind()
    {
        isrewinding = true;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; //unity is still applying physics while rewinding
    }
    public void StopRewind()
    {
        isrewinding = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        //rb.isKinematic=false; if its using 3D only
    }
}
