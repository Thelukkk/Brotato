using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] float speed = 2.0f;

    private int currentHealth;

    Animator anim;
    Rigidbody2D rb;

    Transform target; //follow target like player

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;

            var playerToTheRight = target.position.x > transform.position.x;
            transform.localScale = new Vector2(playerToTheRight ? -1 : 1, 1);
        }
    }

    public void Hit(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hit");

        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
