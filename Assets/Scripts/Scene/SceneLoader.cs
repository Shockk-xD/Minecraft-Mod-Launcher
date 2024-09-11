using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader {
    private Animator _loadAnimator;
    private bool _isLoading = false;
    private const float ANIMATION_TIME = 0.375f;
    private const string FadeIn = nameof(FadeIn);
    private const string FadeOut = nameof(FadeOut);

    public void Initialize(Animator loadAnimator) => _loadAnimator = loadAnimator;

    public async void LoadScene(Scene scene) {
        if (_isLoading) return;
        _isLoading = true;

        _loadAnimator.SetTrigger(FadeIn);
        await UniTask.WaitForSeconds(ANIMATION_TIME);
        await SceneManager.LoadSceneAsync(scene.ToString());
        _loadAnimator.SetTrigger(FadeOut);
        await UniTask.WaitForSeconds(ANIMATION_TIME);

        _isLoading = false;
    }
}
