using UnityEngine;
using Tanks.Complete;
namespace Pollitos
{
    [DefaultExecutionOrder(30)]
    public class ChickMotor : MonoBehaviour
    {
        TankMovement movement; Rigidbody body;
        void Awake(){ movement=GetComponent<TankMovement>(); body=GetComponent<Rigidbody>(); }
        void FixedUpdate()
        {
            if(!movement.enabled || body.isKinematic || movement.m_IsComputerControlled)return;
            var actions=movement.m_InputUser.ActionAsset;
            float x=actions.FindAction("Horizontal").ReadValue<float>();
            float y=actions.FindAction("Vertical").ReadValue<float>();
            var camera=Camera.main;
            if(!camera)return;
            Vector3 forward=Vector3.ProjectOnPlane(camera.transform.forward,Vector3.up);
            if(forward.sqrMagnitude<.01f)forward=Vector3.ProjectOnPlane(camera.transform.up,Vector3.up);
            forward.Normalize(); Vector3 right=Vector3.Cross(Vector3.up,forward);
            Vector3 direction=Vector3.ClampMagnitude(forward*y+right*x,1);
            if(direction.sqrMagnitude<.02f)direction=Vector3.zero;
            body.linearVelocity=Vector3.MoveTowards(body.linearVelocity,direction*movement.m_Speed,65*Time.fixedDeltaTime);
            if(direction.sqrMagnitude>.02f) body.MoveRotation(Quaternion.RotateTowards(body.rotation,Quaternion.LookRotation(direction),650*Time.fixedDeltaTime));
        }
    }
}
