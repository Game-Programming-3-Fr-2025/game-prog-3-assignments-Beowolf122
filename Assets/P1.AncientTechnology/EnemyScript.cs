using System;
using UnityEngine;
using System.Collections.Generic;
public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int hp = 20;
    public int Countdown = 20;
    public int atk = 10;
    public GameObject Player;
    
    public GameObject GameManager;
    public bool entity = false;
    public bool calamity = true;
    public bool enemy = false;

    public List< GameObject > Temples;


    public GameObject MayanSunGodTrapTemple;
    public GameObject LibraryOfAlexandria;
    public GameObject TheOracle;
    public GameObject ScrollsOfInventionAndStrategy;
    public GameObject TabletsOfArchitecture;

    public bool EnemyBP=false;
    void Start()
    {
        if (entity==calamity) { entity = calamity; }
        else { entity = enemy; }
        //if random int is odd, become Monster (red). If even, become Calamity (Black). NOTE: default is enemy so far.

        //Idea: add all items into the list Temples with findObjectsWithTag("Knowledge") to quickly add them into the list
        //Fornow: manually add them
        Temples.Add(MayanSunGodTrapTemple);
        Temples.Add(LibraryOfAlexandria);
        Temples.Add (TheOracle);
        Temples.Add(ScrollsOfInventionAndStrategy);
        Temples.Add(TabletsOfArchitecture);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp<=0|| Countdown <= 0) { Destroy(gameObject); }
        if (entity == enemy) { };
        if (entity== calamity) { };

        if (Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)
            || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) &&EnemyBP==false)
        {            
            GameObject chosen = Temples[UnityEngine.Random.Range(0, Temples.Count)];
            Temples.Remove(chosen);
            Destroy(chosen.gameObject);
            /*//first reassign each game object to list element -1
            if (MayanSunGodTrapTemple) { }
            
           //will run throug
             int randomTempleSelect = UnityEngine.Random.Range(0, Temples.Count);
                 if (randomTempleSelect == Temples.Count) { Destroy(Temple5); Temples.Remove(Temples[Temples.Count-1]); } 
                 //destroy whoever's in last slot, then remove that item in list.
                 //PROBLEM: future iterations means that TempleX may already be destroyed but continue increasing the counter if chosen again
                 //Solution: after destroying TempleX, manually adjust the Temple Positions..?
            else if (randomTempleSelect == Temples.Count - 1) { Destroy(Temple4); Temples.Remove(Temples[Temples.Count - 2]); }
                 //if not last, check and repeat
            else if (randomTempleSelect == Temples.Count - 2) { Destroy(Temple3); Temples.Remove(Temples[Temples.Count - 3]); }
                 //same
            else if (randomTempleSelect == Temples.Count - 3) { Destroy(Temple2); Temples.Remove(Temples[Temples.Count - 4]); }
                 //same
            else if (randomTempleSelect == Temples.Count - 4) { Destroy(Temple1); Temples.Remove(Temples[Temples.Count - 5]); }
                 //same
*/

        };
        if (hp <= 0 || Countdown <= 0) { Destroy(gameObject); } //the win condition. entity gone

        if (EnemyBP == true) {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //combines both Find and Get Component. returns first 
                PlayerScript nameofProxyplayer = FindFirstObjectByType<PlayerScript>();
                //if enemyBP is true, pressing space will damage the player by their attack
                nameofProxyplayer.hp -= atk;
            }
        }



    }
}
