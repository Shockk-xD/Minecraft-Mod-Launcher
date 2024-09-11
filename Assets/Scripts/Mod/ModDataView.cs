using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ModDataView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _modName;
    [SerializeField] private Button _infoButton;

    private ModDataProjectContainer _modProjectContainer;
    private SceneLoader _sceneLoader;

    [Inject]
    public void Construct(ModDataProjectContainer modProjectContainer, SceneLoader sceneLoader) {
        _modProjectContainer = modProjectContainer;
        _sceneLoader = sceneLoader;
    }

    private void Awake() {
        if (_icon == null)
            throw new NullReferenceException(nameof(_icon));  
        if (_modName == null)
            throw new NullReferenceException(nameof(_modName));
        if (_infoButton == null)
            throw new NullReferenceException(nameof(_infoButton));
    }

    public void Initialize(ModData modData) {
        if (modData.Icon != null)
            _icon.sprite = modData.Icon;
        if (modData.Name != null)
            _modName.text = Lean.Localization.LeanLocalization.GetTranslationText($"Mod{modData.ModId}Name");

        _infoButton.onClick.AddListener(() => {
            _modProjectContainer.currentlyModData = modData;
            _sceneLoader.LoadScene(Scene.ModInfo);
        });
    }
}
