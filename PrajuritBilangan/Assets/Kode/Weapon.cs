using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSprite;
    public GameObject bulletPrefab;
    public float fireRate;
    public AudioClip[] shootClips;
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        SoundManager.instance.PlaySfx(shootClips[Random.Range(0, shootClips.Length)]);
    }
}
