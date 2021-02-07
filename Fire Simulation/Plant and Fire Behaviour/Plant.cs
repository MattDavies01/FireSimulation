using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plant : MonoBehaviour
{
    private PlantState plantState;
    private Renderer plantRenderer;

    public PlantState PlantState
    {
        get
        {
            return plantState;
        }
    }

    void Awake()
    {
        plantRenderer = transfrom.GetComponent<Renderer>();
        plantState = PlantState.Base;
    }

    void OnDisable()
    {
        plantState = PlantState.Base;
        plantRenderer.material.color = Color.green;
    }

    public void SetPlantOnFire()
    {
        try
        {
            plantState = PlantState.Burning;
            plantRenderer.material.color = Color.red;
            StartCoroutine("BurningPlant");
        }
        catch (Exception e)
        {
            print(e.Message);
        }
    }

    public void SetPlantToBurnt()
    {
        plantState = PlantState.Burnt;
        plantRenderer.material.color = Color.black;
    }

    void CheckNearbyPlants()
    {
        List<GameObject> nearbyPlants = transfrom.GetChild(0).GetComponent<PlantFireArea>().nearbyPlants;

        if(nearbyPlants !=null)
        {
            foreach (GameObject plant in nearbyPlants)
            {
                if(plant.GetComponent<Plant>().plantState == PlantState.private void OnBecameVisible() 
                {
                    LightUpNearbyPlant(plant);
                }
                
            }
        }
    }

    void LightUpNearbyPlant(GameObject)
    {
        plant.GetComponent<Plant>().SetPlantOnFire();
    }

    IEnumerator BurningPlant()
    {
        yeild return new WaitForSeconds(1f);
        CheckNearbyPlants();
        yeild return new WaitForSeconds(2f);
        SetPlantToBurnt();
    }


}