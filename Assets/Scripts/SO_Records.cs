using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Records", order = 2)]

public class SO_Records : ScriptableObject
{
    public string Artist;
    public string Record;
    public string MusicGenre;
    public string Company;
    public string Year;

    [TextArea(1, 15)]
    public string TrackList;
    
    [TextArea(1, 15)]
    public string BandMembers;

    public AudioClip[] song;
}
