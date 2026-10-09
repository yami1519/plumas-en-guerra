using UnityEngine;
using Tanks.Complete;
namespace Pollitos
{
    // Presentation only: observes movement and health without changing combat.
    public class ChickSounds : MonoBehaviour
    {
        public AudioClip step, hurt;
        AudioSource voice; TankMovement movement; TankHealth health;
        Vector3 lastPosition; float lastHealth, distance;
        void Awake()
        {
            movement=GetComponent<TankMovement>(); health=GetComponent<TankHealth>();
            voice=gameObject.AddComponent<AudioSource>();voice.playOnAwake=false;voice.spatialBlend=0;
            var shooting=GetComponent<TankShooting>();
            if(shooting.m_ShootingAudio)voice.outputAudioMixerGroup=shooting.m_ShootingAudio.outputAudioMixerGroup;
        }
        void OnEnable(){lastPosition=transform.position;distance=0;lastHealth=health.m_StartingHealth;}
        void Update()
        {
            float current=health.m_Slider.value;
            if(current<lastHealth-.01f&&current>0&&hurt){voice.pitch=Random.Range(.94f,1.08f);voice.PlayOneShot(hurt,.55f);}
            lastHealth=current;
            float travelled=Vector3.Distance(lastPosition,transform.position);lastPosition=transform.position;
            if(!movement.enabled||travelled>3){distance=0;return;}
            distance+=travelled;
            if(distance>.95f&&step){distance=0;voice.pitch=Random.Range(.9f,1.12f);voice.PlayOneShot(step,.18f);}
        }
    }
}
