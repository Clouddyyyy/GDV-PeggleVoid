using UnityEngine;



public class ShootBall : MonoBehaviour
{

     //in de inspector moet de prefab van de bal in dit veld (variabele) gesleept worden.
    [SerializeField] private GameObject prefab;
    //kracht die de bal krijgt per seconde dat we de knop inhouden
    [SerializeField] private float forceBuild = 20f;
    //maximale tijd om bij te houden hoe lang we de knop hebben ingedrukt
    [SerializeField] private float maximumHoldTime = 5f;

    //Deze variabelen zijn niet zichtbaar in de inspector

    //Bijhouden hoe lang we de knop hebben ingedrukt (seconden)
    private float _pressTimer = 0f;
    //Totale kracht waarmee de bal wordt afgevoord
    private float _launchForce = 0f;

    [SerializeField] private float lineSpeed = 10f;
    private LineRenderer _line;
    private bool _lineActive = false;


 private void Start()
 {
   
     _line = GetComponent<LineRenderer>();
    
     _line.SetPosition(1,Vector3.zero);

      if (Input.GetMouseButtonDown(0))
    {
        _pressTimer = 0f;
        _lineActive = true;
    }

    if (Input.GetMouseButtonUp(0))
    {

       


        _lineActive = false;
        _line.SetPosition(1, Vector3.zero);
    }
    

 }
  
   

    private void Update(){
        HandleShot();
    }
    //Die functie scrijven we zelf
    private void HandleShot() {
        
         if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0; //reset de timer weer op 0. Verderop gaan we de tijd hierin bijhouden hoe lang we de knop hebben ingehouden
            _lineActive = true;
        }
            
        
       
        if (Input.GetMouseButtonUp(0))
        {
            
            _launchForce = _pressTimer * forceBuild;

            
            GameObject ball = Instantiate(prefab, transform.parent);

            
            ball.transform.rotation = transform.rotation;

           
            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);

           
            ball.transform.position = transform.position;
             _lineActive = false;
            _line.SetPosition(1, Vector3.zero);
        }
        
        if(_pressTimer < maximumHoldTime){
             /*Elk frame tellen we de duur van het frame op bij de verstreken tijd sinds we de knop in hebben gedrukt. Zodra we deze los laten weten we dus hoe lang dit duurde */
            _pressTimer += Time.deltaTime;
        }

          if (_lineActive) {
        _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
    }

    

    }
   
}