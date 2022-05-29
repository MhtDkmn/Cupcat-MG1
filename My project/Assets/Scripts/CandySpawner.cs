using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public GameObject[] Candies;
    GameObject[] cCandies;
    [SerializeField]
    private float spawnMaxPos;

    float randomSecs;

    float randomSecsSlower;

    public static CandySpawner instance;

    private void Awake()
    {
        
            instance = this;
        randomSecs = Random.Range(0.5f, 1f);
        randomSecsSlower = Random.Range(2.5f, 3.5f);

    }
    // Start is called before the first frame update
    void Start()
    {

        StartCandies();
        Invoke("StartCandiesSlower", 15f);
        Invoke("StartCandiesSlower", 30f);


    }

    // Update is called once per frame
    void Update()
    {
        turnLeft();
    }


    void spawnCandy()
    {
        float randomSpawnPos = Random.Range(-spawnMaxPos, spawnMaxPos);
        Vector3 randomPos = new Vector3(randomSpawnPos, transform.position.y, transform.position.z);
        int randomCandy = Random.Range(0, Candies.Length);
        Instantiate(Candies[randomCandy], randomPos, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }


 

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            spawnCandy();
            yield return new WaitForSeconds(randomSecs);
        }
    }


    IEnumerator SpawnCandiesSlower()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            spawnCandy();
            yield return new WaitForSeconds(randomSecsSlower);
        }
    }

    void StartCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    void StartCandiesSlower()
    {
        StartCoroutine("SpawnCandiesSlower");
    }

    public void StopCandies()
    {
        StopCoroutine("SpawnCandies");
    }

    public void turnLeft()
    {
        float RandomRotZ = Random.Range(0.25f, 1.25f);
        cCandies = GameObject.FindGameObjectsWithTag("Candy");
        foreach (GameObject go in cCandies)
        {
            go.transform.Rotate(0, 0, RandomRotZ);
        }
    }











}
















