using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScript : MonoBehaviour
{
    private void Start()
    {
        SimpeObject[] mas1 = new SimpeObject[5];
        SimpeObject[] mas2 = new SimpeObject[3];

        mas1[0] = new SimpeObject { num = 0 };
        mas1[1] = null;
        mas1[2] = new SimpeObject { num = 2 };
        mas1[3] = new SimpeObject { num = 3 };
        mas1[4] = null;

        mas2[0] = new SimpeObject { num = 10 };
        mas2[1] = new SimpeObject { num = 11 };
        mas2[2] = new SimpeObject { num = 12 };

        SimpleFunc(mas1, mas2);
    }

    private void SimpleFunc(SimpeObject[] mas1, SimpeObject[] mas2)
    {
        Debug.Log("Before\n\n");

        Debug.Log("Mas1: ");
        foreach (SimpeObject so in mas1)
        {
            if (so != null)
                Debug.Log(so.num);
            else
                Debug.Log("null");
        }
        Debug.Log("Mas2: ");
        foreach (SimpeObject so in mas2)
        {
            Debug.Log(so.num);
        }


        List<int> indexesMas1 = new List<int>();
        List<int> indexesMas2 = new List<int>();


        for (int i = 0; i < mas2.Length; i++)
        {
            indexesMas2.Add(i);
        }

        for(int i = 0; i < mas1.Length; i++)
        {
            if(mas1[i] == null)
            {
                indexesMas1.Add(i);
            }
        }

        int[] tempMas = indexesMas1.ToArray();

        for (int i = 0; i < tempMas.Length; i++)
        {
            int matchInt1 = Random.Range(0, indexesMas1.Count);
            int matchInt2 = Random.Range(0, indexesMas2.Count);
            mas1[indexesMas1[matchInt1]] = mas2[indexesMas2[matchInt2]];
            indexesMas1.RemoveAt(matchInt1);
            indexesMas2.RemoveAt(matchInt2);

            if (indexesMas2.Count == 0)
                break;
        }

        Debug.Log("After\n\n");

        Debug.Log("Mas1: ");
        foreach (SimpeObject so in mas1)
        {
            if (so != null)
                Debug.Log(so.num);
            else
                Debug.Log("null");
        }
        Debug.Log("Mas2: ");
        foreach (SimpeObject so in mas2)
        {
            Debug.Log(so.num);
        }
    }
}
