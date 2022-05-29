using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{

    public bool touched;
    List<gameobject> bCandies = new List<gameobject>();
    [SerializeField]
    private GameObject particles;
    SpriteRenderer rend;
    public Color myColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touched == true)
        {
            rend.material.color = Color.Lerp(rend.material.color, myColor, 0.05f);         
        }
    }

    private void OnCollisionEnter2D(Collision2D collis)
    {   
        if (collis.gameObject.tag == "Player")
        {
            BasketCandySpawner.instance.SpawnBasketCandy();
            Instantiate(particles, transform.position, Quaternion.identity);
            GameManager.instance.scoreIncrement();
            Destroy(gameObject);
        }

        if (collis.gameObject.tag == "Boundary")
        {
            touched = true;
            GameManager.instance.lifeDecrease();
        }
    }
}
