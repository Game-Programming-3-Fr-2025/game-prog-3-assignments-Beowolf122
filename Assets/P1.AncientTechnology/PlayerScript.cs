using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Wisdom = 0;
    public int Maxhp = 20;
    public int hp = 1;
    public int atk = 1;
    public int def = 1;
    public int surv = 0;

    public bool PlayerBP = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0) { Destroy(gameObject); }
        if (hp > Maxhp) { hp = Maxhp; }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)
    || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) && PlayerBP == false) { hp += surv; }

        if (PlayerBP == true)
        {

            EnemyScript enemyScript = FindFirstObjectByType<EnemyScript>();
            //If wisdom isn't 0, then add/subtract to all stats for each pt of wisdom then set it to 0.
            if (Wisdom != 0)
            {
                Maxhp += Wisdom;
                hp += Wisdom;
                atk += Wisdom;
                def += Wisdom;
                surv += Wisdom;
                Wisdom = 0;
            }
            //If def>0, reduce enemy attack by def, then set def to 0.
            if (def != 0)
            {
                enemyScript.atk -= def;
                def = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hp += surv;
                //THen: pressing space will heal player by their surv
                enemyScript.hp -= atk;
                //and will reduce enemy hp by attack 
            }
        }
    }
}
