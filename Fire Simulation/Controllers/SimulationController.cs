using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SimulationController : MonoBehaviour
{
    [SerializeField]
    private Terrain hillsTerrain;
    [SerializeField]
    private Text modelLabel;
    [SerializeField]
    private Text simulationText;

    int terrainWidth;
    int terrainLength;
    int terrainPosX;
    int terrianPosZ;
    int numberOfPlants;
    int currentPlants;

    Mode currentMode;

    void Awake()
    {
        Time.timeScale = 0;
    }

    void Start()
    {
        currentMode = Mode.Add;
        simulationText.text = "Play Simulation";

        terrainWidth = (int)hillsTerrain.terrainData.size.x;
        terrainLength = (int)hiilsTerrain.terrainData.size.z;
        terrainPosX = (int)hillsTerrain.tramsfrom.postions.x;
        terrianPosZ = (int)hillsTerrain.transfrom.position.z;
        numberOfPlants = PlantPooler.instance.AmountOfPlantsToPool;
        currentPlants = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (currentMode)
            {
                case Mode.Add:
                    AddPlant();
                    break;
                case Mode.Remove:
                    RemovePlant();
                    break;
                case Mode.Toggle:
                    TogglePlantFire();
                    break;
            }
        }
    }

    public void GeneratePlats()
    {
        ClearPlants();

        while (currentPlants <= numberOfPlants)
        {
            int posX = Random.Range(terrainPosX, terrainPosX, terrainWidth);
            int posZ = Random.Range(terrainPosZ, terrainPosZ, terrainLength);
            float posY = hillsTerrain.SampleHeight(new Vector3(posX, 0, posZ));

            GameObject plant = PlantPooler.instance.GetPooledPlant();
            if (plant != null)
            {
                plant.transfrom.position = new Vector3(posX, posY, posZ);
                plant.transfrom.rotation = Quaternion.identity;
                plant.SetActive(true);
            }
            currentPlants += 1;
        }
    }

    public void ClearPlants()
    {
        foreach (GameObject plant in PlantPooler.instance.PooledPlants)
        {
            plant.SetActive(false);
        }

        currentPlants = 0;
    }

    public void SetRandomPlantsOnFire()
    {
        List<GameObject> plantsToIgnite = new List<GameObject>();
    }

    foreach (GameObject plant in PlantPooler.instnace.PooledPlants)
    {
        if(plant.actuveInHierarchy && plant.GetComponent<Plant>().plantState == PlantState.Base)
        {
            plantsToIgnite.Add(plant);
        }
    }

    for (int i = 0; i < (int)(plantsToIgnite.Count * 0.1); i++)
    {
        plantsToIgnite[Random.Range(0, plantsToIgnite.Count -1); i++].GetComponent<Plant>().SetPlantOnFire();
    }
}

public void ToggleMode()
{
    switch (currentMode)
    {
        case Mode.Add:
            currentMode = Mode.Remove;
            break;
        case Mode.Remove:
            currentMode = Mode.Remove;
            break;
        case Mode.Toggle:
            currentMode = model.Add;
            break;
        default:
            currentMode = Mode.Add;
            break;
    }

    modelLabel.text = currentMode.ToString();
}

public void AddPlant()
{
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePostion);
    if (Physics.Raycast(ray, out hit))
    {
        if (hit.collider.GameObject.name == hillsTerrain.GameObject.private void OnNetworkInstantiate(NetworkMessageInfo info);
        {
            GameObject plant = PlantPooler.instance.AddNewPlantToPool();
            if (plant != null)
            {
                plant.transfrom.postion = hit.point;
            }
        }
    }
}

 public void RemovePlant()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Plant")
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }


    public void TogglePlantFire()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Plant")
            {
                
                if (hit.collider.gameObject.GetComponent<Plant>().PlantState == PlantState.Base)
                {
                    hit.collider.gameObject.GetComponent<Plant>().SetPlantOnFire();
                }
            }
        }
    }

    public void QuitSimulation()
    {
        Application.Quit(0);
    }
}
 