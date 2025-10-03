using UnityEngine;

public class BacteriaDestroyerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool pursue = false;
    //Rigidbody2D rigidbody2D;   

    void Start()
    {
        //rigidbody2D=GetComponent
    }

    // Update is called once per frame
    void Update()
    {
        if (pursue == false) { }
        else { }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(gameObject, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
