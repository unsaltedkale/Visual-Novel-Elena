using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConDotBank : MonoBehaviour
{

    public GameManager gm;
    public Holder holder;
    [SerializeField] public List<Holder> holderList;
    [SerializeField] public List<GameManager.ConDot> tempcdList;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadToGm()
    {

        /*tempcdList.Add(holder.cd001);

        gm.cdlist.Clear();
        
        foreach (GameManager.ConDot cd in tempcdList)
        {
            gm.cdlist.Add(cd);
        }*/
    }
}
