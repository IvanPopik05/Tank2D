using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject objPrefab;

    [HideInInspector] public static GameObject obj;
    void Start()
    {
        obj = Instantiate(objPrefab, new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), objPrefab.transform.position.z), Quaternion.identity);
        Debug.Log($"Позиция объекта: {obj.transform.position}");
    }
    void Update()
    {
        
    }
}
