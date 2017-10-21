using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolerManager : MonoBehaviour {
    [SerializeField]
    public static PoolerManager singleton;
    [Tooltip("0 or negative for limiteless"), Range(0,512)]
    public int maxPoolSize = 64;

    //TODO:Not serialize, make empty objects within groups
    [SerializeField]
    List<List<Transform>> objPool = new List<List<Transform>>();
    [SerializeField]
    Dictionary<string, int> objDic = new Dictionary<string, int>();
    [SerializeField]
    List<Transform> objGroup = new List<Transform>();

    public enum WhenPoolLimit { doNothing = 0, callsFirstOne = 1};
    public WhenPoolLimit whenPoolLimit = 0;


    private void Awake()
    {
        print(objDic.Count);
        AssignSingleton();
    }

    public void AssignSingleton()
    {
        singleton = this;
    }

    public Transform AddToThePool(Transform gObj)
    {
        string name = gObj.name;
        if(objPool==null || objDic == null)
        {
            objPool = new List<List<Transform>>();
            objDic = new Dictionary<string, int>();
        }
        if (!objDic.ContainsKey(name))
        {
            int ID = objPool.Count;
            objDic.Add(gObj.name, ID);
            Transform newObj = Instantiate(gObj) as Transform;
            List<Transform> newObjList = new List<Transform>();
            newObjList.Add(newObj);
            newObj.gameObject.SetActive(false);
            objPool.Add(newObjList);
            return newObj;
        }
        else
        {
            Debug.LogWarning("Object already in the pool.");
            return objPool[objDic[name]][0];
        }        
    }

    [ContextMenu("Clean Pool")]
    void CleanPool()
    {
        if (objPool != null)
        {
            for (int i = 0; i < objPool.Count; i++)
            {
                for (int j = 0; j < objPool[i].Count; j++)
                {
                    DestroyImmediate(objPool[i][j].gameObject);
                }
            }
            for (int i = 0; i < objPool.Count; i++)
            {
                objPool[i] = null;
            }
        }        
        objPool = null;
        objDic = null;
        Debug.LogWarning("Pool cleaned!");
    }

    public Transform Instantiate(int ID)
    {
        Transform spawnObj = SearchForAvaliable(ID);
        if (spawnObj != null)
        {
            spawnObj.gameObject.SetActive(true);
        }
        return spawnObj;
        //objPool[objDic[gameObjName]]
    }

    public Transform Instantiate(string gameObjName)
    {
        int ID = objDic[gameObjName];        
        Transform spawnObj = SearchForAvaliable(ID);
        if (spawnObj != null)
        {
            spawnObj.gameObject.SetActive(true);            
        }
        return spawnObj;
        //objPool[objDic[gameObjName]]
    }

    public Transform Instantiate(string gameObjName, Vector3 targetPosition)
    {
        int ID = objDic[gameObjName];
        Transform spawnObj = SearchForAvaliable(ID);
        if (spawnObj != null)
        {
            spawnObj.gameObject.SetActive(true);
            spawnObj.position = targetPosition;
        }
        return spawnObj;
        //objPool[objDic[gameObjName]]
    }

    /// <summary>
    /// Fills the pool of objects before hand
    /// </summary>
    /// <param name="Name of the object type which will be pooled"></param>
    public void FillPool(string gameObjName)
    {
        if (maxPoolSize > 0 && maxPoolSize < 1024)
        {
            int ID = objDic[gameObjName];
            for (int i = 0; i < maxPoolSize; i++)
            {
                Transform newObj = Instantiate(ID);
                if (newObj == null)
                {
                    Debug.LogError("Instantiation unsuccessful");
                    return;
                }
            }
        }
        else if(maxPoolSize<=0)
        {
            Debug.LogError("Can not pre warm a limitless pool");
        }
        else
        {
            Debug.LogError("Size of the pool is too big");
        }
    }

    private Transform SearchForAvaliable(int ID)
    {
        for (int i = 0; i < objPool[ID].Count; i++)
        {
            if (!objPool[ID][i].gameObject.activeSelf)
            {
                return objPool[ID][i];
            }
        }
        if (maxPoolSize == 0 ||
            objPool[ID].Count<maxPoolSize)
        {
            Transform newObj = Instantiate(objPool[ID][0]) as Transform;
            objPool[ID].Add(newObj);
            return newObj;
        }
        switch (whenPoolLimit)
        {
            case WhenPoolLimit.doNothing:
                return null; 
            case WhenPoolLimit.callsFirstOne:
                return objPool[ID][0];
            default:
                return null;
        }        
    }


    [ContextMenu("Disable Pool")]
    public void DeInstantiateAll()
    {
        for (int i = 0; i < objPool.Count; i++)
        {
            for (int j = 0; j < objPool[i].Count; j++)
            {
                objPool[i][j].gameObject.SetActive(false);
            }
        }
    }
}
