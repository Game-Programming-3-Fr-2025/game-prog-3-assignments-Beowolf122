using UnityEngine;
using TMPro;

public class LivesTextSwitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    NinjaPlayerScript NinjaPlayerScript;
    GameManagerScript2 gameManagerScript2;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI ComboText;
    void Start()
    {
        NinjaPlayerScript = FindFirstObjectByType<NinjaPlayerScript>();
        gameManagerScript2 = FindFirstObjectByType<GameManagerScript2>();
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "HP: "+ NinjaPlayerScript.ninjahp;
        ComboText.text = "Combo: " + Mathf.Ceil(gameManagerScript2.combometer);
    }
}
