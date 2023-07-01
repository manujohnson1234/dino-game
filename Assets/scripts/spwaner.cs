using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwaner : MonoBehaviour
{
    // Start is called before the first frame update

    [System.Serializable]
    public struct SpwanableObject
    {
        public GameObject prefab;
        
        public float spwanChance;
    }

    public SpwanableObject[] objects;


    public float minSpawnerRate = 1f;
    public float maxSpawnerRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spwan), Random.Range(minSpawnerRate, maxSpawnerRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spwan()
    {
        float spawnChance = Random.value;

        foreach (var obj in objects)
        {
            if(spawnChance < obj.spwanChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }
            spawnChance -= obj.spwanChance; 
        }
        Invoke(nameof(Spwan), Random.Range(minSpawnerRate, maxSpawnerRate));
    }

}
