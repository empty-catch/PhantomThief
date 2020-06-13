using UnityEngine;

[CreateAssetMenu(fileName = "InteractionScriptable", menuName = "InteractionScriptable", order = 0)]
public class InteractionScriptable : ScriptableObject {
    public Sprite eventSprite;
    public string[] invenstigateStrings;
    public string[] monolougeStrings;
    public string[] systemStrings;

    public string item;
}