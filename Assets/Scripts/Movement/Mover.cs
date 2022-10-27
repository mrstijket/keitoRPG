using RPG.Core;
using UnityEngine;
using UnityEngine.AI;
using RPG.Saving;
using System.Collections.Generic;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction, ISaveable
    {
        [SerializeField] Transform target;
        [SerializeField] float maxSpeed = 5f;

        NavMeshAgent navMeshAgent;
        Health health;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }
        void Update()
        {
            navMeshAgent.enabled = !health.isDead;
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination, float speedFluidity)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFluidity);
        }

        public void MoveTo(Vector3 destination, float speedFluidity)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFluidity);
            navMeshAgent.isStopped = false;
        }
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

        [System.Serializable]
        struct MoverSaveData
        {
            public SerializableVector3 position;
            public SerializableVector3 rotation;
        }

        public object CaptureState()
        {
            Dictionary<string, object> data = new Dictionary<string, object>(); //MoverSaveData data = new MoverSaveData();
            data["position"] = new SerializableVector3(transform.position); //data.position = new SerializableVector3(transform.position);
            data["rotation"] = new SerializableVector3(transform.eulerAngles); //data.rotation = new SerializableVector3(transform.eulerAngles);
            return data;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> data = (Dictionary<string, object>)state; //MoverSaveData data = (MoverSaveData)state;
            GetComponent<NavMeshAgent>().enabled = false; 
            transform.position = ((SerializableVector3)data["position"]).ToVector(); //transform.position = data.position.ToVector();
            transform.eulerAngles = ((SerializableVector3)data["rotation"]).ToVector(); //transform.eulerAngles = data.rotation.ToVector();
            GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}