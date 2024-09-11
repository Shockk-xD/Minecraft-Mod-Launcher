using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mod Data List", menuName = "Mod/Mod Data List")]
public class ModDataList : ScriptableObject
{
    [field: SerializeField] public List<ModData> ModList { get; private set; }
}
