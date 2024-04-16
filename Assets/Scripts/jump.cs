using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
private bool jumping = false;
    public float gravity = 0.5f;
    public float jumpHeight = 10f;
    public float groundLevel = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            jumping = true;
        }

        if (jumping)
        {
            transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
            jumpHeight -= gravity;
            if (transform.position.y <= groundLevel)
            {
                transform.position = new Vector3(transform.position.x, groundLevel, transform.position.z);
                jumping = false;
                jumpHeight = 10f;
            }
        }
    }
}
