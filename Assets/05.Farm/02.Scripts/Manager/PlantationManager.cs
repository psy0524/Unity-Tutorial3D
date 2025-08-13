using System;
using System.Collections;
using UnityEngine;

public class PlantationManager : MonoBehaviour
{
    public enum PlantationState {None, Seed, Harvest }
    public PlantationState plantationState;
    
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Vector2 fieldSize = new Vector2(11, 11);
    [SerializeField] private float tileSize = 2f;

    //[SerializeField] private GameObject currentPlant;
    [SerializeField] private int currPlantIndex;
    [SerializeField] private GameObject[] plants;
    [SerializeField] private GameObject[] crops;

    private GameObject[,] tileArray;
    private Camera mainCamera;
    [SerializeField] private LayerMask fieldLayerMask;

    void Awake()
    {
        mainCamera = Camera.main;
        tileArray = new GameObject[(int)fieldSize.x, (int)fieldSize.y];

        CreateField();
    }

    private void Update()
    {
        if (plantationState != PlantationState.None)
        {
            switch (plantationState)
            {
                case PlantationState.Seed:
                    OnSeed();
                    break;
                case PlantationState.Harvest:
                    OnHarvest();
                    break;
            }
        }
    }

    private void CreateField()
    {
        float offsetX = (fieldSize.x - 1) * tileSize / 2;
        float offsetY = (fieldSize.y - 1) * tileSize / 2;

        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                float posX = transform.position.x + i * tileSize - offsetX;
                float posZ = transform.position.z + j * tileSize - offsetY;

                GameObject tileObj = Instantiate(tilePrefab, transform.GetChild(0));

                tileObj.name = $"Tile_{i}_{j}";
                tileObj.transform.position = new Vector3(posX, 0, posZ);
                //tileArray[i, j] = tileObj;
                tileObj.GetComponent<Tile>().arrayPos = new Vector2Int(i, j);
            }
        }
    }

    private void OnSeed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f, fieldLayerMask))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;

                if (tileArray[tileX, tileY] == null)
                {
                    GameObject plant = Instantiate(plants[currPlantIndex], transform.GetChild(1));
                    plant.GetComponent<Plant>().plantIndex = currPlantIndex;

                    plant.transform.position = hit.transform.position;

                    tileArray[tileX, tileY] = plant;

                }
            }
        }
    }

    private void OnHarvest()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, fieldLayerMask))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;

                if (tileArray[tileX, tileY] != null)
                {
                    Plant plant = tileArray[tileX, tileY].GetComponent<Plant>();

                    if (plant.isHarvest)
                    {
                        plant.gameObject.SetActive(false);
                        tileArray[tileX, tileY] = null;

                        StartCoroutine(HarvestRoutine(plant.plantIndex, hit.transform.position));
                    }
                    
                    //GameObject plant = Instantiate(currentPlant, transform.GetChild(1));

                    //plant.transform.position = hit.transform.position;

                    //tileArray[tileX, tileY] = plant;

                }
            }
        }
    }

    IEnumerator HarvestRoutine(int index, Vector3 pos)
    {
        int ranAmount = UnityEngine.Random.Range(1, 4); // 1~3까지의 작물 개수 설정

        for(int i = 0; i < ranAmount; i++)
        {
            GameObject crop = Instantiate(crops[index]);
            crop.transform.position = pos;
            Rigidbody cropRb = crop.GetComponent<Rigidbody>();
            float ranX = UnityEngine.Random.Range(-2f, 2f);
            float ranZ = UnityEngine.Random.Range(-2f, 2f);
            var forceDir = new Vector3(ranX, 5f, ranZ);

            cropRb.AddForce(forceDir, ForceMode.Impulse);

            yield return new WaitForSeconds(0.15f);
        }
    }

    public void SetPlant(int index)
    {
        currPlantIndex = index;
    }

    public void SetState(PlantationState newState)
    {
        if(plantationState != newState)
        {
            plantationState = newState;
        }
    }
}
