using UnityEngine;

public class VirusScriptThing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int bacteriaCount = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bacteriaCount == 20) { Debug.Log("You win!"); }
        if (bacteriaCount <= 0) { Debug.Log("Wiped out"); }
    }
}
