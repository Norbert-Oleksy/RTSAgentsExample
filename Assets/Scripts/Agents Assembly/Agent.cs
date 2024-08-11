using CoreAssembly;
using DG.Tweening;
using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentsAssembly
{
    public class Agent : MonoBehaviour
    {
        #region Fields
        [Header("Path Finding Logic")]
        [SerializeField] private Seeker seeker;
        #endregion

        #region Variables
        private string agentID;
        private Vector3? targetPoint;
        private Sequence moveSequence;
        #endregion

        #region Methods
        public void InitiateAgent(string id, Vector3? point)
        {
            agentID = id;
            targetPoint = point;
            GameManager.instance.SentMsgToInfoBox(string.Format("Agent {0} spawn", agentID));
            if(targetPoint!=null) FindAPathToPoint();
        }

        private void FindAPathToPoint()
        {
            seeker.StartPath(transform.position, targetPoint.Value, MoveToPoint);
        }

        private void MoveToPoint(Path path)
        {
            moveSequence = DOTween.Sequence();
            Vector3[] movePath = path.vectorPath.ToArray();
            moveSequence.Append(transform.DOPath(movePath, Vector3.Distance(transform.position, targetPoint.Value))).OnComplete(() => OnMoveComplete());
        }

        public void DeleteThisAgent()
        {
            moveSequence?.Kill();
            GameManager.instance.SentMsgToInfoBox(string.Format("Agent {0} was deleted", agentID));
            Destroy(gameObject);
        }

        public void SetNewTargetPoint(Vector3? point) {
            targetPoint = point;
            if (targetPoint != null) FindAPathToPoint();
        }

        private void OnMoveComplete()
        {
            GameManager.instance.SentMsgToInfoBox(string.Format("Agent {0} arrived", agentID));
            Vector3 newPoint;
            do
            {
                newPoint = GameManager.instance.GetRandomPoint().position;
            } while (newPoint == targetPoint);
            SetNewTargetPoint(newPoint);
        }
        #endregion

        #region Unity-API
        private void Awake()
        {
            moveSequence = DOTween.Sequence();
        }

        #endregion
    }
}
