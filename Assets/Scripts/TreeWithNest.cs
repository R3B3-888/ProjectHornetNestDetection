using UnityEngine;

[System.Serializable]
public class TreeWithNest
{
    #region Variables
         
    private int id;
    private GameObject nest;
    private GameObject tree;
    private Vector3 treeSize;
    private float x;
    private float y;
    private float z;
    private float depthOffset = 1.0f;

    #endregion
    
    #region Getter And Setter
    public int Id { get => id; set => id = value; }
    public GameObject Nest { get => nest; set => nest = value; }
    public GameObject Tree { get => tree; set => tree = value; }
    public Vector3 TreeSize { get => treeSize; set => treeSize = value; }
    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }
    public float Z { get => z; set => z = value; }
    #endregion

    public TreeWithNest(int id, GameObject tree, GameObject nest)
    {
        this.id = id;
        this.nest = nest;
        nest.gameObject.name = "Nest";
        treeSize =  tree.GetComponent<MeshRenderer>().bounds.size;
        update(tree);
    }

    public void update(GameObject tree) 
    {
        this.tree = tree;
        x = tree.transform.position.x;
        y = tree.transform.position.y;
        z = tree.transform.position.z;
        nest.transform.position = new Vector3(x, y + treeSize.y * 5/6 * depthOffset, z);
        // nest.transform.position = new Vector3(50, 9, 10);
    }

    public string toString()
    {
        return "Height: " + treeSize.y + "; (x,y,z): (" + x + ", " + y + ", " + z + ")";
    }
}