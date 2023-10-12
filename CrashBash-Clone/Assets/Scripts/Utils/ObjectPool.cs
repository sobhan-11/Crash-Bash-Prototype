using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Utility;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject pooledObject;
    [SerializeField] private int count;
    [SerializeField] private bool canGrow;
    private List<GameObject> pool=new();


    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (pooledObject.GetComponent<IPooledObject>() == null)
        {
            throw new System.Exception("invalid object to pool " + pooledObject.name);
        }

        for (var i = 0; i < count; i++)
        {
            CreatePooledObject();
        }
    }

    private GameObject CreatePooledObject()
    {
        var p = Instantiate(pooledObject, transform.position, transform.rotation);
        p.transform.parent = this.transform;
        p.gameObject.SetActive(false);
        p.GetComponent<IPooledObject>().SetPool(this);
        pool.Add(p);
        return p;
    }

    public bool IsPoolFor(GameObject g)
    {
        return pooledObject == g;
    }

    public T GetObject<T>() where T : MonoBehaviour
    {
        if (transform.childCount == 0)
        {
            if (!canGrow)
                return null;
            var newResult = CreatePooledObject().GetComponent<T>();
            newResult.transform.parent = null;
            newResult.gameObject.SetActive(true);
            return newResult;
        }

        var result = transform.GetChild(0).gameObject;
        result.transform.parent = null;
        // result.gameObject.SetActive(true);
        return result.GetComponent<T>();
    }
    

    public List<T> GetPool<T>() where T : MonoBehaviour
    {
        var result = new List<T>();
        for (int i = 0; i < pool.Count; i++)
        {
            var p=pool[i].GetComponent<T>();
            if (!p) return null;
            result.Add(p);
        }
        return result;
    }
}