using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script {
    public class CircleSphereController : MonoBehaviour
    {
        private Transform _spheresHolder;
        [SerializeField] private GameObject spherePrefab = default;
        [SerializeField] private Vector3 rotationCenter = default;
        [SerializeField] private float radius = 2f;
        [SerializeField] private int numberOfPoints = 6;
        [SerializeField] private float demi_grand_axe1;
        [SerializeField] private float demi_grand_axe2;
        [SerializeField] private Vector3 centre;

        private void Awake()
        {
            _spheresHolder = transform;
        }

        private void Start()
        {
            StartCoroutine(UpdateSpheres());
        }

        private IEnumerator UpdateSpheres()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);

                // Retrieve circle points
                List<Vector3> circlePoints = GetCirclePoints();

                // Remove previously instantiated spheres
                foreach (Transform child in _spheresHolder) Destroy(child.gameObject);

                // Instantiate new spheres
                foreach (Vector3 circlePoint in circlePoints)
                    Instantiate(spherePrefab, circlePoint, Quaternion.identity, _spheresHolder);
            }
        }

        private List<Vector3> GetCirclePoints()
        {
            List<Vector3> circlePoints = new List<Vector3>();
            List<float> coordonnesX = new List<float>();
            List<float> coordonnesY = new List<float>();
            List<List<float>> coordonnes = new List<List<float>>();
            float angle = 2 * Mathf.PI / numberOfPoints;
            for (int i = 0; i < numberOfPoints; i++)
            {

                // LET'S HAVE FUN !
                // On defini une elipse qui a deux demi grand axe indépendant.
                float x = Mathf.Cos(angle * i) * Mathf.Sqrt(((demi_grand_axe1) * (demi_grand_axe1)) +
                                                            ((Mathf.Cos(angle * i)) * (Mathf.Cos(angle * i))));
                float y = Mathf.Sin(angle * i) * Mathf.Sqrt(((demi_grand_axe2) * (demi_grand_axe2)) +
                                                            ((Mathf.Sin(angle * i)) * (Mathf.Sin(angle * i))));
                
                //si on veut un cercle :
                /*
                demi_grand_axe1 = demi_grand_axe2
                float x = Mathf.Cos(angle * i) * Mathf.Sqrt(((demi_grand_axe1) * (demi_grand_axe1)) +
                                                            ((Mathf.Cos(angle * i)) * (Mathf.Cos(angle * i))));
                float y = Mathf.Sin(angle * i) * Mathf.Sqrt(((demi_grand_axe2) * (demi_grand_axe2)) +
                                                            ((Mathf.Sin(angle * i)) * (Mathf.Sin(angle * i))));
                */
                coordonnesX.Add(x);
                coordonnesY.Add(y);
                //Debug.Log(coordonnesX[i]);
                //Debug.Log(coordonnesY[i]);
            }

            coordonnes.Add(coordonnesX);
            coordonnes.Add(coordonnesY);
            List<Vector3> coordSphere = new List<Vector3>();
            for (int i = 0; i < coordonnesX.Count; i++)
            {
                coordSphere.Add(new Vector3(
                    centre.x + coordonnes[0][i],
                    centre.y + coordonnes[1][i],
                    centre.z));
                //Debug.Log(coordSphere[i]);
            }

            return coordSphere;
        }
    }
}