using UnityEngine;

public class Jalan : MonoBehaviour
{
    public GameObject[] duri;
    public PolygonCollider2D[] polygons;
    
    void Update()
    {
        for (int i = 0; i < duri.Length; i++)
        {
            if (DataPlayer.invisible)
                polygons[i].enabled = false;
            else
                polygons[i].enabled = true;
        }

        for (int i = 0; i < duri.Length; i++)
        {
            duri[i].transform.position = Vector2.MoveTowards(duri[i].transform.position, new Vector2(-35f, duri[i].transform.position.y), 1f * Time.deltaTime);

            if (duri[i].transform.position.x <= -35f)
            {
                duri[i].transform.position = new Vector2(35f, duri[i].transform.position.y);
            }
        }
    }
}
