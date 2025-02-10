using System;
using System.Resources;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private GameObject soldierPrefab;
    [SerializeField] private Vector3 dragonOffset;
    [SerializeField] private Vector3 soldierOffset;

    private GameObject dragon;
    private GameObject soldier;
    private ARTrackedImageManager arTrackedImageManager;

    private void OnEnable()
    {
        arTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            if (image.referenceImage.name == "SpawnImage")
            {
                dragon = Instantiate(dragonPrefab, image.transform);
                dragon.transform.position = dragonOffset;
            }
            
            else if (image.referenceImage.name == "SoldierImage")
            {
                soldier = Instantiate(soldierPrefab, image.transform);
                soldier.transform.position = soldierOffset;
            }
        }

    }
}
