using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Squarescript : MonoBehaviour
{
    [SerializeField] private GameObject objet = default;
    [SerializeField] private Vector3 centre;
    [SerializeField] private float cote;
    [SerializeField] private int nbPoints = 8;
    [SerializeField] private float angleRotationX = 90f;
    [SerializeField] private float angleRotationY = 90f;
    [SerializeField] private float angleRotationZ = 90f;


    private Transform _formeCercle;

     void Awake()
     {
        _formeCercle = transform;
     }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initialisation());
    }
    private IEnumerator Initialisation()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                Debug.Log("test");
                List<Vector3> data = CalculPoints();
                foreach (Transform sousObjet in _formeCercle)
                {
                    Destroy(sousObjet.gameObject);
                }
                foreach (Vector3 fablab in data)
                {
                    Debug.Log(angleRotationX);
                    Debug.Log(angleRotationY);
                    Debug.Log(angleRotationZ);
                    Instantiate(objet, fablab, Quaternion.Euler( angleRotationX, angleRotationY,
                                            angleRotationZ), _formeCercle);
                }

            }
        }
    private List<Vector3> CalculPoints() {

        List<float> coordonnesX = new List<float> ();
        List<float> coordonnesY = new List<float> ();
        List<List<float>> coordonnes = new List<List<float>> ();
        float angle = 2*Mathf.PI / nbPoints;
        for (int i = 0; i < nbPoints; i++)
        {
            float x = Mathf.Sqrt(((cote)*(cote))+((Mathf.Cos(angle*i))*(Mathf.Cos(angle*i))));
            float y = Mathf.Sqrt(((cote)*(cote))+((Mathf.Sin(angle*i))*(Mathf.Sin(angle*i)))); 
            coordonnesX.Add(x);
            coordonnesY.Add(y);
            //Debug.Log(coordonnesX[i]);
            //Debug.Log(coordonnesY[i]);
        }
        coordonnes.Add(coordonnesX);
        coordonnes.Add(coordonnesY);
        List<Vector3> coordSphere = new List<Vector3>();
        for (int i = 0; i < coordonnesX.Count; i++) {
            coordSphere.Add(new Vector3(
                centre.x + coordonnes[0][i],
                centre.y + coordonnes[1][i],
                centre.z));
            //Debug.Log(coordSphere[i]);
        }
        return coordSphere;
    }
    }
