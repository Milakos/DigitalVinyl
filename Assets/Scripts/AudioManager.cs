using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Button btnForward;
    [SerializeField] private Button btnBack;
    public bool nextSongAM;
    public bool PreviousSong;
    private void Awake() 
    {
        btnForward.onClick.AddListener(FWD); 
        btnBack.onClick.AddListener(BCKW);    
        nextSongAM = false; 
        PreviousSong = false;
    }

    public void FWD()
    {
        nextSongAM = true;
    }

    public void BCKW()
    {
        PreviousSong = true;
    }
}
