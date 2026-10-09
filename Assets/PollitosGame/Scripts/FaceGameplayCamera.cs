using UnityEngine;
namespace Pollitos {
 public class FaceGameplayCamera:MonoBehaviour {
  void LateUpdate(){if(Camera.main)transform.rotation=Camera.main.transform.rotation;}
 }
}
