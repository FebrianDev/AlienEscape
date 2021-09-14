using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource gameOver;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer player;

    [Header("GameObject")]
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject lightInvisible;

    private Coroutine inv, shl;

    private void Start()
    {
        DataPlayer.score = 0;
        DataPlayer.isGameOver = false;
        DataPlayer.health = 3;
        DataPlayer.invisible = false;
        DataPlayer.shield = false;
        shield.SetActive(false);
        rigid = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (rigid != null && !DataPlayer.isGameOver)
            {
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.up * 4000f * Time.deltaTime);
            }
        }

        if (transform.position.x <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), 0.1f);
        }

        if (DataPlayer.shield)
            shield.SetActive(true);
        else
            shield.SetActive(false);

        if (DataPlayer.invisible)
        {
            lightInvisible.SetActive(true);
            player.color = new Vector4(255, 255, 255, 0.2f);
        }
        else
        {
            lightInvisible.SetActive(false);
            player.color = new Vector4(255, 255, 255, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Pipe") || collision.gameObject.tag.Equals("Duri"))
        {
            if (!DataPlayer.shield)
            {
                gameOver.PlayOneShot(gameOver.clip);
                DataPlayer.isGameOver = true;
            }
        }

        if (collision.gameObject.tag.Equals("HealthItem"))
        {
            Destroy(GameObject.FindWithTag("HealthItem"));

            if(DataPlayer.health < 3)
            {
                DataPlayer.health++;
            }
            else
            {
                DataPlayer.score++;
            }
        }

        if (collision.gameObject.tag.Equals("InvisibleItem"))
        {
            Destroy(GameObject.FindWithTag("InvisibleItem"));
            if (DataPlayer.shield)
            {
                StopCoroutine(nameof(ShieldActive));
                DataPlayer.shield = false;
            }
          
            if (DataPlayer.invisible)
            {
                DataPlayer.invisible = true;
                StopCoroutine(nameof(InvisibleActive));
                StartCoroutine(nameof(InvisibleActive));
            }
            else
            {
                DataPlayer.invisible = true;
                StartCoroutine(nameof(InvisibleActive));
            }
        }

        if (collision.gameObject.tag.Equals("ShieldItem"))
        {
            Destroy(GameObject.FindWithTag("ShieldItem"));
          
            if (DataPlayer.invisible)
            {
                StopCoroutine(nameof(InvisibleActive));
                DataPlayer.invisible = false;
            }

            if (DataPlayer.shield)
            {
                DataPlayer.shield = true;
                StopCoroutineShield();
                shl = StartCoroutine(nameof(ShieldActive));
            }
            else
            {
                DataPlayer.shield= true;
                shl = StartCoroutine(nameof(ShieldActive));
            }
        }
    }

    IEnumerator InvisibleActive()
    {       
        yield return new WaitForSeconds(5);
        DataPlayer.invisible = false;
    }

    public IEnumerator ShieldActive()
    {
        
        yield return new WaitForSeconds(5);
        DataPlayer.shield = false;
    }

    public void StopCoroutineShield()
    {
        if(shl != null)
        {
            StopCoroutine(nameof(ShieldActive)); 
        }
    }
}
