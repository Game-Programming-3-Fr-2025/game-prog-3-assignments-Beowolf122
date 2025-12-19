using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float MaxHP = 1000f;
    public float currentHP = 1000f;
    public float Atk = 100f;
    public float AtkCD = 3f;
    public float spd = 1f;

    public GameObject Player;
    BasePlayerScript BasePlayerScript;
    public bool Gamestart=false;
    public float distance;

    public float detectionRadius = 1f;
    public LayerMask targetLayers; // Specify which layers to detect

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BasePlayerScript=FindFirstObjectByType<BasePlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP<=0) { Destroy(gameObject); }
        AtkCD -= Time.deltaTime;

        //should continuously move towards the player
        //C= chased player, A=enemy moving,B=direction that still needs to be moved to... so player transform-self transform 
        distance = Vector2.Distance(Player.transform.position,transform.position);
        Vector2 direction = (Player.transform.position- transform.position).normalized;

        rb.linearVelocity = (spd * direction) / distance;

/*        //or... rotate the object to player's direction, then change linear velocity to move "forward"?
        transform.rotation=Quaternion.Euler(0,0,0);
*/
        
        //When close enough range, launches attack?
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, targetLayers);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("Detected object within range: " + hitCollider.gameObject.name);
            if (AtkCD <= 0) {
                BasePlayerScript.currentHP -= Atk;
                
                AtkCD = 3;
            }
        }
        //or when colliding, launches an attack, knocking the player back, with its own CD



    }
    //oncollisionEnter2D: when hit by attack, addforce backwards, small "stagger" effect
}

/*To find GameObjects within a certain physical distance, you can use Unity's physics functions like Physics.OverlapSphere() (for 3D)
or Physics2D.OverlapCircleAll() (for 2D):

 public float detectionRadius = 5f;
    public LayerMask targetLayers; // Specify which layers to detect

    void Update()
{
    Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, targetLayers);
    foreach (var hitCollider in hitColliders)
    {
        Debug.Log("Detected object within range: " + hitCollider.gameObject.name);}
            // Perform actions on the detected object*/