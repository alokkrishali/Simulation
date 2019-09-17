using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField]
    GameObject[] Objects;

    public GameObject currentObject;

    void Start()
    {
        currentObject = Objects[0];
        currentObject.SetActive(true);
    }

    public void ShowObjectAtIndex(int Index)
    {
        currentObject.SetActive(false);
        currentObject = Objects[Index];
        currentObject.SetActive(true);
    }
}
