using UnityEngine;
using TMPro;
using DataBase;

namespace sliders
{
    public class TextMeshValueInt : MonoBehaviour
    {
        [SerializeField]
        Settings.UISettingsInt setting;
        TextMeshProUGUI display;
        int value;

        void Start()
        {
            value = Settings.GetValue(setting);
            display = GetComponent<TextMeshProUGUI>();
            display.SetText("{0}", value);
        }
    }
}
