using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using System.Collections;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Enemic : MonoBehaviour
{
    public GridManager gridManager;
    [SerializeField] public int hp;
    [SerializeField]
    Tilemap groundTilemap;
    [SerializeField] List<Enemic> list;
    [SerializeField] List<Jugador> listEnemic;
    [SerializeField] public Tilemap extraTilemap;
    [SerializeField]
    Tilemap collisionTilemap;
    [SerializeField] int moviment;
    [SerializeField] int RangAtac;
    [SerializeField] bool distancia = false;
    [SerializeField] public bool selected;
    public GameObject nums;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemic";
        if (RangAtac > moviment)
            distancia = true;
    }

    private void OnEnable()
    {
        for (int i = 0; i < SceneManager.GetSceneByName(SceneManager.GetActiveScene().name).GetRootGameObjects().Length; i++)
        {
            GameObject a = SceneManager.GetSceneByName(SceneManager.GetActiveScene().name).GetRootGameObjects()[i];
            if (a.name == "Grid")
            {
                for (int x = 0; x < a.transform.childCount; x++)
                {
                    if (a.transform.GetChild(x).name == "Mapa")
                    {
                        this.gridManager = a.transform.GetChild(x).GetComponent<GridManager>();
                        this.groundTilemap = a.transform.GetChild(x).GetComponent<Tilemap>();
                    }
                    else if (a.transform.GetChild(x).name == "Extra")
                        this.extraTilemap = a.transform.GetChild(x).GetComponent<Tilemap>();
                    else if (a.transform.GetChild(x).name == "Dificultat")
                    {
                        this.collisionTilemap = a.transform.GetChild(x).GetComponent<Tilemap>();
                    }
                }
            }
            else if (a.transform.tag == "Enemic")
            {
                if(a.transform.position != this.transform.position)
                    this.list.Add(a.transform.GetComponent<Enemic>());
            }
            else if (a.transform.tag == "Jugador")
            {
                this.listEnemic.Add(a.transform.GetComponent<Jugador>());
            }
        }
    }


    // Update is called once per frame
    bool ataque = false;
    void Update()
    {
        if (!listEnemic.IsUnityNull())
        {
            for (int x = 0; x < listEnemic.Count; x++)
            {
                if (listEnemic[x] != null)
                {
                    if (groundTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)) == groundTilemap.WorldToCell(listEnemic[x].transform.position))
                    {

                        if (this.selected && gridManager.torn==1)
                        {
                            this.atacar();
                            this.ataque = true;
                        }
                    }
                }
            }
        }
        if (!ataque)
        {
            this.QuitarSelect();
        }
        this.ataque = false;
    }

    public void Move(Vector2 direction)
    {
        print(CanMove(direction));
        if (this.selected)
        {
            if (CanMove(direction))
            {  
                print("Enemic Torn abans del canvi: " + gridManager.torn);
                gridManager.torn = 0;
                print("Enemic Torn despres del canvi: " + gridManager.torn);
                transform.position = new Vector3(groundTilemap.WorldToCell((Vector3)direction).x + 0.5f, groundTilemap.WorldToCell((Vector3)direction).y + 0.5f, groundTilemap.WorldToCell((Vector3)direction).z);
            }
            for (int x = groundTilemap.cellBounds.min.x; x < groundTilemap.cellBounds.max.x; x++)
            {
                for (int y = groundTilemap.cellBounds.min.y; y < groundTilemap.cellBounds.max.y; y++)
                {
                    for (int z = groundTilemap.cellBounds.min.z; z < groundTilemap.cellBounds.max.z; z++)
                    {
                        groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);
                    }
                }

            }
            this.selected = false;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        if (Vector3Int.Distance(groundTilemap.WorldToCell((Vector3)direction), groundTilemap.WorldToCell(this.transform.position)) <= moviment)
        {
            Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3)direction);
            if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) return false;
            return true;
        }
        return false;
    }

    public void Paint(Vector2 direction)
    {
        print(CanPaintMovement(direction));
        if (CanPaintMovement(direction))
        {

            groundTilemap.SetColor(groundTilemap.WorldToCell((Vector3)direction), Color.red);
            collisionTilemap.SetColor(groundTilemap.WorldToCell((Vector3)direction), Color.red);
        }
    }
    private bool CanPaintMovement(Vector2 direction)
    {
        if (!distancia)
        {
            for (int x = groundTilemap.cellBounds.min.x; x < groundTilemap.cellBounds.max.x; x++)
            {
                for (int y = groundTilemap.cellBounds.min.y; y < groundTilemap.cellBounds.max.y; y++)
                {
                    for (int z = groundTilemap.cellBounds.min.z; z < groundTilemap.cellBounds.max.z; z++)
                    {
                        if (Vector3Int.Distance(new Vector3Int(x, y, z), groundTilemap.WorldToCell(this.transform.position)) <= moviment)
                        {
                            groundTilemap.SetTileFlags(new Vector3Int(x, y, z), TileFlags.None);
                            groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)),new Color(255, 0, 0,0.74f));
                            extraTilemap.SetColor(extraTilemap.WorldToCell(new Vector3(x, y, z)), new Color(255, 0, 0, 0.74f));
                        }
                        else
                        {
                            groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);
                            extraTilemap.SetColor(extraTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);
                        }
                    }
                }
            }
            CanPaintAtk();
        }
        else
        {
            CanPaintAtk();
            for (int x = groundTilemap.cellBounds.min.x; x < groundTilemap.cellBounds.max.x; x++)
            {
                for (int y = groundTilemap.cellBounds.min.y; y < groundTilemap.cellBounds.max.y; y++)
                {
                    for (int z = groundTilemap.cellBounds.min.z; z < groundTilemap.cellBounds.max.z; z++)
                    {
                        if (Vector3Int.Distance(new Vector3Int(x, y, z), groundTilemap.WorldToCell(this.transform.position)) <= moviment)
                        {
                            groundTilemap.SetTileFlags(new Vector3Int(x, y, z), TileFlags.None);
                            groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), new Color(255, 0, 0, 0.74f));
                            extraTilemap.SetColor(extraTilemap.WorldToCell(new Vector3(x, y, z)), new Color(255, 0, 0, 0.74f));                        
                        }
                    }
                }
            }
        }


        Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) return false;
        return true;

    }
    void CanPaintAtk()
    {
        if (gridManager.torn==1) {
            for (int x = groundTilemap.cellBounds.min.x; x < groundTilemap.cellBounds.max.x; x++)
            {
                for (int y = groundTilemap.cellBounds.min.y; y < groundTilemap.cellBounds.max.y; y++)
                {
                    for (int z = groundTilemap.cellBounds.min.z; z < groundTilemap.cellBounds.max.z; z++)
                    {
                        if (Vector3Int.Distance(new Vector3Int(x, y, z), groundTilemap.WorldToCell(this.transform.position)) <= RangAtac)
                        {
                            groundTilemap.SetTileFlags(new Vector3Int(x, y, z), TileFlags.None);
                            groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), Color.red);
                            extraTilemap.SetColor(extraTilemap.WorldToCell(new Vector3(x, y, z)), Color.red);

                        }
                        else
                        {
                            if (distancia)
                            {
                                groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);
                                extraTilemap.SetColor(extraTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);

                            }
                        }
                    }
                }
            }
        }
    }

    void QuitarSelect()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3Int gridPosition = groundTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            for (int x = 0; x < list.Count; x++)
            {
                if (list[x] != null)
                    if (groundTilemap.WorldToCell(list[x].transform.position) == gridPosition) this.selected = false;
            }
        }
    }
    
    private void OnMouseDown()
    {
        this.Paint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (!this.selected && gridManager.torn == 1)
        {
            this.selected = true;
            print("Estic sel�leccionant " + this.gameObject.name);
        }
        else
        {
            for (int x = groundTilemap.cellBounds.min.x; x < groundTilemap.cellBounds.max.x; x++)
            {
                for (int y = groundTilemap.cellBounds.min.y; y < groundTilemap.cellBounds.max.y; y++)
                {
                    for (int z = groundTilemap.cellBounds.min.z; z < groundTilemap.cellBounds.max.z; z++)
                    {
                        groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);
                        extraTilemap.SetColor(extraTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);
                    
                    }
                }

            }
            this.selected = false;
        }
        print(this.selected);
    }
    void atacar()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3Int gridPosition = groundTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if ((Vector3Int.Distance(gridPosition, groundTilemap.WorldToCell(this.transform.position)) <= RangAtac))
            {
                for (int x = 0; x < listEnemic.Count; x++)
                {
                    if (listEnemic[x] != null)
                    {
                        if (gridPosition == groundTilemap.WorldToCell(listEnemic[x].transform.position) && gridManager.torn == 1)
                        {
                            print("Enemic He atacado, selected: " + this.selected+" torn:"+gridManager.torn);
                            listEnemic[x].danyar();
                            gridManager.torn = 0;
                            print("Yo"+this.name+": te pego");
                            print(listEnemic[x].name+"Enemigo: Ai");
                            if (listEnemic[x].hp <= 0)
                            {
                                this.listEnemic.Remove(listEnemic[x]);
                            }
                            this.selected = false;
                        }
                    }
                }
            }
        }
    }
    public void danyar()
    {
        if (gridManager.torn == 0)
        {
            this.hp--;
            if (this.hp > 0)
            {
                Destroy(this.transform.GetChild(0).gameObject);
                GameObject num = Instantiate(nums.transform.GetChild(this.hp - 1).gameObject, this.transform);
                num.transform.position = new Vector3(this.transform.position.x + 0.1f, this.transform.position.y - 0.15f, 0);
            }
            if (this.hp <= 0)
            {
                //Player1Manager.getInstance().setMoney(10);
                InfoCompartida.monedes += 5;
                Destroy(this.gameObject);
            }
        }
    }

}