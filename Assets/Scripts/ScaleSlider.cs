using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleSlider : MonoBehaviour
{
    public TrackItems itemManager;
    public Slider scaleSlider;
    //[SerializeField]
    GameObject targetObj;


    // Start is called before the first frame update
    void Start()
    {
        targetObj = itemManager.GetActiveObj();
        scaleSlider.value = 0.5f;
    }

    public void OnSliderChange() {
        targetObj = itemManager.GetActiveObj();
        targetObj.transform.localScale = new Vector3(scaleSlider.value /10, scaleSlider.value /10, scaleSlider.value /10);

       //this.GetComponent<AudioSource>().volume = scaleSlider.value;
    }

    public void ResetScale(float scale = 0.5f) {
        scaleSlider.value = scale;
    }
}
