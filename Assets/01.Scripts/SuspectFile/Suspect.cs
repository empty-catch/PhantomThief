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

    [Header("Proviso")]
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
}
