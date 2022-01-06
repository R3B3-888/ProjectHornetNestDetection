using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceBetweenTreesSlider : MonoBehaviour
{
    [SerializeField] private Slider _spaceBetweenTreesSlider;
    [SerializeField] private TextMeshProUGUI _spaceBetweenTreesSliderText;
    
    void Start()
    {
        _spaceBetweenTreesSlider.onValueChanged.AddListener((v) => {
            _spaceBetweenTreesSliderText.text = v.ToString("0");
            DataBase.Settings.SpaceBetweenTrees = (int) v;
        });
    }
}
