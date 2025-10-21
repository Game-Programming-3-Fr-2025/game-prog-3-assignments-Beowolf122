using JetBrains.Annotations;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public int Hp = 100;
    public float Timer = 60f;
    public GameObject Crumb;
    public int breadcrumbs = 100;
    //breadcrumbs present count?
    
    public GameObject Seagull;
    public float SeagullSpawnCD = 5f;
    public float SeagullSpawnCurrentCD = 5f;
    //seagulls present count?
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer<=0) { Debug.Log("You win!");
            Debug.Log("Damage dealt: Sum of all seagull's agg. level");
        }

        if (Hp <= 0 || breadcrumbs <= 0) { Debug.Log("You lose"); }

        if (Input.GetKeyDown(KeyCode.Mouse0)) { 
            Instantiate (Crumb, Input.mousePosition ,Quaternion.identity);//is spawning it in weird place
            breadcrumbs -= 1;
        }

        SeagullSpawnCurrentCD -= Time.deltaTime;

        if (SeagullSpawnCurrentCD <= 0)
        {
            SpawnSeagulls();
        }


    }
    private void SpawnSeagulls() //have it take in seagull count and breadcrumbs present
    {
        int B = Random.Range(-7, 8);
        Vector3 Xspawner = new Vector3(B, 6, 0);

        Instantiate(Seagull, transform.position = Xspawner, Quaternion.identity); //run this code for however many crumbs present
        //each seagull reduces 
        
    }
}
