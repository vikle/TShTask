using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EcsGame
{
    public class UIHudPanel : MonoBehaviour
    {
        public Text killedScores;
        public Slider healthSlider;

        public void SetScores(int value)
        {
            killedScores.text = value.ToString();
        }

        public void SetHealth(int value)
        {
            healthSlider.value = value / 100f;
        }
    };
}