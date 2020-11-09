using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    private Collider2D drag;
    public LayerMask layer;
    [SerializeField]
    private bool clicked;
    private Touch touch;

    public LineRenderer lineFront;
    public LineRenderer lineBack;

    private Ray leftCatapultRay;
    private CircleCollider2D pedraCol;
    private Vector2 catapultToRock;
    private Vector3 pointL;

    private SpringJoint2D spring;
    private Vector2 prevVel;
    private Rigidbody2D pedraRB;

    public GameObject bomba;

    //limite do elastico

    private Transform catapult;
    private Ray rayToMT;

    //rastro

    private TrailRenderer rastro;

    public Rigidbody2D CatapultRB;
    public bool estouPronto = false;

    public AudioSource audioObjeto;
    public GameObject audioMorteObjeto;

    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        lineFront = (LineRenderer)GameObject.FindWithTag("LF").GetComponent<LineRenderer>();
        lineBack = (LineRenderer)GameObject.FindWithTag("LB").GetComponent<LineRenderer>();
        CatapultRB = GameObject.FindWithTag("LB").GetComponent<Rigidbody2D>();
        spring.connectedBody = CatapultRB;
        Vector2 temp = spring.connectedAnchor;
        temp.x = 0;
        temp.y = 0;
        spring.connectedAnchor = temp;
        drag = GetComponent<Collider2D>();
        leftCatapultRay = new Ray(lineFront.transform.position, Vector3.zero);
        pedraCol = GetComponent<CircleCollider2D>();
        pedraRB = GetComponent<Rigidbody2D>();
        catapult = spring.connectedBody.transform;
        rayToMT = new Ray(catapult.position, Vector3.zero);
        rastro = GetComponentInChildren<TrailRenderer>();
        audioObjeto = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupLine();
    }

    // Update is called once per frame
    void Update()
    {
        LineUpdate();
        SpringEffect();
        prevVel = pedraRB.velocity;

#if UNITY_ANDROID

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(wp, Vector2.zero, Mathf.Infinity, layer.value);
            if (hit.collider != null)
            {
                if(GameManager.instance.pausado == false) { 
                    if(transform.position == GameManager.instance.pos.position) { 
                        clicked = true;
                        rastro.enabled = false;
                        estouPronto = true;
                    }
                }
            }
            if (clicked)
            {
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    Vector3 tPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10));
                    catapultToRock = tPos - catapult.position;
                    if (catapultToRock.sqrMagnitude > 9f)
                    {
                        rayToMT.direction = catapultToRock;
                        tPos = rayToMT.GetPoint(3f);
                    }
                    transform.position = tPos;
                    rastro.enabled = false;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    pedraRB.isKinematic = false;
                    clicked = false;
                    rastro.enabled = true;
                }
            }
        }
#endif

#if UNITY_EDITOR

        if(clicked)
        {
            Dragging();
        }

#endif

        if (clicked==false && pedraRB.isKinematic==false && pedraRB.IsSleeping())
        {
            DestroiPedra();
            pedraRB.isKinematic = true;
        }

        if (pedraRB.isKinematic == false)
        {
            Vector3 posCam = Camera.main.transform.position;
            posCam.x = transform.position.x;
            posCam.x = Mathf.Clamp(posCam.x,GameManager.instance.objE.position.x, GameManager.instance.objD.position.x);
            Camera.main.transform.position = posCam;
        }
    }

    void SetupLine()
    {
        lineFront.SetPosition(0, lineFront.transform.position);
        lineBack.SetPosition(0, lineBack.transform.position);
    }

    void LineUpdate()
    {
        if (transform.name == GameManager.instance.nomeObjeto)
        {
            catapultToRock = transform.position - lineFront.transform.position;
            leftCatapultRay.direction = catapultToRock;
            pointL = leftCatapultRay.GetPoint(catapultToRock.magnitude + pedraCol.radius);
            lineFront.SetPosition(1, pointL);
            lineBack.SetPosition(1, pointL);
        }
    }

    void SpringEffect()
    {
        if (spring != null && GameManager.instance.objetosEmCena > 0)
        {
            if (pedraRB.isKinematic == false)
            {
                if (prevVel.sqrMagnitude > pedraRB.velocity.sqrMagnitude)
                {
                    lineFront.enabled = false;
                    lineBack.enabled = false;
                    Destroy(spring);
                    pedraRB.velocity = prevVel;
                }
            }else if (pedraRB.isKinematic == true && transform.position  == GameManager.instance.pos.position)
            {
                lineFront.enabled = true;
                lineBack.enabled = true;
            }
        }
    }

    void DestroiPedra()
    {
        if (pedraRB.velocity.magnitude == 0 && pedraRB.IsSleeping())
        {
            StartCoroutine(TempoParaDestruirPedra());
        }
    }

    IEnumerator TempoParaDestruirPedra()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(bomba, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Instantiate(audioMorteObjeto, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
            GameManager.instance.objetosNum -= 1;
            GameManager.instance.objetosEmCena = 0;
            GameManager.instance.objetoLancado = false;
            estouPronto = false;
    }

    //mouse

    void Dragging()
    {
        if (pedraRB.isKinematic)
        {
            Vector3 mouseWP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWP.z = 0f;
            catapultToRock = mouseWP - catapult.position;
            if (catapultToRock.sqrMagnitude > 9f)
            {
                rayToMT.direction = catapultToRock;
                mouseWP = rayToMT.GetPoint(3f);
            }
            transform.position = mouseWP;
        }
    }

    void OnMouseDown()
    {
        if (GameManager.instance.pausado == false) {
            if (transform.position == GameManager.instance.pos.position)
            {
                clicked = true;
                rastro.enabled = false;
                estouPronto = true;
            }
        }
    }

    void OnMouseUp()
    {
        if (estouPronto)
        {
            pedraRB.isKinematic = false;
            clicked = false;
            rastro.enabled = true;
            GameManager.instance.objetoLancado = true;
            audioObjeto.Play();
        }
    }
}
