using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Pipe") || collision.gameObject.tag.Equals("Duri"))
        {
         
            //     Destroy(GameObject.FindWithTag("Pipe"));
            new Player().StopCoroutineShield();
            
            StartCoroutine(DestroyShield());
            print("Shield Destroy");
        }
    }

    IEnumerator DestroyShield()
    {
        yield return new WaitForSeconds(0.1f);
        DataPlayer.shield = false;
        gameObject.SetActive(false);
    }
}
