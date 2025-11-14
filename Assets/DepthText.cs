using System.Drawing;
using TMPro;
using UnityEngine;

public class DepthText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI DepthTextbox;
    GameManagerScript2 game;
    void Start()
    {
        game = FindFirstObjectByType<GameManagerScript2>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (game.maxdepth - game.depth >= 500)
        {
            DepthTextbox.text = "Depth:" + game.depth + "m";
        }
        
/*        if (game.maxdepth - game.depth <= 500)
        { 
            DepthTextbox.text= "Depth:"+ "<color=\"red\">game.depth</color>";
        }*/

    }
}
/*// Change the entire text to red
myTextMeshPro.text = "<color=\"red\">This text is now red!</color>";

// Or, change only a portion of the text to red
myTextMeshPro.text = "This is normal text, but <color=\"red\">this part is red</color>.";

// You can also use hexadecimal color codes for more specific colors
myTextMeshPro.text = "This text is <color=#FF0000>red using hex code</color>.";*/