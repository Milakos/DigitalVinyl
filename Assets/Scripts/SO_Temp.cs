using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FlowerContent", order = 1)]
public class SO_Temp : ScriptableObject
{
    public Color color;
    public string flowerName;

    [TextArea(1, 15)]
    public string descriptionContent;


}

