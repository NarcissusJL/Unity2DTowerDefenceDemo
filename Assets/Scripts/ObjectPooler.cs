using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] GameObject levelManager;
    [SerializeField] GameObject thisObject;
    public int enemyPoolSize;

    private List<GameObject> _enemyPool;
    private GameObject _poolContainer;
    private string _poolName;

    // Start is called before the first frame update
    void Awake()
    {
        _enemyPool = new List<GameObject>();
        _poolContainer = new GameObject($"Pool - {enemyPrefab.name}");
        
    }

    // Update is called once per frame
    private void CreatePooler()
    
    {
        for (int i = 0; i < enemyPoolSize; i++)
        {
           _enemyPool.Add(CreateIns());
        }
        
    }
    private GameObject CreateIns()
    {
        GameObject newInstance = Instantiate(enemyPrefab);
        newInstance.transform.SetParent(_poolContainer.transform);
        newInstance.SetActive(false);
        return newInstance;
    }
    public GameObject GetInstanceFromPool()
    {
        for (int i = 0; i < _enemyPool.Count; i++)
        {
            if(!_enemyPool[i].activeInHierarchy)
            {
                return _enemyPool[i];
            }
        }
        return CreateIns();
    }
    public void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
    }

    void Start(){
        _poolName = gameObject.name;
        if (_poolName == "Pooler1"){
            enemyPoolSize = levelManager.GetComponent<AsahdLevelManager>().enemy1Size;
        }
        else if(_poolName == "Pooler2"){
            enemyPoolSize = levelManager.GetComponent<AsahdLevelManager>().enemy2Size;
            
        }
        else if(_poolName == "Pooler3"){
            enemyPoolSize = levelManager.GetComponent<AsahdLevelManager>().enemy3Size;
        }

        
    }
    
}
