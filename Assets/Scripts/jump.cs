using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool jumping = false;
    private float initialYPosition;
    private float currentJumpHeight = 0f;
    public float gravity = 0.5f;
    public float jumpForce = 10f;
    public float groundLevel = 0f;

    private void Start()
    {
        initialYPosition = transform.position.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !jumping)
        {
            jumping = true;
            currentJumpHeight = 0f; // Сбрасываем текущую высоту прыжка
        }

        if (jumping)
        {
            currentJumpHeight += jumpForce * Time.deltaTime; // Увеличиваем текущую высоту прыжка
            float newYPosition = initialYPosition + currentJumpHeight;
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

            jumpForce -= gravity;

            if (currentJumpHeight <= 0f)
            {
                jumping = false;
                jumpForce = 10f; // Сбрасываем силу прыжка
            }
        }
    }
}
