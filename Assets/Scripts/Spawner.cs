using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitToSpawnPrefab;
    [SerializeField] private GameObject bombToSpawnPrefab;
    [SerializeField] private Transform[] spawnPlaces;
    [SerializeField] private GameManager manager;
    private float minWait = 0.3f;
    private float maxWait = 0.7f;
    private float minForce = 10f;
    private float maxForce = 20f;
    private float bombSpawnChance = 0.2f;
    private float bombSpawnChanceMax = 0.8f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
        bombSpawnChance = 0.2f;
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            float num = Random.value;

            if (num < bombSpawnChance)
            {
                GameObject bomb = Instantiate(bombToSpawnPrefab, t.position, t.rotation);

                bomb.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);

                Destroy(bomb, 5f);
            }
            else
            {

                GameObject fruit = Instantiate(fruitToSpawnPrefab[Random.Range(0, fruitToSpawnPrefab.Length)], t.position, Quaternion.Euler(-90, 0, 90));

                fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);

                Destroy(fruit, 5f);
            }
        }
    }

    public void DifficultyCheck()
    {
        if (manager.score > 50)
        {
            bombSpawnChance = 0.3f;
        }

        if (manager.score > 100)
        {
            bombSpawnChance = 0.4f;
        }

        if (manager.score > 150)
        {
            bombSpawnChance = 0.5f;

        }

        if (manager.score > 200)
        {
            bombSpawnChance = 0.6f;
        }

        if (manager.score > 250)
        {
            bombSpawnChance = 0.7f;
        }

        if (manager.score > 300)
        {
            bombSpawnChance = 0.8f;
        }


        if (bombSpawnChance > bombSpawnChanceMax)
        {
            bombSpawnChance = bombSpawnChanceMax;
        }
    }
}
