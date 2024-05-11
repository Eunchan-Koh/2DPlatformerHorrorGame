using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterInfo : MonoBehaviour
{
    public GameObject TeleportTo;
    public Vector3 locationTo;
    void Awake(){
        locationTo = TeleportTo.transform.position;
    }
    
}
