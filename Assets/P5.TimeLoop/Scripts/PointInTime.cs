using Unity.Mathematics;
using UnityEngine;

public class PointInTime //monobehavior just gives you access to start/update, and allows it to interact with other scripts while being assigned in the inspector
{
    public Vector3 position;
    public quaternion rotation;

    public PointInTime (Vector3 _position, quaternion _rotation) //makes a constructor, that needs those 2 things. You can even add velocity and angular velocity
    {
        position = _position;
        rotation = _rotation;
        //Then in your list, you wouldn't store a list of Vector3's, you'd store a list of "PtInTime",
        //and in those if-statements, instead of using positions, you'd do "PointInTime pointInTime = pointsInTime [0] to store the info
        //then set your transform.positions/rotations to be equal to pointInTime.position/rotation

        //likewise, in recording in the insert, instead of a transform.position, you'd add a new PointInTime(x,y) that takes in the current 
        //position and rotation as transform.position/rotation in x and y.

    }
}
/*

To those of you who want to make this code more performant here are a few things to keep in mind:

-Because we're only storing simple values, consider using a struct instead of a class.
- Because we're "overwriting" values consider using an array with a fixed length & simply swapping in/out values when we reach its end.

Using generic lists is handy but will always be slower than an array with a given size.

Also to those of you who suggest using a Stack. 
This makes perfect sense and was actually what I started by using. 
However we need the ability to overwrite values, so we need to access items at the bottom of the list, which a stack by definition won't do. 

TODO: code clean up shortcut? 
*/



