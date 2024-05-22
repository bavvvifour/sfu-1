using UnityEngine;

public class takeball : MonoBehaviour
{
    public float pickUpRadius = 1f;
    public Transform handPosition; // Позиция руки для поднятия мяча
    private GameObject pickedBall; // Ссылка на подобранный мяч

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PickUpBall();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowBall();
        }
    }

    void PickUpBall()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickUpRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("ball"))
            {
                pickedBall = collider.gameObject;
                pickedBall.transform.position = handPosition.position; // Поднимаем мяч к руке персонажа
                pickedBall.transform.parent = transform; // Делаем персонажа родителем мяча
                break;
            }
        }
    }

    void ThrowBall()
    {
        if (pickedBall != null)
        {
            pickedBall.transform.parent = null; // Отсоединяем мяч от персонажа
            Rigidbody2D ballRigidbody = pickedBall.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
                ballRigidbody.velocity = new Vector2(5f, 5f); // Пример скорости броска мяча
            }
            pickedBall = null;
        }
    }
}
