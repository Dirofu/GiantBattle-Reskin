using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : Info
{
    [SerializeField] private SkinnedMeshRenderer _renderer;

    [SerializeField] private List<Material> _materials;
    [SerializeField] private List<Sprite> _flagSprites;
    [SerializeField] private List<string> _names;

    public int CountMaterials => _materials.Count;
    public int CountFlags => _flagSprites.Count;
    public int CountNames => _names.Count;

    public void SetInfo(int numberMaterial, int numberFlag, int numberName)
    {
        _renderer.material = _materials[numberMaterial];
        Flag.sprite = _flagSprites[numberFlag];
        Name.text = _names[numberName].ToString();
    }
}
