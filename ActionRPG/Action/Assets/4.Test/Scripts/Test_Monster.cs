using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Test
{
    public class Test_Monster : Test_Character
    {
        public float ViewAngle;
        public float ViewDistance;

        [SerializeField]
        LayerMask targetMask;
       // public Transform target;

        public Vector3 LeftLine;
        public Vector3 RightLine;
        protected override void Move()
        {
            
            
        }
        private void Update()
        {
            View();
        }

        Vector3 BoundaryAngle(float angle)
        {
            angle += transform.eulerAngles.y;
            return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),0,Mathf.Cos(angle * Mathf.Deg2Rad));
        }

        void View()
        {
            LeftLine = BoundaryAngle(-ViewAngle * 0.5f);
            RightLine = BoundaryAngle(ViewAngle * 0.5f);

            Debug.DrawRay(transform.position + transform.up, LeftLine * ViewDistance, Color.red);
            Debug.DrawRay(transform.position + transform.up, RightLine * ViewDistance, Color.red);

            Collider[] target = Physics.OverlapSphere(transform.position, ViewDistance, targetMask);
            
            for( int i =0; i < target.Length; i++)
            {
                Transform targetTransform = target[i].transform;
                if (targetTransform.gameObject.tag == "Player")
                {
                    Vector3 direction = (targetTransform.position - transform.position).normalized;
                    float angle = Vector3.Angle(direction, Vector3.forward);
                    if(angle<ViewAngle *0.5f)
                    {
                        RaycastHit hit;
                        if(Physics.Raycast(transform.position + transform.up, direction, out hit, ViewDistance))
                        {
                            if (hit.transform.gameObject.tag == "Player")
                            {
                                Debug.DrawRay(transform.position + transform.up, direction*ViewDistance, Color.green);
                                
                            }
                            else
                            {
                                Debug.DrawRay(transform.position + transform.up, direction * ViewDistance, Color.yellow);
                            }
                        }
                    }
                }

            }
        }
    }
}