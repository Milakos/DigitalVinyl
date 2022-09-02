using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracker : MonoBehaviour
{
    public TMP_Text text;
    public GameObject anim;
    [SerializeField] ARTrackedImageManager imageManager;
    [SerializeField] GameObject[] prefabs;
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    public Vector3 scaleFactor;
    private void Awake() 
    {
        text.text = "";
        imageManager = GetComponent<ARTrackedImageManager>();

        foreach(GameObject pf in prefabs)
        {
            GameObject go  = Instantiate(pf, Vector3.zero, Quaternion.identity);
            
            go.name = pf.name;
            spawnedPrefabs.Add(pf.name, go);
            go.SetActive(false);
        }
    }

    private void OnEnable() 
    {
        text.text ="OnEnable";
        imageManager.trackedImagesChanged += ImageChange;
    }

    private void OnDisable() 
    {
        imageManager.trackedImagesChanged -= ImageChange;
       
    }
    private void ImageChange(ARTrackedImagesChangedEventArgs eventArgs)
    {
        
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {

            text.text = "Added";
            ChangeLocation(trackedImage.referenceImage.name, trackedImage.transform.position, trackedImage.transform.rotation, true);
        }
        
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            
            ChangeLocation(trackedImage.referenceImage.name, trackedImage.transform.position, trackedImage.transform.rotation, true);
            text.text = "Update";

            if(trackedImage.trackingState == TrackingState.Limited || trackedImage.trackingState == TrackingState.None)
            {
                anim.SetActive(true);
                ChangeLocation(trackedImage.referenceImage.name, Vector3.zero, Quaternion.identity, false);
                text.text = "Removed";
            }
            else
            {
                anim.SetActive(false);
            }
        }
    }

    
    void ChangeLocation (string name, Vector3 ob, Quaternion quat, bool vis)
    {
            spawnedPrefabs[name].transform.position = ob;
            spawnedPrefabs[name].transform.rotation = quat;
            spawnedPrefabs[name].SetActive(vis);
    }
}
