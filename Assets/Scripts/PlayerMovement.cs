using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 mousePos;
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        position = Vector2.Lerp(transform.position, mousePos, moveSpeed);
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.localScale = new Vector3(0.25f, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.localScale = new Vector3(-0.25f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}