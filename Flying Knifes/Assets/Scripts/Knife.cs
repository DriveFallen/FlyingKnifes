using UnityEngine;

public class Knife : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wood"))
        {
            _rb.velocity = Vector2.zero;
            transform.SetParent(collision.transform);
            _rb.gravityScale = 0f;
            GameManager.knifeCount -= 1;
        }

        if (collision.CompareTag("Knife"))
        {
            _rb.velocity = Vector2.down;
            _rb.gravityScale = 1;
            gameObject.tag = "Untagged";
            GameManager.knifeCount = 0;
        }

        if (collision.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            GameManager.fruitsCount -= 1;
        }
    }
}
