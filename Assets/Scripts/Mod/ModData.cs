using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mod Data", menuName = "Mod/Mod Data")]
public class ModData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, TextArea()] public string Description { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public List<Sprite> Screenshots { get; private set; }
    [field: SerializeField] public int ModId { get; private set; }
}
