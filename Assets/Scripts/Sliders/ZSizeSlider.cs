using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZSizeSlider : MonoBehaviour
{
    [SerializeField] private Slider _zSizeSlider;
    [SerializeField] private TextMeshProUGUI _zSizeSliderText;
    
    void Start()
    {
        _zSizeSlider.onValueChanged.AddListener((v) => {
            _zSizeSliderText.text = v.ToString("0");
            MapGenerator.zSize = (int) v;
        });
    }
}
