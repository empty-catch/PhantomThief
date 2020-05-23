#pragma warning disable CS0649
using UnityEngine;

[CreateAssetMenu(fileName = "Suspect", menuName = "Suspect")]
public class Suspect : ScriptableObject
{
    [Header("Information")]
    [SerializeField]
    private Sprite picture;
    [SerializeField]
    private new string name;
    [SerializeField]
    private string description;

    [Header("Clue")]
    [SerializeField]
    private string where;
    [SerializeField]
    private string what;
    [SerializeField]
    private string how;
    [SerializeField]
    private string why;

    public Sprite Picture => picture;
    public string Name => name;
    public string Description => description;
    public string Where => where;
    public string What => what;
    public string How => how;
    public string Why => why;
}
