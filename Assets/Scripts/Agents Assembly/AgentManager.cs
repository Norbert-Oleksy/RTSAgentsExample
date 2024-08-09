using CoreAssembly;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

namespace AgentsAssembly
{
    public class AgentManager : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GameObject agentPrefab;
        #endregion

        #region Variables
        private List<Agent> agents;
        private System.Random random;
        #endregion

        #region Methods
        public void SpawnAgent()
        {
            GameObject agentObj = Instantiate(agentPrefab, Vector3.zero, Quaternion.identity);
            Agent agent = agentObj.GetComponent<Agent>();
            agent.InitiateAgent(Guid.NewGuid().ToString(),null);
            agents.Add(agent);
            GameManager.instance.UpdateAgentsCounter(agents.Count);
        }

        public void RemoveRandomAgent()
        {
            if(agents.Count==0) return;
            Agent agent = agents[random.Next(agents.Count)];
            agents.Remove(agent);
            agent.DeleteThisAgent();
            GameManager.instance.UpdateAgentsCounter(agents.Count);
        }

        public void ClearAllAgents()
        {
            foreach (var agent in agents)
            {
                agent.DeleteThisAgent();
            }
            agents.Clear();
            GameManager.instance.UpdateAgentsCounter(agents.Count);
        }

        #endregion

        #region Unity-API
        private void Awake()
        {
            random = new System.Random();
            agents = new List<Agent>();
            GameManager.AgentManagerSpawnAgent += SpawnAgent;
            GameManager.AgentManagerRemoveRandomAgent += RemoveRandomAgent;
            GameManager.AgentManagerClearAllAgents += ClearAllAgents;
        }
        #endregion
    }
}