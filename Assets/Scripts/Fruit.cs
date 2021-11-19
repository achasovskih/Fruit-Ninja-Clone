using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject slicedFruitPrefab;
    [SerializeField] private float explosionRadius = 5f;
    private GameManager myGM;
    public int scoreAmount = 3;

    private void Start()
    {
        scoreAmount = 3;
        myGM = FindObjectOfType<GameManager>();
    }

    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        myGM.PlaySliceSound();

        Rigidbody[] rbOnSlised = inst.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody item in rbOnSlised)
        {
            item.transform.rotation = Random.rotation;
            item.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }

        if (slicedFruitPrefab.tag == "Banana")
        {
            myGM.IncreaseScore(scoreAmount);
        }
        else if (slicedFruitPrefab.tag == "Orange")
        {
            myGM.IncreaseScore(scoreAmount - 1);
        }
        else if (slicedFruitPrefab.tag == "Waterlemon")
        {
            myGM.IncreaseScore(scoreAmount - 2);
        }


        Destroy(gameObject);

        Destroy(inst, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade blade = collision.GetComponent<Blade>();

        if (!blade)
        {
            return;
        }

        CreateSlicedFruit();
    }
}
