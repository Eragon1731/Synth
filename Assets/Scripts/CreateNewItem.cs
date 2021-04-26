using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewItem : MonoBehaviour
{
    public TrackItems itemManager; 

    public void RefreshScene() {

        float offset = 2; 

        foreach ( GameObject item in itemManager.items){
            item.transform.position = new Vector3(-7, 0 + offset, 0);
            item.GetComponent<AudioSource>().Stop();
            item.GetComponent<Renderer>().material.color = Color.HSVToRGB(0, 0, 1);
          //  item.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
            offset -= 2;
        }
    }
}
