using UnityEngine;

public class PlantationManager : MonoBehaviour
{
    public enum PlantationState { Seed, Harvest }
    public PlantationState plantationState;
    
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Vector2 fieldSize = new Vector2(11, 11);
    [SerializeField] private float tileSize = 2f;

    public GameObject plantPrefab;

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
        if (GameManager.Instance.cameraState == CameraState.Plantation)
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
                    GameObject plant = Instantiate(plantPrefab, transform.GetChild(1));

                    plant.transform.position = hit.transform.position;

                    tileArray[tileX, tileY] = plant;

                }
            }
        }
    }

    private void OnHarvest()
    {

    }
}
