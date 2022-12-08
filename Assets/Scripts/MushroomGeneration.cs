﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MushroomGeneration : MonoBehaviour
{
    public GameObject mushroomPrefab;
    GameObject mushroomNodes;
    public int numberOfNodes;
    // Start is called before the first frame update
    void Start()
    {
        // Get the game object that contains all the possible spawning points for the mushrooms.
        mushroomNodes = GameObject.Find("Mushroom Nodes");
        numberOfNodes = mushroomNodes.transform.childCount - 1; // subtract one, need to account for starting index of 0;
        Debug.Log(numberOfNodes);
        SpawnMushroom(mushroomNodes.transform.GetChild(0).gameObject);
        
        Debug.Log(mushroomNodes.transform.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMushroom(GameObject spawnPoint)
    {
        // check to see if spawnpoint already has a mushroom. If it does, don't spawn another one
        if(spawnPoint.transform.childCount != 0) return;
        Debug.Log("Spawnning Mushroom");
        GameObject mushroom = (GameObject)Instantiate(mushroomPrefab);
        mushroom.transform.SetParent(spawnPoint.transform);
        mushroom.transform.position = spawnPoint.transform.position;
        // set color of mushroom light
    }

    public GameObject ReturnMushroomSpawnNode(int index)
    {
        return mushroomNodes.transform.GetChild(index).gameObject;
    }
}