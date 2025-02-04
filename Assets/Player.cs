using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float velo = 0.02f;
    [SerializeField]
    private float mx,my;
    [SerializeField]
    private float maxX,minX,maxY,minY;
    public FixedJoystick moveJoy;
    public GameObject tiroLazer;
    public Transform aqui;
    public Transform pontoTiro;

    public Button button;
    private bool tirolivre = true;
    
    
    void Start()
    {
       
        
        SetminMax();
        //Debug.Log(" vert"+ maxY + " "+ minY);
       // Debug.Log("Horiz" + maxX + " "+ minX);
        button.onClick.AddListener(Onfire);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
    }

    private void DragToque()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved )
        {
            Vector2 toqueposicao = Input.GetTouch(0).deltaPosition;
            transform.Translate(0f,toqueposicao.y * velo * Time.deltaTime ,0f);
            
        }
    }

    private void Onfire()
    {
        if(tirolivre)
        {
            tirolivre =  false;
            GameObject temp = Instantiate(tiroLazer, pontoTiro.position, pontoTiro.rotation);
            temp.transform.parent = aqui;
            StartCoroutine(espera());
        }
       

         
        
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(0.5f);
        tirolivre = true;
    }

    private void MovePlayer()
    {
            
       if(moveJoy.Horizontal > 0 && mx <maxX)
       {
           transform.Translate(Vector3.right * velo * Time.deltaTime);
           
       }
       if(moveJoy.Horizontal < 0 && mx > minX)
       {
            transform.Translate(Vector3.left * velo * Time.deltaTime);
       }


       if(moveJoy.Vertical >0 && my <maxY)
       {
            transform.Translate(Vector3.up * velo * 2f*  Time.deltaTime);
       }
       
        if(moveJoy.Vertical <0 && my > minY)
       {
            transform.Translate(Vector3.down* velo * 2f * Time.deltaTime);
       }

        mx = transform.position.x;
        my = transform.position.y;
       //transform.Translate(mx,my,0f);
       //Debug.Log(mx + "  " + my);
    }

    private void SetminMax()
    {
        Vector3 borda = Camera.main.ScreenToWorldPoint( new Vector3(Screen.safeArea.width, 0f,0f));
        maxX = 0; 
        minX = -7;
        maxY = 4.4f;
        minY = -4.4f;
 

    }


}
