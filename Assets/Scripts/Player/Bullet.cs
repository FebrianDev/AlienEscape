using UnityEngine;
using System.Collections;
public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip [] clip;
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 4f);
        
        if(transform.position.x > 15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !DataPlayer.invisible)
        {
            DataPlayer.health -= 1;

            if(DataPlayer.health <= 0)
            {
                audio.PlayOneShot(clip[1]);
            }
            else
            {
                audio.PlayOneShot(clip[0]);
            }

            StartCoroutine(DestroyBullet());


        }

        if (collision.gameObject.tag.Equals("Shield"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Pipe"))
        {
            Destroy(GameObject.FindWithTag("Pipe"));
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
