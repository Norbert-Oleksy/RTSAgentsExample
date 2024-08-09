using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreAssembly;
using UnityEngine.UI;
namespace UIAssembly
{
    public class UIAgentsControler : MonoBehaviour
    {
        #region Fields
        [Header("InfoBoxSection")]
        [SerializeField] private Transform infoBoxContent;
        [SerializeField] private GameObject infoMsgPrefab;
        #endregion
        #region Variables
        private string _agentsCount;
        #endregion

        #region Methods

        public void AddAgent()
        {
            GameManager.instance.RequestAgentSpawn();
        }

        public void RemoveRandomAgent()
        {
            GameManager.instance.RequestRemoveRandomAgent();
        }

        public void ClearAllAgents()
        {
            GameManager.instance.RequestClearAllAgents();
        }

        public void SentMsgInfoBox(string msg)
        {
            GameObject infoMsg = Instantiate(infoMsgPrefab);
            infoMsg.transform.SetParent(infoBoxContent, false);
            infoMsg.GetComponent<Text>().text = msg;
        }

        public void UpdateAgentsCounter(int value)
        {
            _agentsCount = value.ToString();
        }

        #endregion

        #region Unity-API
        private void Awake()
        {
            _agentsCount = 0.ToString();
            GameManager.UpdateAgentLabel += UpdateAgentsCounter;
            GameManager.SentInfoMsg += SentMsgInfoBox;
        }

        void OnGUI()
        {
            GUI.Label(new Rect(-83, 66, 500, 100), _agentsCount, new GUIStyle { fontSize = 25, alignment = TextAnchor.UpperCenter, normal = new GUIStyleState { textColor = Color.white } });
        }
        #endregion
    }
}
