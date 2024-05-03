using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f; // Сила прыжка
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false; // Флаг, указывающий, находится ли персонаж на земле
    private float groundCheckRadius = 0.2f; // Радиус для проверки нахождения на земле
    public LayerMask groundLayer; // Слой, представляющий землю

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the GameObject.");
        }
    }

    void Update()
    {
        // Проверяем, находится ли персонаж на земле
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position, groundCheckRadius, groundLayer);

        // Получаем ввод с клавиатуры
        bool isMoveLeftKeyPressed = Input.GetKey(KeyCode.A);
        bool isMoveRightKeyPressed = Input.GetKey(KeyCode.D);

        // Устанавливаем анимацию в зависимости от направления движения и наличия горизонтального ввода
        if (isMoveLeftKeyPressed || isMoveRightKeyPressed)
        {
            animator.SetBool("stop", false);
            if (isMoveLeftKeyPressed)
            {
                transform.localScale = new Vector3(-5, 5, 1); // Разворачиваем персонажа влево
            }
            else
            {
                transform.localScale = new Vector3(5, 5, 1); // Разворачиваем персонажа вправо
            }
        }
        else
        {
            animator.SetBool("stop", true);
        }

        // Если персонаж на земле и была нажата клавиша прыжка
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Применяем вертикальную скорость для прыжка
        }

        // Применяем горизонтальное движение
        float horizontalVelocity = (isMoveLeftKeyPressed ? -1 : 0) + (isMoveRightKeyPressed ? 1 : 0);
        rb.velocity = new Vector2(horizontalVelocity * speed, rb.velocity.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}
