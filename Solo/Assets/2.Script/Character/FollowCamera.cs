using UnityEngine;
namespace Actions.Camera
{
    public class FollowCamera : MonoBehaviour
    {

        GameObject target;
        [SerializeField]
        [Tooltip("중심축의 위치 변환")]
        Vector3 offset;
        [SerializeField]
        [Tooltip("타겟과 카메라의 거리")]
        float distance = 5.0f;

        [HideInInspector]
        public float horizontalAngle = 0;
        [HideInInspector]
        public float verticalAngle = 10f;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        private void LateUpdate()
        {
            Move();
        }

        void Move()
        {

            if (target != null)
            {
                Vector3 lookPosition = target.transform.position + offset;
                Vector3 relativePos = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * new Vector3(0, 0, -distance);
                transform.position = (lookPosition + relativePos);

                transform.LookAt(lookPosition);

            }
        }

    }
}