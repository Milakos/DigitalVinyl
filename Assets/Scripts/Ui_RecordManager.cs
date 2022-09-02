using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Ui_RecordManager : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager imageManager;
    [SerializeField] TMP_Text[] uiso;

    [SerializeField] TMP_Text nowPlaying;
    [SerializeField] Toggle toggle;
    [SerializeField] GameObject panelInstruction;
    Camera cam;
    int layerMask;

    int nameofmiles;
    void Start()
    {
        
        cam = Camera.main;
        layerMask = 1 << LayerMask.NameToLayer("Records");
        nowPlaying.text = "";
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
                
                Record record = hit.collider.GetComponentInParent<Record>();
                uiso[0].text = record.artist;
                uiso[1].text = record.vinylRecord;
                uiso[2].text = record.musicGenre;
                uiso[3].text = record.company;
                uiso[4].text = record.year;
                uiso[5].text = record.trackList;
                uiso[6].text = record.bandMembers;
        }
        else    
        {
            panelInstruction.SetActive(false);
            toggle.interactable = false;
        }
        
        Record rec = FindObjectOfType<Record>();
        nowPlaying.text = "Now Playing: " + rec.nameofSong;
    }
}
