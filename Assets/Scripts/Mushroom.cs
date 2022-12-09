using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    public ParticleSystem particles;
    public Light light;
    MushroomGeneration generate;
    Color mushroomColor;


    private void Awake() 
    {
        mushroomColor = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        particles.Stop();
    }

    void Start()
    {
        particles.startColor = mushroomColor;
        light.color = mushroomColor;
        light.intensity = 0.02f;
        generate =  (MushroomGeneration)GameObject.Find("Environment").GetComponent<MushroomGeneration>();
    }

    void OnCollisionEnter(Collision collision)
    {
       particles.Play(); // when player bumps into the mushroom emit particles
       generate.SpawnMushroom(generate.ReturnMushroomSpawnNode(Random.Range(0, generate.numberOfNodes))); // generate another mushroom somewhere
       Destroy(this.gameObject, 2.0f); // destory mushroom after 2 seconds.
    }

  
}
