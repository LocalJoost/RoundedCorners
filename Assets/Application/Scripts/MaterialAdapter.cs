using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MaterialAdapter : MonoBehaviour
{
    [SerializeField]
    private List<Material> replacementMaterials = new List<Material>();

    [SerializeField]
    private string replacementPrefix = "Round";
    
    void Start()
    {
        var replacementMaterialsDictionary = 
            replacementMaterials.ToDictionary(material => 
                material.name.Replace(replacementPrefix, string.Empty));

        var renderers = gameObject.GetComponentsInChildren<MeshRenderer>(true);
        foreach (var r in renderers)
        {
            if (r.sharedMaterial == null) continue;
            if (replacementMaterialsDictionary.ContainsKey(r.sharedMaterial.name))
            {
                r.sharedMaterial = replacementMaterialsDictionary[r.sharedMaterial.name];
            }
        }
    }
}
