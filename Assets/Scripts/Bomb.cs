using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade player = collision.GetComponent<Blade>();

        if (!player)
        {
            return;
        }

        FindObjectOfType<GameManager>().OnBombHit();
    }
}
