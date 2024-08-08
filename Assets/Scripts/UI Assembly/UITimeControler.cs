using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIAssembly
{
    public class UITimeControler : MonoBehaviour
    {
        #region Singleton
        public static UITimeControler instance;
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
            //if ((true && value < 0)) return;

            //TODO
        }

        public void PauseOrResume()
        {
            if (isPaused)
            {
                //use f from core to set a scale
                //_timerText = "1.0"; display scale value
            }
            else
            {
                _timerText = "PAUSE";
                //set scale to 0
            }
            isPaused = !isPaused;
        }

        #endregion

        #region Unity-API
        private void Awake()
        {
            if (instance != null && instance != this) return;
            instance = this;
            _timerText = 1.0f.ToString("0.0#");
        }

        void OnGUI()
        {
            GUI.Label(new Rect(945, 10, 400, 50), _timerText, new GUIStyle { fontSize = 50, alignment = TextAnchor.MiddleCenter, normal = new GUIStyleState { textColor = Color.white } });
        }
        #endregion
    }
}
