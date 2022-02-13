using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // NOTE: I haven't set it up for the script to reload when public values change in the editor so for now it'll have to be changed manually here
    
    // if number of type of tagged items increase, just add more values to the two array here
    // spread of object spwan from -value[i] to value[i]
    public float[] radiusVals = {25, 50, 75};
    // number of the given object to spawn
    public float[] numOfObjects = {50, 75, 100};

    // stores the types of object
    GameObject[] objs;
    int counter = 0;

    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("spawn");
        //int numObjects = objs.Length;
        //Debug.Log(numObjects);
    }

    void Update() {
        // for each of the types of object, will create the number and spread specified
        foreach(GameObject g in objs){
            // number of objects to spawn
            if (counter <= numOfObjects[System.Array.IndexOf(objs, g)]){
                //Debug.Log(System.Array.IndexOf(objs, g)); // index of the current object
                //Debug.Log(radiusVals[System.Array.IndexOf(objs, g)]); // value from the index
                //Debug.Log("next");

                // creates instances of the object into the scene with random position within the specified range
                // Simplified Translation:
                // Instantiate(object to make, Position(random X range, y=0, random Z range), Rotation)
                GameObject.Instantiate(g.gameObject, new Vector3(Random.Range(-radiusVals[System.Array.IndexOf(objs, g)], radiusVals[System.Array.IndexOf(objs, g)]), 0, Random.Range(-radiusVals[System.Array.IndexOf(objs, g)], radiusVals[System.Array.IndexOf(objs, g)])), Quaternion.Euler(new Vector3(0f, 90f, 0f)));
                
                counter++;
            }
        }
    }
}
