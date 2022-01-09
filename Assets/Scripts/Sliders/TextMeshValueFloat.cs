using UnityEngine;
using TMPro;
using DataBase;

namespace sliders
{
    public class TextMeshValueFloat : MonoBehaviour
    {
        [SerializeField]
        Settings.UISettingsFloat setting;
        TextMeshProUGUI display;
        float value;

        void Start()
        {
            value = Settings.GetValue(setting);
            display = GetComponent<TextMeshProUGUI>();
            display.SetText("{0:2}", value);
        }
    }
}
