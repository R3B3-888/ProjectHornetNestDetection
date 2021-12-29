using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedSlider : MonoBehaviour
{
    [SerializeField] private Slider _seedSlider;
    [SerializeField] private TextMeshProUGUI _seedSliderText;
    
    void Start()
    {
        _seedSlider.onValueChanged.AddListener((v) => {
            _seedSliderText.text = v.ToString("0");
            MapGenerator.Seed = (int) v;
        });
    }
}
