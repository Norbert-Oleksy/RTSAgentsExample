using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIAssembly
{
    public class UIAgentsControler : MonoBehaviour
    {
        #region Singleton
        public static UIAgentsControler instance;
        #endregion
        #region Variables
        private string _agentsCount;
        #endregion

        #region Methods

        public void AddAgent()
        {
            //TODO
        }

        public void RemoveRandomAgent()
        {
            //TODO
        }

        public void ClearAllAgents()
        {
            //TODO
        }

        public void SentMsgInfoBox(string msg)
        {
            //TODO
        }

        public void UpdateAgentsCounter(string value)
        {
            //TODO
        }

        #endregion

        #region Unity-API
        private void Awake()
        {
            if (instance != null && instance != this) return;
            instance = this;
            _agentsCount = 0.ToString();
        }

        void OnGUI()
        {
            GUI.Label(new Rect(-83, 66, 500, 100), _agentsCount, new GUIStyle { fontSize = 25, alignment = TextAnchor.UpperCenter, normal = new GUIStyleState { textColor = Color.white } });
        }
        #endregion
    }
}
