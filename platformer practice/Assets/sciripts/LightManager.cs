using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lights;
    public playerMove player;
    int lightSize;
    void Awake()
    {
        lightSize = lights.Length;
        Debug.Log(lightSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        if(player.hiding){
            for(int i = 0; i < lightSize; i++){
                lights[i].SetActive(false);
            }
        }else{
            for(int i = 0; i < lightSize; i++){
                lights[i].SetActive(true);
            }
        }
    }
}
