using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelocity = 0.1f;

    private Rigidbody2D rb;
    private Vector3 lastMousePos;
    private Vector3 mouseVelocity;
    private Collider2D bladeCollider;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bladeCollider = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        bladeCollider.enabled = IsMouseMoving();
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool IsMouseMoving()
    {
        Vector3 curMousPos = transform.position;
        float traveled = (lastMousePos - curMousPos).magnitude;

        lastMousePos = curMousPos;

        if (traveled > minVelocity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
