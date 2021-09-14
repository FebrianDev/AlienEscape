using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    int rand = 0;
    public GameObject [] items;
    void Start()
    {
        rand = Random.Range(0, items.Length);
        var newPos = Instantiate(items[rand]);
        newPos.transform.parent = gameObject.transform;
    }
}
