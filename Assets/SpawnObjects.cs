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
    float noSpawnVal = 2;
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
        // new Vector3(Random.Range(-passerRange, passerRange), 0, Random.Range(-passerRange, passerRange))
        
        // for each of the types of object, will create the number of and spread specified
        foreach(GameObject g in objs){

            // use value at the index if not null [radiusVals]
            if (System.Array.IndexOf(objs, g) < radiusVals.Length){
                passerRange = radiusVals[System.Array.IndexOf(objs, g)];
            } else {
                passerRange = pass_default;
            }
            // use value at the index if not null [numOfObjects]
            if (System.Array.IndexOf(objs, g) < numOfObjects.Length){
                passerNums = numOfObjects[System.Array.IndexOf(objs, g)];
            } else {
                passerNums = pass_default;
            }

            // random range based on area around camera and noSpawn buffer space
            if (Random.Range(0,2) == 0){
                holderX = Random.Range(passerRange, camX + noSpawnVal);
                holderZ = Random.Range(passerRange, camZ + noSpawnVal);
            } else {
                holderX = Random.Range(passerRange, camX - noSpawnVal);
                holderZ = Random.Range(passerRange, camZ + noSpawnVal);
            }

            // number of objects to spawn for each type of object
            if (counter <= passerNums){
                // index of the current object
                //Debug.Log(System.Array.IndexOf(objs, g));
                
                // value from the index
                //Debug.Log(radiusVals[System.Array.IndexOf(objs, g)]); 
                //Debug.Log("next");

                // creates instances of the object into the scene with random position within the specified range
                // Simplified Translation:
                // Instantiate(object to make, Position(random X range, y=0, random Z range), Rotation)
                GameObject.Instantiate(g.gameObject, new Vector3(holderX, 0, holderZ), Quaternion.Euler(new Vector3(0f, 90f, 0f)));
                
                counter++;
            }
        }
    }
}
