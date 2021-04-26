using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSlider : MonoBehaviour
{
    public TrackItems itemManager;
    float m_Hue;
    public Slider colorSlider;
    Renderer m_Renderer;

    GameObject targetObject; 

    void Start()
    {
        SetRenderer();

        //Set the maximum and minimum values for the Sliders
        colorSlider.maxValue = 1;
        colorSlider.minValue = 0;
    }

    public void SetRenderer() {
        targetObject = itemManager.GetActiveObj();
        //targetObject = obj;
        m_Renderer = targetObject.GetComponent<Renderer>();
    }


    public void OnSliderChange() {
        m_Hue = colorSlider.value;
        m_Renderer.material.color = Color.HSVToRGB(m_Hue, 1, 1);

    }

    public float GetColor() {
        return m_Hue;
    }

}
