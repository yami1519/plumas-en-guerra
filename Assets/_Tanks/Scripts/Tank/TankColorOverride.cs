using UnityEngine;

public class TankColorOverride : MonoBehaviour
{
    public Color customColor = Color.red; // Elige el color que quieras en el Inspector

    void Start()
    {
        // Aplica el color de forma independiente usando un bloque de propiedades de material
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();

        foreach (var rend in renderers)
        {
            rend.GetPropertyBlock(propBlock);
            propBlock.SetColor("_BaseColor", customColor); // Propiedad estándar de URP
            rend.SetPropertyBlock(propBlock);
        }
    }
}