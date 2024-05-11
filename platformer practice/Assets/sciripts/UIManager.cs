using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public playerMove player;
    Image staminaImage;
    // Start is called before the first frame update
    void Start()
    {
        staminaImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(staminaImage == null){
            //since update is being called fast, frequently text value is not set yet to new value - resulting in text == null. so this section required
        }else{
            staminaImage.fillAmount = player.stamina/100f;
            if(player.dashable){
                staminaImage.color = new Color(0.6792f, 0.5199f, 0, 1);
            }else{
                staminaImage.color = new Color(0.6981f, 0.0557f, 0, 1);
            }
        }
        
    }
}
