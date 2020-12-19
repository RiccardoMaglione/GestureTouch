using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SphereGo;

    void Start()
    {
        InvokeRepeating("Spawn", 1, 1);
    }

    public void Spawn()
    {
        if(this.gameObject.name == "SpawnUp") //Up to Down
        {
            GameObject Go = Instantiate(SphereGo, new Vector3(Random.Range(-6, 7), transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 180));
            Go.name = "GoUp";
            Destroy(Go, 5);
        }
        if (this.gameObject.name == "SpawnDown") //Down to Up
        {
            GameObject Go = Instantiate(SphereGo, new Vector3(Random.Range(-6, 7), transform.position.y, transform.position.z), Quaternion.identity);
            Go.name = "GoDown";
            Destroy(Go, 5);
        }
        if (this.gameObject.name == "SpawnRight") //Right to Left
        {
            GameObject Go = Instantiate(SphereGo, new Vector3(transform.position.x, Random.Range(-8, 9), transform.position.z), Quaternion.Euler(0, 0, 90));
            Go.name = "GoRight";
            Destroy(Go, 5);
        }
        if (this.gameObject.name == "SpawnLeft") //Left to Right
        {
            GameObject Go = Instantiate(SphereGo, new Vector3(transform.position.x, Random.Range(-8, 9), transform.position.z), Quaternion.Euler(0, 0, 270));
            Go.name = "GoLeft";
            Destroy(Go, 5);
        }
    }
}
