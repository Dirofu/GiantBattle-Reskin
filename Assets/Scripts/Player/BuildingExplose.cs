using UnityEngine;

public class BuildingExplose : MonoBehaviour
{
    [SerializeField] private int _minExplosionRank;
    [SerializeField] private Shake _cameraShake;

    private ParticleSystem _explosionParticle;
    private AudioSource _explosionSound;

    private void Start()
    {
        _explosionParticle = GetComponent<ParticleSystem>();
        _explosionSound = GetComponent<AudioSource>();
    }

    private void PlacingExplosionToBuilding(Transform building)
    {
        transform.position = new Vector3(building.transform.position.x, transform.position.y, building.transform.position.z);
    }

    private void PlayExplosion()
    {
        _explosionParticle.Play();
        _explosionSound.Play();
    }

    private void DestroyBuilding(Transform building)
    {
        PlacingExplosionToBuilding(building);
        PlayExplosion();
    }

    public void TryExplose(int rank, Transform building)
    {
        if (rank >= _minExplosionRank)
        {
            DestroyBuilding(building);
            _cameraShake.Shaking();
        }
    }
}
