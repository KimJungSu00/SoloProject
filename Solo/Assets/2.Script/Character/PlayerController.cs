using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions.Player
{
    public class PlayerController : MonoBehaviour
    {

        public float MoveSpeed;
        public float RotationSpeed;

        Status status;

        Rigidbody rigidBody;

        [HideInInspector]
        public Vector2 MoveInput;


        [HideInInspector]
        public float horizontalAngle = 0;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            status = GetComponent<Status>();
        }
        private void FixedUpdate()
        {
            Move();
        }
        void Move()
        {
            Vector3 direction = new Vector3(MoveInput.x, 0, MoveInput.y);
            direction = Quaternion.Euler(0, horizontalAngle, 0) * direction;
            if (MoveInput == Vector2.zero || status.isAttack)
            {
                status.isWalk = false;
                return;
            }

            status.isWalk = true;
            rigidBody.velocity = direction * MoveSpeed * Time.deltaTime;
            Quaternion newRotation = Quaternion.LookRotation(direction);
            rigidBody.rotation = Quaternion.Slerp(rigidBody.rotation, newRotation, RotationSpeed * Time.deltaTime);
        }

        public void Attack()
        {
            if (!status.isAttack)
                StartCoroutine(AttackCoroutine());
        }

        IEnumerator AttackCoroutine()
        {
            status.isAttack = true;
            yield return new WaitForSeconds(0.5f);
            status.isAttack = false;
        }

    }

}