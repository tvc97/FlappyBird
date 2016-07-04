using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeController : MonoBehaviour
{

    public float maxHeight;
    public float minHeight;

    public GameObject pipePrefab;

    public int maxSpawnPipe;
    public List<GameObject> pipes;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < maxSpawnPipe; i++)
        {
            GameObject temp = Instantiate(pipePrefab) as GameObject;
            temp.SetActive(false);
            pipes.Add(temp);

            temp.transform.localRotation = Quaternion.Euler(0,0,Random.Range(0.0001F,0.0002F));
        }

        InvokeRepeating("Spawn", 0f, 1.3f);
    }

    // Update is called once per frame
    void Spawn()
    {
        float randHeight = Random.Range(minHeight, maxHeight);
        for (int i = 0; i < maxSpawnPipe; i++)
        {
            if (!pipes[i].activeSelf)
            {
                pipes[i].transform.position = new Vector3(transform.position.x, randHeight, -0.5F);
                pipes[i].transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0.0001F, 0.0002F));
                pipes[i].SetActive(true);
                break;
            }
        }
    }


}