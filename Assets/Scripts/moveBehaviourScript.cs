using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBehaviourScript : MonoBehaviour
{
    public float speed = 5f; //MonoBehaviour
    private Rigidbody2D rb;
    Vector2 move;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the GameObject.");
        }
    }

    void Update()
    {
        if (rb != null)
        {
            move.x = Input.GetAxisRaw("Horizontal");

            if (move.x < 0)
            {
                transform.localScale = new Vector3(-5, 5, 1); // Разворачиваем персонажа влево
            }
            else if (move.x > 0)
            {
                transform.localScale = new Vector3(5, 5, 1); // Разворачиваем персонажа вправо
            }

            if (move.x != 0)
            {
                animator.SetBool("stop", false);
            }
            else
            {
                animator.SetBool("stop", true);
            }

            rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        }
    }
}
