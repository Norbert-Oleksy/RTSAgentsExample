using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentsAssembly
{
    public class Agent : MonoBehaviour
    {
        #region Variables
        public string agentID { get; private set; }
        private Vector3? targetPoint;
        #endregion

        #region Methods
        public void InitiateAgent(string id, Vector3? point)
        {
            agentID = id;
            targetPoint = point;
        }

        private void MoveToPoint()
        {
            //TODO
            //targetPoint = null;
        }

        public void DeleteThisAgent()
        {
            Destroy(gameObject);
        }

        public void SetNewTargetPoint(Vector3? point) {
            targetPoint = point;
        }

        #endregion

        #region Unity-API
        private void Update()
        {
            if (targetPoint.HasValue) MoveToPoint();
        }
        #endregion
    }
}
