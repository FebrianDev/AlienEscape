using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] bg;
    void Update()
    {
        for(int i = 0; i < bg.Length; i++)
        {
            bg[i].transform.position = Vector2.MoveTowards(bg[i].transform.position, new Vector2(-21.5f, bg[i].transform.position.y), 0.8f * Time.deltaTime);
            
            if(bg[i].transform.position.x <= -21.5f)
            {
                bg[i].transform.position = new Vector2(21.5f, bg[i].transform.position.y);
            }
        }
    }
}
