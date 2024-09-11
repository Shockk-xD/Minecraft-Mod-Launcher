using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ModInfoLoader : MonoBehaviour
{
    [SerializeField] private TMP_Text _modNameText;
    [SerializeField] private Transform _screenshotsContent;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private GameObject _screenshotPrefab;

    private ModDataProjectContainer _modProjectContainer;

    [Inject]
    public void Construct(ModDataProjectContainer modDataProjectContainer)
        => _modProjectContainer = modDataProjectContainer;

    private void Start() {
        Load();
    }

    private void Load() {
        var modData = _modProjectContainer.currentlyModData;

        _modNameText.text = Lean.Localization.LeanLocalization.GetTranslationText($"Mod{modData.ModId}Name");
        foreach (var screenshot in modData.Screenshots) {
            var screenshotPrefab = Instantiate(_screenshotPrefab, _screenshotsContent);
            var imageComponent = screenshotPrefab.GetComponent<Image>();

            imageComponent.sprite = screenshot;
        }
        _descriptionText.text = Lean.Localization.LeanLocalization.GetTranslationText($"Mod{modData.ModId}Description");
    }
}
