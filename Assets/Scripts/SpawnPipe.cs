using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{

    float timer = 0, jeda = 2f;
    public GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > jeda)
        {
            Instantiate(pipe, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
