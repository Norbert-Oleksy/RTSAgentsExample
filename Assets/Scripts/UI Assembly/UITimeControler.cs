using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreAssembly;
using UnityEngine.UI;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;

namespace UIAssembly
{
    public class UITimeControler : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Image pauseImage;
        [SerializeField] private Sprite pauseIcon;
        [SerializeField] private Sprite resumeIcon;
        #endregion

        #region Variables
        private bool isPaused = false;
        private string _timerText;
        #endregion

        #region Methods

        public void ChangeTimeByTheValue(float value)
        {
            if (isPaused)
            {
                PauseOrResume();
                return;
            }
            GameManager.instance.ChangeTickRateBy(value);
        }

        public void PauseOrResume()
        {
            if (isPaused)
            {
                GameManager.instance.SetTickRate(1.0f);
                pauseImage.sprite = pauseIcon;
            }
            else
            {
                GameManager.instance.SetTickRate(0);
                pauseImage.sprite = resumeIcon;
            }
            isPaused = !isPaused;
        }

        public void UpdateTimerText(float time)
        {
            if (time == 0) { _timerText = "PAUSE"; }
            else { _timerText = time.ToString("0.0#");}
        }

        #endregion

        #region Unity-API
        private void Awake()
        {
            _timerText = 1.0f.ToString("0.0#");
            GameManager.UpdateTimeLabel += UpdateTimerText;
        }

        void OnGUI()
        {
            GUI.Label(new Rect(945, 10, 400, 50), _timerText, new GUIStyle { fontSize = 50, alignment = TextAnchor.MiddleCenter, normal = new GUIStyleState { textColor = Color.white } });
        }
        #endregion
    }
}
