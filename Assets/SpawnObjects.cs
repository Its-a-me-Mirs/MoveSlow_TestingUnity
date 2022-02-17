using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // NOTE: I haven't set it up for the script to re-exictute for now you'll have to turn on and off play mode
    
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

    // setting up no spawn area size (around center of the spawn)
    public float noSpawnVal = 10;
    float holderX, holderZ = 0;
    float camX, camZ = 0;

    void Start() {

        // TO-DO: set up re-ordering of the array of objects
        objs = GameObject.FindGameObjectsWithTag("spawn");
        //int numObjects = objs.Length;
        //Debug.Log(numObjects);
        
        // TO-DO: change center to a seperate empty object instead of the camera (use "Player" tag)
        Camera cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        camX = cam.transform.position.x;
        camZ = cam.transform.position.z;
    }

    void Update() {
    
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

            // random range based on area around camera and noSpawn buffer space
            // evenly distributes across all 4 quadrants (instead of randomly picking quadrants)
            if (counter % 4 == 0){
                // x is greater than noSpawn
                holderX = Random.Range(camX + noSpawnVal, camX + passerRange);
                holderZ = Random.Range(-passerRange + camZ, passerRange + camZ);
            }
            else if (counter % 4 == 1){
                // x is less than -noSpawn
                holderX = Random.Range(camX - noSpawnVal, -passerRange + camX);
                holderZ = Random.Range(-passerRange + camZ, passerRange + camZ);
            }
            else if (counter % 4 == 2){
                // z is greater than noSpawn
                holderZ = Random.Range(camZ + noSpawnVal, camZ + passerRange);
                holderX = Random.Range(-passerRange + camX, passerRange + camX);
            }
            else {
                // z is less than noSpawn
                holderZ = Random.Range(camZ - noSpawnVal, -passerRange + camZ);
                holderX = Random.Range(-passerRange + camX, passerRange + camX);
            }

            // number of objects to spawn for each type of object
            if (counter <= passerNums){
                // creates instances of the object into the scene with the specified ranges
                // Simplified Translation:
                // Instantiate(object to make, Position(random X range, y=0, random Z range), Rotation (x=0, random y axis, z=0))
                
                // TO-DO: add in variations to the object's scaling
                //Debug.Log("passerRange: " + passerRange + " holderX: " + holderX + " holderZ: " + holderZ);
                GameObject.Instantiate(g.gameObject, new Vector3(holderX, 0, holderZ), Quaternion.Euler(new Vector3(0f, Random.Range(0f,360f), 0f)));
                
                counter++;
            }
            
        }
    }
}
