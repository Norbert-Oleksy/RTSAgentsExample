using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
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
        [Header("Points System")]
        [SerializeField] private Transform pointsContainer;
        [SerializeField] private GameObject pointPrefab;
        #endregion
        #region Events
        //UI Events
        public static event Action<int> UpdateAgentLabel;
        public static event Action<float> UpdateTimeLabel;
        public static event Action<string> SentInfoMsg;

        //AgentManager Events
        public static event Action AgentManagerSpawnAgent, AgentManagerRemoveRandomAgent, AgentManagerClearAllAgents;
        //public static event Action AgentManagerRemoveRandomAgent;
        //public static event Action AgentManagerClearAllAgents;
        #endregion

        #region Variables
        [SerializeField] private List<Transform> points = new List<Transform>();
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
            Time.timeScale = value;
            UpdateTimeLabel?.Invoke(value);
        }
        public void ChangeTickRateBy(float value)
        {
            Time.timeScale = Mathf.Max(0f, Time.timeScale + value);
            UpdateTimeLabel?.Invoke(Time.timeScale);
        }

        #endregion

        #region Methods - Points
        public Transform GetRandomPoint()
        {
            if(points.Count == 0) SpawnNewPoint(new Vector3(UnityEngine.Random.Range(-100,100), 0, UnityEngine.Random.Range(-100, 100)));
            return GetRandomFromTheList(points);
        }

        public void SpawnNewPoint(Vector3 position)
        {
            GameObject point = Instantiate(pointPrefab,position, Quaternion.identity);
            point.transform.SetParent(pointsContainer, true);
        }

        #endregion

        #region Methods - Core
        public T GetRandomFromTheList<T>(List<T> list)
        {
            return list[UnityEngine.Random.RandomRange(0, list.Count)];
        }
        #endregion

        #region Unity-API
        private void Awake()
        {
            if (instance != null && instance != this) return;
            instance = this;
            points = pointsContainer.GetComponentsInChildren<Transform>().Where(t => t != pointsContainer.transform).ToList();
        }
        #endregion
    }
}
