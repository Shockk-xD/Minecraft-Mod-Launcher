using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class LoadSceneByButton : MonoBehaviour
{
    [SerializeField] private Scene _sceneToLoad;

    [Inject] private readonly SceneLoader _sceneLoader;

    private void Start() {
        var button = GetComponent<Button>();

        button.onClick.AddListener(() => _sceneLoader.LoadScene(_sceneToLoad));
    }
}
