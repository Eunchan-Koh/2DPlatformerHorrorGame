using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerObjectInteract : MonoBehaviour
{
    public bool hidable;
    public bool pickable;
    public bool teleportable;
    public Vector3 location;
    public GameObject interactedObject;
    void Awake()
    {
        hidable = false;
        teleportable = false;
    }

    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.layer == 8){
            ObjectInfo a = collision.GetComponent<ObjectInfo>();
            if(a == null){
                Debug.Log("collision object info is null! playerObjectInteract");
            }
            interactedObject = collision.gameObject;
            location = a.gameObject.transform.position;
            if(a.isHideSpot){
                // Debug.Log("enabled!");
                hidable=true;
            }else if(a.isItem){
                // Debug.Log("aaaq");
                pickable = true;
            }
        }else if(collision.gameObject.layer == 11){
            // Debug.Log("isteleportable");
            teleportable = true;
            location = collision.GetComponent<TeleporterInfo>().locationTo;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.layer == 8){
            if(hidable){
                // Debug.Log("exited!");
                hidable = false;
            }
            if(pickable){
                pickable = false;
            }
        }else if(collision.gameObject.layer == 11){
            // Debug.Log("isteleportable");
            teleportable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
