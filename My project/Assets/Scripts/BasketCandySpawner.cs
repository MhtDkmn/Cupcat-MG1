using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasketCandySpawner : MonoBehaviour
{
    public static BasketCandySpawner instance;
    public GameObject newBasketCandies;
    public GameObject[] basketCandies;
    public List<GameObject> basketCandyList;
    int candyCount;
    public TextMeshProUGUI CandyCount;
    GameObject counterUI;
    [SerializeField]
    private GameObject particles;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        counterUI = GameObject.Find("Canvas-Counter/Counter/GalpUI");
    }

    // Update is called once per frame
    void Update()
    {
        candyCount = basketCandyList.Count;
        CandyCount.text = candyCount.ToString();
        LifeIncrease();
    }

    public void SpawnBasketCandy()
    {
        Vector3 SpawnPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        int RandomCandy = Random.Range(0, basketCandies.Length);
        newBasketCandies = Instantiate(basketCandies[RandomCandy], SpawnPos, Quaternion.identity);
        basketCandyList.Add(newBasketCandies);
    }

    void LifeIncrease()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            foreach (GameObject bCand in basketCandyList)
            {

                Destroy(bCand);
                if (bCand != null)
                {
                    Instantiate(particles, bCand.transform.position, Quaternion.identity);
                }
            }
            if (candyCount > 15)
            {
                GameManager.instance.candyTolife();
            }

            basketCandyList.Clear();
        }
        if (candyCount >= 15)
        {
            counterUI.SetActive(true);
        }
        else
        {
            counterUI.SetActive(false);
        }
    }
}
