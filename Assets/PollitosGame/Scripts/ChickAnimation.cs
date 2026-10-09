using UnityEngine;
using Tanks.Complete;
namespace Pollitos {
 // Only visual pivots move: the collider, muzzle and physics root stay stable.
 public class ChickAnimation : MonoBehaviour {
  public Transform leftFoot,rightFoot,leftWing,rightWing;
  TankMovement movement;TankShooting shooting;Vector3 previous;float stride,amount,flap;
  Quaternion lf,rf,lw,rw;
  public int ShotsAnimated {get;private set;}
  public float WalkAmount=>amount;
  void Awake(){movement=GetComponent<TankMovement>();shooting=GetComponent<TankShooting>();lf=leftFoot.localRotation;rf=rightFoot.localRotation;lw=leftWing.localRotation;rw=rightWing.localRotation;}
  void OnEnable(){previous=transform.position;amount=0;flap=0;shooting.ShotFired+=OnShot;}
  void OnDisable(){shooting.ShotFired-=OnShot;leftFoot.localRotation=lf;rightFoot.localRotation=rf;leftWing.localRotation=lw;rightWing.localRotation=rw;}
  void OnShot(){flap=1;ShotsAnimated++;}
  void LateUpdate(){
   float d=Vector3.Distance(transform.position,previous);previous=transform.position;
   float speed=(Time.deltaTime>0&&d<2&&movement.enabled)?d/Time.deltaTime:0;
   amount=Mathf.MoveTowards(amount,Mathf.Clamp01(speed/3),Time.deltaTime*8);
   stride+=speed*Time.deltaTime*5;float step=Mathf.Sin(stride)*32*amount;
   leftFoot.localRotation=lf*Quaternion.Euler(step,0,0);rightFoot.localRotation=rf*Quaternion.Euler(-step,0,0);
   flap=Mathf.MoveTowards(flap,0,Time.deltaTime*3.5f);float wings=Mathf.Sin(flap*Mathf.PI)*65;
   leftWing.localRotation=lw*Quaternion.Euler(0,0,-wings);rightWing.localRotation=rw*Quaternion.Euler(0,0,wings);
  }
 }
}
