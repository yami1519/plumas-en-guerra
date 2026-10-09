using UnityEngine;
namespace Pollitos
{
    // Projectile-only volume. The smaller solid capsule still controls walking.
    public static class ChickHitbox
    {
        public static void Install(Transform root)
        {
            if(root.Find("Zona de impacto del cuerpo"))return;
            foreach(var mesh in root.GetComponentsInChildren<MeshFilter>())
            {
                if(mesh.name!="Chick001" && mesh.name!="Chick1" && mesh.name!="Body" && mesh.name!="Body.003")continue;
                if(!mesh.sharedMesh)continue;
                Bounds source=mesh.sharedMesh.bounds;Bounds local=new Bounds();bool first=true;
                for(int x=-1;x<=1;x+=2)for(int y=-1;y<=1;y+=2)for(int z=-1;z<=1;z+=2)
                {
                    Vector3 point=root.InverseTransformPoint(mesh.transform.TransformPoint(source.center+Vector3.Scale(source.extents,new Vector3(x,y,z))));
                    if(first){local=new Bounds(point,Vector3.zero);first=false;}else local.Encapsulate(point);
                }
                var obj=new GameObject("Zona de impacto del cuerpo");obj.layer=root.gameObject.layer;obj.transform.SetParent(root,false);
                var hit=obj.AddComponent<CapsuleCollider>();hit.isTrigger=true;hit.center=local.center;
                hit.radius=Mathf.Min(local.size.x,local.size.z)*.45f;hit.height=Mathf.Max(local.size.y,hit.radius*2);
                return;
            }
        }
    }
}
