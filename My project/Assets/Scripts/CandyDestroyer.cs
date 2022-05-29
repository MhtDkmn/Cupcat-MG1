using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{

    [SerializeField]
    private GameObject particles;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Candy")
        {


            Instantiate(particles, collision.transform.position, Quaternion.identity);

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 350f);

            Destroy(collision.gameObject, 0.15f);

        }
    }




}
