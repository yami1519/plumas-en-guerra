using UnityEngine;
namespace Pollitos {
 public class ChickIdentity : MonoBehaviour {
  void Awake(){ChickHitbox.Install(transform);}
  public string displayName;
  public Color accent=Color.white;
 }
}
