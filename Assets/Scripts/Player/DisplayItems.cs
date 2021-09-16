using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItems : MonoBehaviour
{
    [Header("Ghosts")] [SerializeField] private GameObject[] ghosts;
    [Header("Shields")] [SerializeField] private GameObject[] shields;

    void Start()
    {
        
        for (var i = 0; i < shields.Length; i++)
        {
            shields[i].SetActive(false);
            ghosts[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DataItem.Ghost == 1)
        {
            ItemsdHidden(shields, ghosts, 2);
        }
        else if (DataItem.Ghost == 2)
        {
            ItemsdHidden(shields, ghosts, 1);
        }
        else if (DataItem.Ghost == 3)
        {
            ItemsdHidden(shields, ghosts, 0);
        }
        else if (DataItem.Shield == 1)
        {
            ItemsdHidden(ghosts, shields, 2);
        }

        else if (DataItem.Shield == 2)
        {
            ItemsdHidden(ghosts, shields, 1);
        }
        else if (DataItem.Shield == 3)
        {
            ItemsdHidden(ghosts, shields, 0);
        }
        else
        {
            for (var i = 0; i < shields.Length; i++)
            {
                shields[i].SetActive(false);
                ghosts[i].SetActive(false);
            }
        }
    }

    private void ItemsdHidden(GameObject[] itemsNonActive, GameObject[] itemsActive, int pos)
    {
        foreach (var t in itemsNonActive)
        {
            t.SetActive(false);
        }

        for (var i = 0; i < itemsActive.Length; i++)
        {
            if (i == pos)
            {
                itemsActive[i].SetActive(true);
            }
            else
            {
                itemsActive[i].SetActive(false);
            }
        }
    }
}