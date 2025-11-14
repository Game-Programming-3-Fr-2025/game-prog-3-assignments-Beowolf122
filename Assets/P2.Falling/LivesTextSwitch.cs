using UnityEngine;

public class LivesTextSwitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    NinjaPlayerScript NinjaPlayerScript;
    void Start()
    {
        NinjaPlayerScript = FindFirstObjectByType<NinjaPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
