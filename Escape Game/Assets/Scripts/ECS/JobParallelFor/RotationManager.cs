using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets.Scripts.ECS.JobParellelFor
{
    class RotationManager : MonoBehaviour
    {
        private TransformAccessArray _transforms;
        private RotationSpeed_ParallelFor _job;
        private JobHandle _jobHandle;

        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private float _speed;

        private void OnDisable()
        {
            this._jobHandle.Complete();
            this._transforms.Dispose();
        }

        private void Start()
        {
            this._transforms = new TransformAccessArray(0, -1);
            this.Spawn(3);
        }
        
        private void Spawn(int amount)
        {
            this._jobHandle.Complete();

            this._transforms.capacity = this._transforms.length + amount;
            for (int i = 0; i < amount; i++)
            {
                Vector3 pos = new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f));
                var obj = Instantiate(this._prefab, pos, Quaternion.identity);
                this._transforms.Add(obj.transform);
            }
        }

        private void Update()
        {
            this._jobHandle.Complete();
            if (Input.GetKeyDown("space"))
                this.Spawn(1);

            this._job = new RotationSpeed_ParallelFor()
            {
                deltaTime = Time.deltaTime,
                rotationSpeed = this._speed
            };
            this._jobHandle = this._job.Schedule(this._transforms);
            JobHandle.ScheduleBatchedJobs();
        }
    }
}
