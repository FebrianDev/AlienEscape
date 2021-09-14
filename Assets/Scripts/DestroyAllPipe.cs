using UnityEngine;

public class DestroyAllPipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("AllPipe"))
        {
            Destroy(GameObject.FindWithTag("AllPipe"));
        }
    }
}
