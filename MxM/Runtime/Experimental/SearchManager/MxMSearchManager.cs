// Copyright © 2017-2024 Vault Break Studios Pty Ltd

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MxM
{
    public class MxMSearchManager : MonoBehaviour
    {
        [SerializeField] private int m_maxUpdatesPerFrame;
        [SerializeField] private float m_maxAllowableDelay;
        [SerializeField] private int m_expectedActorCount;
        

        public static MxMSearchManager Instance { get; private set; } = null;

        private struct ScheduleRequest
        {
            public MxMAnimator Animator;
            public int Priority;
            public float RequestTime;
        }

        private List<ScheduleRequest> ScheduleRequests = null;
        
        
        // Start is called before the first frame update
        void Start()
        {
            if (Instance != null)
            {
                Debug.LogWarning(
                    "Attempting to create an MxMSearchManager but one already exists and only one is allowed.");
                Destroy(this);
                return;
            }

            Instance = this;
            ScheduleRequests = new List<ScheduleRequest>(m_expectedActorCount);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void UpdatePhase2()
        {
            
        }

        void LateUpdate()
        {
            
        }

        void FixedUpdate()
        {
            
        }

        public void RequestPoseScheduledSearch(MxMAnimator a_animator, int a_priority)
        {
            ScheduleRequests.Add(new ScheduleRequest()
            {
                Animator = a_animator, 
                Priority = a_priority, 
                RequestTime = Time.deltaTime
            });
        }
    }
}