using Koro;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Demo
{
    public class ColorBlindDemoScript : MonoBehaviour
    {
        [SerializeField] private List<ColorBlindCondition> conditions = null;
        [SerializeField] private TextMeshProUGUI conditionLabelText = null;
        [SerializeField] private PostProcessProfile profile = null;

        private int currentIndex = 0;

        private void Start()
        {
            UpdateUI();
        }

        public void Next()
        {
            currentIndex++;
            if (currentIndex >= conditions.Count)
                currentIndex = 0;

            UpdateUI();
        }

        public void Previous()
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = conditions.Count - 1;

            UpdateUI();
        }

        private void UpdateUI()
        {
            ColorBlindCondition condition = conditions[currentIndex];

            conditionLabelText.text = condition.Type.ToString();
            profile.GetSetting<Colorblind>().RedValues.value = condition.Mix.RedValues;
            profile.GetSetting<Colorblind>().GreenValues.value = condition.Mix.GreenValues;
            profile.GetSetting<Colorblind>().BlueValues.value = condition.Mix.BlueValues;
        }
    }
}