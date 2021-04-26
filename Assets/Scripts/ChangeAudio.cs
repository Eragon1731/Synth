using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public TrackItems itemManager;
    public ColourSlider colourManager;
   // public ScaleSlider scaleManager;

    public int position = 0;
    public int samplerate = 44100;
    public float frequency = 440;

    AudioSource aud;
    float scale_value = 2;

    private Vector3 screenPoint;
    private Vector3 offset;
    private float[] samples; 
    public bool isActive = false;
    private float scale; 

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();

        //get the source data
        samples = new float[aud.clip.samples * aud.clip.channels];
        print("samples" + samples.Length);
        aud.clip.GetData(samples, 0);
    }

    void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.tag == "area")
        {
            frequency = colourManager.GetColor();
            //ChangeWaves(frequency);
            aud.pitch = frequency;
            aud.Play();
        }
        else {
            aud.Stop();
        }
    }

    /* Mouse move functions */

    private void OnMouseDown()
    {
        itemManager.SetActiveItem(this.GetComponent<Transform>().gameObject);
        colourManager.SetRenderer();
        //if (transform.localScale.x > 5f)
      //  scaleManager.ResetScale();

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); // hardcode the y and z for your use

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        gameObject.transform.position = new Vector3( curPosition.x, curPosition.y, 0);

        if (aud.isPlaying) {
            //changing position to change stuff?
            aud.dopplerLevel = transform.position.x;
            aud.panStereo = transform.position.y;
            scale = transform.position.x;
            print("scale" + frequency);
           // ChangeWaves(frequency);
        }

    }

    void ChangeWaves(float scale) {
        for (int i = 0; i < samples.Length; i++) {
            //samples[i] = samples[i] * (scale);
            samples[i] = Mathf.Sin(scale * Mathf.PI * i * 440/ 44100);
        }

        aud.clip.SetData(samples, 0);
    }
}
