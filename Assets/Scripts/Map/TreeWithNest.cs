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
    #endregion

    public TreeWithNest(int id, GameObject tree, GameObject nest)
    {
        this.id = id;
        this.nest = nest;
        nest.gameObject.name = "Nest";
        treeSize = tree.GetComponent<MeshRenderer>().bounds.size;
        update(tree);
    }

    public void update(GameObject tree)
    {
        this.tree = tree;
        x = tree.transform.position.x;
        y = tree.transform.position.y;
        z = tree.transform.position.z;
        nest.transform.position = new Vector3(x, y + treeSize.y * 5 / 6 * depthOffset, z);
        // nest.transform.position = new Vector3(50, 9, 10);
    }

    public string toString()
    {
        return "Height: " + treeSize.y + "; (x,y,z): (" + x + ", " + y + ", " + z + ")";
    }
}