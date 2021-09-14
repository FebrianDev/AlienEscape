using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private AudioSource coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            DataPlayer.score += 1;
            coin.PlayOneShot(coin.clip);
        }
    }
}
