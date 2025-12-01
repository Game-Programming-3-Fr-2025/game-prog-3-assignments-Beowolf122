using UnityEngine;
using TMPro;

public class LivesTextSwitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    NinjaPlayerScript NinjaPlayerScript;
    public TextMeshProUGUI LivesText;
    void Start()
    {
        NinjaPlayerScript = FindFirstObjectByType<NinjaPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "HP: "+ NinjaPlayerScript.ninjahp;
    }
}
