using UnityEngine;

public class Pipe : MonoBehaviour
{
    float posY;
    public PolygonCollider2D pipeAtas, pipeBawah;

    public Transform posItem;
    public GameObject[] items;

    int rand = 0;

    void Start()
    {
        rand = Random.Range(0, items.Length);
        var newPos = Instantiate(items[rand], posItem.position, posItem.rotation);
        newPos.transform.parent = gameObject.transform;
        posY = Random.Range(-2f, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, posY), new Vector2(-20f, posY), 3f * Time.deltaTime);

        if (transform.position.x <= -20f)
            Destroy(gameObject);

        if (DataPlayer.invisible)
        {
            if(pipeAtas != null)
                pipeAtas.enabled = false;
            if(pipeBawah != null)
                pipeBawah.enabled = false;
        }
        else
        {
            if (pipeAtas != null)
                pipeAtas.enabled = true;
            if (pipeBawah != null)
                pipeBawah.enabled = true;
        }
    }
}
