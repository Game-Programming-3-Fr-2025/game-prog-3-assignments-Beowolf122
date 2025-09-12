using UnityEngine;

public class TempleScript1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Knowledge")
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)
    || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5))
            {
                PlayerScript playerScript = FindFirstObjectByType<PlayerScript>();
                GameManagerScript gameManagerScript = FindFirstObjectByType<GameManagerScript>();
                playerScript.Wisdom += 1;

                if (gameObject.name == "StoneTabletsOfArchitecture" && Input.GetKeyDown(KeyCode.Alpha1)) {
                    playerScript.surv += 5;
                    playerScript.def += 4;
                    playerScript.Maxhp += 5;

                }

                if (gameObject.name == "Scrolls of Invention and Strategy" && Input.GetKeyDown(KeyCode.Alpha2)) {
                    playerScript.def += 4;
                    playerScript.atk += 4;
                    playerScript.surv += 2;
                }

                if (gameObject.name == "TheOracle" && Input.GetKeyDown(KeyCode.Alpha3)) {
                    playerScript.hp += 10;
                    playerScript.Wisdom += 1;
                    if (Random.value <= .5)

                    { Destroy(gameManagerScript.Fog); }
                    }

                if (gameObject.name == "LibraryOfAlexandria" && Input.GetKeyDown(KeyCode.Alpha4)) {
                    playerScript.Wisdom += 3;

                    if (Random.value <= .25) { 

                        gameManagerScript.destroyedtemples += 1;
                    Destroy(gameObject); 
                    }
                }

                if (gameObject.name == "MayanSunGodTrapTemple" && Input.GetKeyDown(KeyCode.Alpha5)) 
                {
                    playerScript.atk += 5;
                    playerScript.Maxhp += 10;
                    if (Random.value <= .3) { playerScript.hp -= 5; }
                        }

                //enums: making a drop down to select
            }
        }
    }
}
