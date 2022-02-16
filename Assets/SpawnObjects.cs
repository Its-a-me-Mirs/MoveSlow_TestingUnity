using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // NOTE: I haven't set it up for the script to reload when public values change in the editor so for now it'll have to be changed manually here
    
    // tagged items cutomized values goes here, switches to defaultVals if array is not long enough (below)
   
    // spread of object spwan from -value[i] to value[i]
    public float[] radiusVals = {25, 50, 75, 60};

    // number of the given object to spawn
    public float[] numOfObjects = {50, 75, 100, 250};

    // setting up default value if outside array length
    public float pass_default = 50;
    float passerRange = 0;
    float passerNums = 0;

    // stores the types of object
    GameObject[] objs;
    int counter = 0;

    // no spawn area size
    float noSpawnVal = 15;
    float holderX, holderZ = 0;
    float camX, camZ = 0;

    void Start() {
        objs = GameObject.FindGameObjectsWithTag("spawn");
        //int numObjects = objs.Length;
        //Debug.Log(numObjects);
        
        Camera cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        camX = cam.transform.position.x;
        camZ = cam.transform.position.z;
    }

    void Update() {
        // TO-DO: restricting the Random.Range from including a specific area around the camera
        
        // for each of the types of object, will create the number of and spread specified
        foreach(GameObject g in objs){
            // index of the current object
            //Debug.Log(System.Array.IndexOf(objs, g));
            
            // value from the index
            //Debug.Log(radiusVals[System.Array.IndexOf(objs, g)]); 

            // use value at the index if not null [radiusVals]
            if (System.Array.IndexOf(objs, g) < radiusVals.Length){
                passerRange = radiusVals[System.Array.IndexOf(objs, g)];
            } else { passerRange = pass_default;}

            // use value at the index if not null [numOfObjects]
            if (System.Array.IndexOf(objs, g) < numOfObjects.Length){
                passerNums = numOfObjects[System.Array.IndexOf(objs, g)];
            } else { passerNums = pass_default;}

            // To-DO: random range based on area around camera and noSpawn buffer space
            //create logic based on the 4 quadrants

            // if (Random.Range(0,2) == 0){
            //     holderX = Random.Range(passerRange, camX + noSpawnVal);
            // } else {
            //     holderX = Random.Range(-passerRange, camX - noSpawnVal);
            // }

            // if (Random.Range(0,2) == 0){
            //     holderZ = Random.Range(passerRange, camZ + noSpawnVal);
            // } else {
            //     holderZ = Random.Range(-passerRange, camZ - noSpawnVal);
            // }

            // if (Random.Range(0,4) == 0){
            //     //Quadrant 1
            //     holderX = Random.Range(camX + noSpawnVal, passerRange);
            //     holderZ = Random.Range(camZ + noSpawnVal, passerRange);
            // }
            // else if (Random.Range(0,4) == 1){
            //     //Quadrant 2
            //     holderX = Random.Range(camX + noSpawnVal, passerRange);
            //     holderZ = Random.Range(camZ - noSpawnVal, -passerRange);
            // }
            // else if (Random.Range(0,4) == 2){
            //     //Quadrant 3
            //     holderX = Random.Range(camX - noSpawnVal, -passerRange);
            //     holderZ = Random.Range(camZ - noSpawnVal, -passerRange);
            // }
            // else {
            //     // Quadrant 4
            //     holderX = Random.Range(camX - noSpawnVal, -passerRange);
            //     holderZ = Random.Range(camZ + noSpawnVal, passerRange);
            // }

            if (Random.Range(0,4) == 0){
                // x is greater than noSpawn
                holderX = Random.Range(camX + noSpawnVal, passerRange);
                holderZ = Random.Range(-passerRange, passerRange);
            }
            else if (Random.Range(0,4) == 1){
                // x is less than -noSpawn
                holderX = Random.Range(camX - noSpawnVal, -passerRange);
                holderZ = Random.Range(-passerRange, passerRange);
            }
            else if (Random.Range(0,4) == 2){
                // z is greater than noSpawn
                holderZ = Random.Range(camZ + noSpawnVal, passerRange);
                holderX = Random.Range(-passerRange, passerRange);
            }
            else {
                // z is less than noSpawn
                holderZ = Random.Range(camZ - noSpawnVal, -passerRange);
                holderX = Random.Range(-passerRange, passerRange);
            }

            // number of objects to spawn for each type of object
            if (counter <= passerNums){
                // creates instances of the object into the scene with random position within the specified range
                // Simplified Translation:
                // Instantiate(object to make, Position(random X range, y=0, random Z range), Rotation)
                Debug.Log("passerRange: " + passerRange + " holderX: " + holderX + " holderZ: " + holderZ);
                GameObject.Instantiate(g.gameObject, new Vector3(holderX, 0, holderZ), Quaternion.Euler(new Vector3(0f, 90f, 0f)));
                
                counter++;
            }
            
        }
    }
}
