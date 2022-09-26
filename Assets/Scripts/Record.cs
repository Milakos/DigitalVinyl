using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Record : MonoBehaviour
{
    #region Values
    public SO_Records so;
    UnityEvent myEvent;

    AudioManager am;

    [HideInInspector]
    public string artist;
    [HideInInspector]
    public string vinylRecord;
    [HideInInspector]
    public string musicGenre;
    [HideInInspector]
    public string company;
    [HideInInspector]
    public string year;
    [HideInInspector]
    public string trackList;
    [HideInInspector]
    public string bandMembers;
    [SerializeField] public int PreviousSong = -1;
    [SerializeField]public  int nextSong = 1;
    [SerializeField] public int currentSong = 0;
    public AudioClip aclip;
    public AudioSource source;

    public string nameofSong;

#endregion Values
    private void Start() 
    {
        am = FindObjectOfType<AudioManager>();
        source = FindObjectOfType<AudioSource>();
        currentSong = 0;
        nextSong = 1;
    }
    // private void OnEnable() 
    // {
    //     source.Play();    
    // }
    // private void OnDisable() 
    // {
    //     source.Stop();
    // }

    // Update is called once per frame
    void Update()
    {
        artist = so.Artist;
        vinylRecord = so.Record;
        musicGenre = so.MusicGenre;
        company = so.Company;
        year = so.Year;
        trackList = so.TrackList;
        bandMembers = so.BandMembers;
        aclip = so.song[currentSong];
        source.clip = so.song[currentSong];

        if(am.nextSongAM == true)
        {
            currentSong += nextSong;
            // currentSong = nextSong;
            am.nextSongAM = false;

            if(currentSong == so.song.Length)
            {
                currentSong = 0;
            }
        }
           
        if (am.PreviousSong == true && currentSong == 0)
        {
            currentSong = so.song.Length;
            print(so.song.Length);
        }

        if (am.PreviousSong == true)
        {
            currentSong += PreviousSong;
            // currentSong = PreviousSong;
            am.PreviousSong = false;


        }



        nameofSong = so.song[currentSong].name;
    }

}
