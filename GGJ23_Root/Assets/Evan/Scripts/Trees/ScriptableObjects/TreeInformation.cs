using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeInformation", menuName = "Tree Information/New Tree Information Object", order = 1)]
public class TreeInformation : ScriptableObject
{
    public GameObject treePrefab;
    public string treeName;
    public int lifeEssenceCost;
    public Sprite thumbnailSprite;
}
