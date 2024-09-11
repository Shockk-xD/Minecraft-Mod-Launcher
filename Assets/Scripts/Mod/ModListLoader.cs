using UnityEngine;
using Zenject;

public class ModListLoader : MonoBehaviour
{
    [SerializeField] private GameObject _modDataView;
    [SerializeField] private Transform _content;
    [SerializeField] private ModDataList _list;

    private DiContainer _diContainer;

    [Inject]
    public void Construct(DiContainer diContainer) => _diContainer = diContainer; 

    private void Start() {
        Load();
    }

    private void Load() {
        foreach (var mod in _list.ModList) {
            var modView = _diContainer.InstantiatePrefab(_modDataView, _content);
            var modDataView = modView.GetComponent<ModDataView>();
            modDataView.Initialize(mod);
        }
    }
}
