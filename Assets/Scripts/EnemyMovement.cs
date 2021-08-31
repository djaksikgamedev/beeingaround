using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float lifeLength;
    private float timeInGame;
    private Transform target;
    private int runX;
    private int runY;
    private float speed;
    private PolygonCollider2D col;

    private void Start()
    {
        col = GetComponent<PolygonCollider2D>();
        speed = GameController.instance.enemySpeed;
        runX = Random.Range(0, 2) * 2 - 1;
        runY = Random.Range(0, 2) * 2 - 1;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        timeInGame += Time.deltaTime;

        if (timeInGame <= lifeLength)
        {
            ChasePlayer();
        }
        else
        {
            StopChase();
            Destroy(gameObject, 3f);
        }
    }

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (target.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
        }
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void StopChase()
    {
        transform.position += new Vector3(runX, runY, 0) * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.EndGame();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            col.isTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            col.isTrigger = false;
        }
    }
}