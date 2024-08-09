using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using static Codice.Client.Common.Threading.ThreadWaiter;

namespace CoreAssembly
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager instance;
        #endregion
        #region Fields
        [SerializeField] private List<Transform> listOfPoints;
        #endregion
        #region Events
        //UI Events
        public static event Action<int> UpdateAgentLabel;
        public static event Action<float> UpdateTimeLabel;
        public static event Action<string> SentInfoMsg;

        //AgentManager Events
        public static event Action AgentManagerSpawnAgent;
        public static event Action AgentManagerRemoveRandomAgent;
        public static event Action AgentManagerClearAllAgents;
        #endregion

        #region Variables
        private float _timeTick=1.0f;
        #endregion

        #region Methods - UI
        public void SentMsgToInfoBox(string msg)
        {
            SentInfoMsg?.Invoke(msg);
        }

        public void UpdateAgentsCounter(int value)
        {
            UpdateAgentLabel?.Invoke(value);
        }

        #endregion

        #region Methods - Agent
        public void RequestAgentSpawn()
        {
            AgentManagerSpawnAgent?.Invoke();
        }

        public void RequestRemoveRandomAgent()
        {
            AgentManagerRemoveRandomAgent?.Invoke();
        }

        public void RequestClearAllAgents()
        {
            AgentManagerClearAllAgents?.Invoke();
        }

        #endregion

        #region Methods - Time
        public void SetTickRate(float value)
        {
            _timeTick = value;
            UpdateTimeLabel?.Invoke(_timeTick);
        }
        public void ChangeTickRateBy(float value)
        {
            _timeTick += value;
            if (_timeTick < 0) _timeTick = 0;
            UpdateTimeLabel?.Invoke(_timeTick);
        }

        #endregion

        #region Unity-API
        private void Awake()
        {
            if (instance != null && instance != this) return;
            instance = this;
        }
        #endregion
    }
}
