using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;


    public ParticleSystem explosionParticle;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //get the script

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(),RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque(){
        return Random.Range(-maxTorque,maxTorque);
    }
    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange,xRange), -ySpawnPos);
    }

    private void OnMouseDown(){
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
        if(gameManager.isGameActive){
            gameManager.UpdateScore(pointValue);
        }
    }
    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")){
             gameManager.GameOver();
        }
    }
  
    // Update is called once per frame


    void Update()
    {
        
    }
}
