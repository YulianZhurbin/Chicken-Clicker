using System.Collections;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosion;
    [SerializeField] ParticleSystem radiationSmoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode(Vector3 enemyPosition)
    {
        GameObject explosionParticles = Instantiate(enemyExplosion, enemyPosition, enemyExplosion.transform.rotation);
        StartCoroutine(RemoveParticles(explosionParticles, 1.0f));
    }

    IEnumerator RemoveParticles(GameObject particlesToRemove, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(particlesToRemove);
    }

    public void Irradiate()
    {
        radiationSmoke.Play();
    }

}
