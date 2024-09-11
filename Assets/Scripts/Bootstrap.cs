using TMPro;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private TMP_Text _loadingText;
    [SerializeField] private Animator _sceneLoaderAnimator;

    private bool _isLoaded = false;
    private const int LEFT_MOUSE_BUTTON = 0;

    private SceneLoader _sceneLoader;

    [Inject]
    public void Construct(SceneLoader sceneLoader) => _sceneLoader = sceneLoader;

    private void Awake() {
        if (_loadingText == null)
            throw new NullReferenceException(nameof(_loadingText));
        if (_sceneLoaderAnimator == null)
            throw new NullReferenceException(nameof(_sceneLoaderAnimator));
    }

    private async void Start() {
        await Load();
        InitializeSceneLoader();
    }

    private async UniTask Load() {
        float loadingTime = 1.5f;

        _loadingText.text = Lean.Localization.LeanLocalization.GetTranslationText("Loading");
        await UniTask.WaitForSeconds(loadingTime);
        _loadingText.text = Lean.Localization.LeanLocalization.GetTranslationText("TapToContinue");
        _isLoaded = true;
    }

    private void InitializeSceneLoader() {
        _sceneLoader.Initialize(_sceneLoaderAnimator);
    }

    private void Update() {
        if (_isLoaded && Input.GetMouseButton(LEFT_MOUSE_BUTTON))
            _sceneLoader.LoadScene(Scene.MainMenu);
    }
}
