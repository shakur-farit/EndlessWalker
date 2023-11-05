using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance;

    [SerializeField] private PoolItem[] _poolItems;

    private Dictionary<int, Queue<GameObject>> _poolQueue = new Dictionary<int, Queue<GameObject>>();
    private Dictionary<int, bool> _growAnleBool = new Dictionary<int, bool>();
    private Dictionary<int, Transform> _parents = new Dictionary<int, Transform>();

    private void Awake()
    {
        Instance = this;

        PoolInit();
    }

    private void PoolInit()
    {
        GameObject pooGroup = new GameObject("Pool Group");

        for (int i = 0; i < _poolItems.Length; i++)
        {
            GameObject uniquePool = new GameObject(_poolItems[i].PoolObject.name + " Group");
            uniquePool.transform.SetParent(pooGroup.transform);

            int objId = _poolItems[i].PoolObject.GetInstanceID();
            _poolItems[i].PoolObject.SetActive(false);

            _poolQueue.Add(objId, new Queue<GameObject>());
            _growAnleBool.Add(objId, _poolItems[i].GrowAble);
            _parents.Add(objId, uniquePool.transform);

            for (int j = 0; j < _poolItems[i].PoolAmount; j++)
            {
                GameObject temp = Instantiate(_poolItems[i].PoolObject, uniquePool.transform);
                _poolQueue[objId].Enqueue(temp);
            }
        }
    }

    public GameObject UseObject(GameObject obj, Vector3 pos, Quaternion rot)
    {
        int objId = obj.GetInstanceID();

        GameObject temp = _poolQueue[objId].Dequeue();

        if (temp.activeInHierarchy)
        {
            if (_growAnleBool[objId])
            {
                _poolQueue[objId].Enqueue(temp);
                temp = Instantiate(obj, _parents[objId]);
                temp.transform.position = pos;
                temp.transform.rotation = rot;
                temp.SetActive(true);
            }
            else
            {
                temp = null;
            }
        }
        else
        {
            temp.transform.position = pos;
            temp.transform.rotation = rot;
            temp.SetActive(true);
        }

        _poolQueue[objId].Enqueue(temp);
        return temp;
    }

    public void ReturnObject(GameObject obj, float delay = 0f)
    {
        if (delay == 0f)
        {
            obj.SetActive(false);
        }
        else
        {
            StartCoroutine(DelayReturn(obj, delay));
        }
    }

    private IEnumerator DelayReturn(GameObject obj, float delay)
    {
        while (delay > 0f)
        {
            delay -= Time.deltaTime;
            yield return null;
        }

        obj.SetActive(false);
    }
}

[System.Serializable]
public class PoolItem
{
    public GameObject PoolObject; // obj of populate
    public int PoolAmount; // start amount of obj
    public bool GrowAble; // can amoutn grow if start amout wasn't enough
}
