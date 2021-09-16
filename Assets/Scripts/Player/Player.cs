using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [Header("Components")] [SerializeField]
    private AudioSource gameOver;

    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer player;

    [Header("GameObject")] [SerializeField]
    private GameObject shield;

    [SerializeField] private GameObject lightInvisible;

    private Coroutine inv, shl;

    private void Start()
    {
        DataPlayer.score = 0;
        DataPlayer.isGameOver = false;
        DataPlayer.health = 3;
        DataPlayer.invisible = false;
        DataPlayer.shield = false;
        DataPlayer.coin = 0;

        DataItem.Ghost = 0;
        DataItem.Shield = 0;

        shield.SetActive(false);
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log("Ghost " + DataItem.Ghost);
        Debug.Log("Shield " + DataItem.Shield);
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

            if (DataPlayer.health < 3)
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
            DataItem.Ghost += 1;
            DataItem.Shield = 0;
            Destroy(GameObject.FindWithTag("InvisibleItem"));
            if (DataItem.Ghost == 3)
            {
                if (DataPlayer.shield)
                {
                    StopCoroutine(nameof(ShieldActive));
                    DataPlayer.shield = false;
                    DataItem.Ghost = 0;
                }

                if (DataPlayer.invisible)
                {
                    DataPlayer.invisible = true;
                    if (inv != null)
                        StopCoroutine(nameof(InvisibleActive));
                    inv = StartCoroutine(nameof(InvisibleActive));
                    DataItem.Ghost = 0;
                }
                else
                {
                    DataItem.Ghost = 0;
                    DataPlayer.invisible = true;
                    inv = StartCoroutine(nameof(InvisibleActive));
                }
            }
        }

        if (collision.gameObject.tag.Equals("ShieldItem"))
        {
            DataItem.Ghost = 0;
            DataItem.Shield += 1;
            Destroy(GameObject.FindWithTag("ShieldItem"));
            if (DataItem.Shield == 3)
            {
                if (DataPlayer.invisible)
                {
                    StopCoroutine(nameof(InvisibleActive));
                    DataPlayer.invisible = false;
                    DataItem.Shield = 0;
                }

                if (DataPlayer.shield)
                {
                    DataPlayer.shield = true;
                    StopCoroutineShield();
                    shl = StartCoroutine(nameof(ShieldActive));
                    DataItem.Shield = 0;
                }
                else
                {
                    DataItem.Shield = 0;
                    DataPlayer.shield = true;
                    shl = StartCoroutine(nameof(ShieldActive));
                }
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
        if (shl != null)
        {
            StopCoroutine(nameof(ShieldActive));
        }
    }
}