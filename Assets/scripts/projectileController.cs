using UnityEngine;
using UnityEngine.Tilemaps;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private bool toBeDestroyed = false;
    Tilemap tilemap;
    public int speed = 7;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
    }
    private void OnEnable()
    {
        if (rb2d != null)
        {
            rb2d.velocity = transform.up * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        tilemap = collision.gameObject.GetComponent<Tilemap>();
        if (collision.gameObject.GetComponent<Tank>() != null)
        {
            collision.gameObject.GetComponent<Tank>().TakeDamage();
        }
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        if (toBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }
    public void DestroyProjectile()
    {
        if (gameObject.activeSelf == false)
        {
            Destroy(this.gameObject);
        }
        toBeDestroyed = true;
    }
}