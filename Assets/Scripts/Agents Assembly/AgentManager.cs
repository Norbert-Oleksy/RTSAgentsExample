using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentsAssembly
{
    public class AgentManager : MonoBehaviour
    {
        #region Singleton
        public static AgentManager instance;
        #endregion

        #region Fields
        [SerializeField] private GameObject _agentPrefab;
        #endregion

        #region Variables
        private List<Agent> agents;
        private System.Random random;
        #endregion

        #region Methods
        public void SpawnAgent()
        {
            GameObject agentObj = Instantiate(_agentPrefab, Vector3.zero, Quaternion.identity);
            Agent agent = agentObj.GetComponent<Agent>();
            agent.InitiateAgent(Guid.NewGuid().ToString(),null);
            agents.Add(agent);
        }

        public void RemoveRandomAgent()
        {
            Agent agent = agents[random.Next(agents.Count)];
            agents.Remove(agent);
            agent.DeleteThisAgent();
            //Remember to add msg in infobox
        }

        public void ClearAllAgents()
        {
            foreach (Agent agent in agents)
            {
                agents.Remove(agent);
                agent.DeleteThisAgent();
            }
            //Remember to add msg in infobox
        }

        #endregion

        #region Unity-API
        private void Awake()
        {
            if (instance != null && instance != this) return;
            instance = this;
            random = new System.Random();
        }
        #endregion
    }
}
