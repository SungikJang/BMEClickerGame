using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyGenerator : MonoBehaviour
{

    [SerializeField] private GameObject EnemyPool;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private GameObject EnemyPrefab1;
    [SerializeField] private GameObject EnemyPrefab2;
    [SerializeField] private GameObject EnemyPrefab3;
    [SerializeField] private GameObject EnemyPrefab4;
    [SerializeField] private GameObject EnemyPrefab5;
    [SerializeField] private GameObject EnemyPrefab6;
    [SerializeField] private GameObject EnemyPrefab7;
    [SerializeField] private GameObject EnemyPrefab8;
    [SerializeField] private GameObject EnemyPrefab9;
    [SerializeField] private GameObject EnemyPrefab10;
    [SerializeField] private GameObject EnemyPrefab11;
    [SerializeField] private GameObject EnemyPrefab12;
    [SerializeField] private GameObject EnemyPrefab13;
    [SerializeField] private GameObject EnemyPrefab14;
    [SerializeField] private GameObject EnemyPrefab15;
    [SerializeField] private GameObject EnemyPrefab16;
    [SerializeField] private GameObject EnemyPrefab17;
    [SerializeField] private GameObject EnemyPrefab18;

    private string[] EnemyLists;
    
    private GameObject player;

    public GameObject Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }
    
        
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        EnemyLists = new string[]
        {
            EnemyPrefab.name, EnemyPrefab1.name, EnemyPrefab2.name, EnemyPrefab3.name, EnemyPrefab4.name,
            EnemyPrefab5.name, EnemyPrefab6.name, EnemyPrefab7.name, EnemyPrefab8.name, EnemyPrefab9.name,
            EnemyPrefab10.name, EnemyPrefab11.name, EnemyPrefab12.name, EnemyPrefab13.name, EnemyPrefab14.name,
            EnemyPrefab15.name, EnemyPrefab16.name, EnemyPrefab17.name, EnemyPrefab18.name
        };
        StartCoroutine(EnemySpone(EnemyLists, new Vector3(-9, 0, 0)));
        StartCoroutine(EnemySpone(EnemyLists, new Vector3(9, 0, 0)));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpone(string[] names, Vector3 point)
    {
        var time = 2.0f;
        while (true)
        {
            var ind = Random.Range(0, names.Length);
            var mon = Manager.Resource.Instantiate("Prefabs/Enemy/" + names[ind]);
            mon.transform.position = point;
            mon.transform.SetParent(EnemyPool.transform);
            mon.GetComponent<MobController>().Player = player;
            yield return new WaitForSeconds(time);
            time -= 0.01f;
        }
    }
    
}
