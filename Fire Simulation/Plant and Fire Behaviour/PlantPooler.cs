using System.Collections.Generic;
using UnityEngine;

public class PlantPooler : MonoBehaviour
{
    public static PlantPooler instance;

    [SerializeField]
    private List<GameObject> pooledPlants;
    [SerializeField]
    private int amountOfPlantsToPool;
    [SerializeField]
    private GameObject plantToPool;

    public List<GameObject> PooledPlants
    {
        get
        {
            return pooledPlants;
        }
    }

    public int AmountOfPlantsToPool
    {
        get
        {
            return amountOfPlantsToPool;
        }
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pooledPlants = new List<GameObject>();

        for (int i = 0; i < amountOfPlantsToPool; i++)
        {
            GameObject plant = Instantiate(plantToPool);
            plant.SetActive(false);
            pooledPlants.Add(plant);
        }
    }
    public GameObject GetPooledPlant()
    {
        for (int i = 0; i < pooledPlants.Count; i++)
        {
            if (!pooledPlants[i].activeInHierarchy)
            {
                return pooledPlants[i];
            }
        }

        return null;
    }

    public GameObject AddNewPlantToPool()
    {
        GameObject plant = Instantiate(plantToPool);
        plant.SetActive(true);
        pooledPlants.Add(plant);
        return plant;
    }
}