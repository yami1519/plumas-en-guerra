using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using Tanks.Complete;
namespace Pollitos
{
    public class ChickMenuPreviews : MonoBehaviour
    {
        GameUIHandler ui; Camera[] cameras; RenderTexture[] textures;
        bool menuWasVisible;
        IEnumerator Start()
        {
            ui=GetComponent<GameUIHandler>(); yield return null;
            cameras=new Camera[ui.m_PlayerSlots.Length];textures=new RenderTexture[cameras.Length];
            for(int i=0;i<cameras.Length;i++)
            {
                var slot=ui.m_PlayerSlots[i];var preview=slot.TankPreview;if(!preview)continue;
                foreach(var c in preview.GetComponentsInChildren<Collider>(true))c.enabled=false;
                var rb=preview.GetComponent<Rigidbody>();if(rb)rb.isKinematic=true;
                foreach(var canvas in preview.GetComponentsInChildren<Canvas>(true))canvas.gameObject.SetActive(false);
                foreach(var t in preview.GetComponentsInChildren<Transform>(true))t.gameObject.layer=31;
                preview.transform.position=new Vector3(1000+i*20,0,0);preview.transform.rotation=Quaternion.identity;
                var cameraObject=new GameObject("Retrato "+i);var cam=cameraObject.AddComponent<Camera>();
                cam.cullingMask=1<<31;cam.clearFlags=CameraClearFlags.SolidColor;cam.backgroundColor=new Color(.98f,.94f,.78f,0);
                cam.orthographic=true;cam.orthographicSize=2.25f;cam.nearClipPlane=.1f;cam.farClipPlane=18;cam.depth=-20;
                cam.transform.position=preview.transform.position+new Vector3(4,3.1f,7);cam.transform.LookAt(preview.transform.position+Vector3.up*1.4f);
                FaceCamera(preview.transform,cam.transform);
                cam.GetUniversalAdditionalCameraData().renderPostProcessing=false;
                var rt=new RenderTexture(384,384,24,RenderTextureFormat.ARGB32);rt.Create();cam.targetTexture=rt;
                cameras[i]=cam;textures[i]=rt;
                slot.m_TankStats.text=new[]{"PÍO","COPITO","PEPITA","CAPITÁN"}[i]+"\nVida "+slot.TankPrefab.GetComponent<TankHealth>().m_StartingHealth+"\nDaño "+slot.TankPrefab.GetComponent<TankShooting>().m_MaxDamage;
                slot.m_TankStats.color=Color.white;slot.m_TankStats.faceColor=new Color32(255,245,210,255);
                var image=new GameObject("Retrato del pollito",typeof(RectTransform),typeof(RawImage));image.transform.SetParent(slot.m_TankPreviewPosition,false);
                var rect=image.GetComponent<RectTransform>();rect.sizeDelta=new Vector2(360,360);rect.anchoredPosition=new Vector2(0,110);
                var raw=image.GetComponent<RawImage>();raw.texture=rt;raw.raycastTarget=false;
            }
        }
        void LateUpdate()
        {
            if(cameras==null)return;
            bool menuVisible=ui.m_StartMenuRoot.gameObject.activeInHierarchy;
            for(int i=0;i<cameras.Length;i++)
            {
                if(cameras[i])
                {
                    cameras[i].enabled=menuVisible;
                    // Set the starting angle once when opening the menu; never pause rotation.
                    if(menuVisible && !menuWasVisible && ui.m_PlayerSlots[i].TankPreview)
                        FaceCamera(ui.m_PlayerSlots[i].TankPreview.transform,cameras[i].transform);
                }
                // StartMenuSlot handles the original demo preview rotation.
            }
            menuWasVisible=menuVisible;
        }
        static void FaceCamera(Transform preview,Transform camera)
        {
            Vector3 direction=Vector3.ProjectOnPlane(camera.position-preview.position,Vector3.up);
            if(direction.sqrMagnitude>0.001f)
                preview.rotation=Quaternion.LookRotation(direction,Vector3.up);
        }
        void OnDestroy()
        {if(cameras==null)return;for(int i=0;i<cameras.Length;i++){if(cameras[i])Destroy(cameras[i].gameObject);if(textures[i]){textures[i].Release();Destroy(textures[i]);}}}
    }
}
