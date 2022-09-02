using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class UI_ManagerHandler : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager imageManager;
    [SerializeField] TMP_Text flowerName;
    [SerializeField] Toggle toggle;
    [SerializeField] TMP_Text detailsText;
    [SerializeField] GameObject panelInstruction;
    Camera cam;
    int layerMask;
    void Start()
    {
        cam = Camera.main;
        layerMask = 1 << LayerMask.NameToLayer("Flowers");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
            
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            
                // panelInstruction.SetActive(true);
                toggle.interactable = true;
               
                Flower flower = hit.collider.GetComponentInParent<Flower>();
                
                flowerName.text = flower.flowerName;
                detailsText.text = flower.description;
        }
        else    
        {
            panelInstruction.SetActive(false);
            toggle.interactable = false;
            flowerName.text = "";
            detailsText.text = "";
        }
    }
}
