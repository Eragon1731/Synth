using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackItems : MonoBehaviour
{
    public List<GameObject> items;
    public GameObject activeObject;

    public GameObject instructions;
    bool isStart = false; 
    private void Update()
    {
        if (!isStart) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                instructions.SetActive(false);
                isStart = true;
            }
        }
    }

    public void AddItem(GameObject itObj) {

        items.Add(itObj);
        SetActiveItem(itObj);
    }

    public void SetActiveItem(GameObject active)
    {
        foreach (GameObject item in items) {
            if (active.name == item.name)
            {
                activeObject = active;
                activeObject.tag = "it";
                activeObject.GetComponent<ChangeAudio>().isActive = true;
            }
            else {
                item.GetComponent<ChangeAudio>().isActive = false;
            }

        }
    }

    public GameObject GetActiveObj() {
        return activeObject;
    }
}
