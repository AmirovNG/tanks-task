using UnityEngine;
using UnityEngine.Tilemaps;

public class projectileController : MonoBehaviour
{
    [SerializeField]
    bool toBeDestroyed = false;
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
    //function called from Tank to destroy the projectile when the tank is destroyed
    public void DestroyProjectile()
    {
        //if the projectile is already inactive, destroy the projectile gameobject
        if (gameObject.activeSelf == false)
        {
            Destroy(this.gameObject);
        }
        //set flag toBeDestroyed so that if projectile is still active checking the flag toBeDestroyed during onDisable to destroy the projectile
        toBeDestroyed = true;
    }
}