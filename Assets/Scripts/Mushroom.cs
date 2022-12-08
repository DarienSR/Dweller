using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    public ParticleSystem particles;

    MushroomGeneration generate;

    void Start()
    {
        particles.Stop();
        generate =  (MushroomGeneration)GameObject.Find("Environment").GetComponent<MushroomGeneration>();
    }

    void OnCollisionEnter(Collision collision)
    {
       particles.Play(); // when player bumps into the mushroom emit particles
       generate.SpawnMushroom(generate.ReturnMushroomSpawnNode(Random.Range(0, generate.numberOfNodes))); // generate another mushroom somewhere
       Destroy(this.gameObject, 2.0f); // destory mushroom after 2 seconds.
    }
}
