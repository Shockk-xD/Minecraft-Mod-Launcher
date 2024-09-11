using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Zenject;
using Image = UnityEngine.UI.Image;

public class ModInstallerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _installingModNameText;
    [SerializeField] private TMP_Text _percentViewText;
    [SerializeField] private TMP_Text _statusText;
    [SerializeField] private Image _progressBar;

    [SerializeField] private Animator _downloadingIconAnimator;

    [SerializeField] private Image _openModButtonImage;
    [SerializeField] private Sprite _greenFrameSprite;

    private ModDataProjectContainer _modProjectContainer;
    private float _installTime = 5;

    [Inject]
    private void Construct(ModDataProjectContainer modProjectContainer)
        => _modProjectContainer = modProjectContainer;

    private void Start() {
        Install();
    }

    private async void Install() {
        var modData = _modProjectContainer.currentlyModData;
        _installingModNameText.text = Lean.Localization.LeanLocalization.GetTranslationText("ModIsInstalling") + "\n" + Lean.Localization.LeanLocalization.GetTranslationText($"Mod{modData.ModId}Name");
        _statusText.text = Lean.Localization.LeanLocalization.GetTranslationText("Installing");

        float timer = 0;
        while (timer < _installTime) {
            timer += Time.deltaTime;
            float t = timer / _installTime;

            _progressBar.fillAmount = t;
            _percentViewText.text = ((int)(t * 100)).ToString() + "%"; 

            await UniTask.Yield(PlayerLoopTiming.Update);
        }

        _installingModNameText.text = Lean.Localization.LeanLocalization.GetTranslationText("ModIsInstalled") + "\n" + modData.Name; 
        _statusText.text = Lean.Localization.LeanLocalization.GetTranslationText("OpenMod");
        _openModButtonImage.sprite = _greenFrameSprite;
        _downloadingIconAnimator.enabled = false;
    }
}
