using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGen : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject obj;
    public int modTime = 5;
    public float y = 14.58f;

    // Goes through a grid at starting at 0,0
    // and if that % by a certain number is 0 it will generate an object at that point in space
    // Giving us a grid like effect 
    void Start(){
        for(int x = 0; x < width; x++){
            for(int z = 0; z < height; z++){
                if(x%modTime == 0 && z%modTime == 0){
                    Instantiate(obj,new Vector3(x,y,z),Quaternion.identity);
                }
            }
        }
    }
}
