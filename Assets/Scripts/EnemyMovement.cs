using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player, pointPos;
    public GameObject bullet;
    float timer, jeda = 3.5f;

    [SerializeField] private AudioSource shoot;

    void Update()
    {
         transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, player.position.y), 0.05f);

        timer += Time.deltaTime;
        if(timer > jeda)
        {
            shoot.PlayOneShot(shoot.clip);
            Instantiate(bullet, pointPos.position, pointPos.rotation);
            timer = 0f;
        }
    }
}
