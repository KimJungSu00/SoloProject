using UnityEngine;
namespace Actions.Camera
{
    public class FollowCamera : MonoBehaviour
    {

        [SerializeField]
        GameObject target;
        [SerializeField]
        [Tooltip("중심축의 위치 변환")]
        Vector3 offset;


        private void LateUpdate()
        {
            Move();
        }

        void Move()
        {
            if (target != null)
            {
                Vector3 lookPosition = target.transform.position + offset;
                transform.position = lookPosition;
                transform.LookAt(lookPosition);

            }
        }

    }
}