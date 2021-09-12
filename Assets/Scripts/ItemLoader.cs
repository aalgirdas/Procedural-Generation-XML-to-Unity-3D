using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemLoader : MonoBehaviour {

    public const string path = "items_files/items";
    ///public   string path2 ;
    public string path3;


    private float fireRate = 0.050f;
    private float nextFire = 0.0f;


    private ItemContainer ic;

    public Text m_MessageText;
    public Text m_MessageVerb;
    public Text m_MessageFrame;


    // Use this for initialization
    void Start () 
    {


        m_MessageText.text = "";



        //path2 = System.IO.Path.Combine(Application.dataPath, "Resources/items2.xml");

        ic = ItemContainer.Load(path);

        ////    ItemContainer ic = new ItemContainer(path);
        ////  ic = ic.Load(path);


        //////    ItemContainer.Load(path);

        ///load_item_if_time();


        //GameObject plane_2 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //plane_2.transform.position = new Vector3(0, 6.5F, 0);



        path3 = System.IO.Path.Combine(Application.dataPath, "Resources/items_saved2.xml");
        ItemContainer.Save(path3, ic);

    }




    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //Instantiate(projectile, transform.position, transform.rotation);
            //Debug.Log("Hello: " + nextFire+ "    "+ fireRate);
            load_item_if_time();
            load_verb_if_time();
            load_action_if_time();
        }
    }






    void load_action_if_time()
    {

        foreach (Item item in ic.items)
        {

            if (item.item_type == null)
            {
                continue;
            }

            if (item.item_type != "show_action")
            {
                continue;
            }

            if (item.fTimeToShow < 0)
            {
                continue;
            }

            if (item.fTimeToShow > Time.time)
            {
                continue;
            }


            if (item.fTimeToStop < Time.time)
            {
                continue;
            }

            


            GameObject gameobject_tmp = GameObject.Find(item.name);


            if (gameobject_tmp == null)
            {
                continue;

            }


            //gameobject_tmp.transform.position = new Vector3(0.75f, 0.0f, 0.0f);

            if (item.sVerbType == "InMotion")
            {
                gameobject_tmp.transform.Rotate(0.0f, 10.0f, 0.0f, Space.Self); // Space.Self Space.World
                //m_MessageText.text = "dddddddddddddddxxxxxxxxxxxxxxxxxxxxxxxx"; // 

            }

            if (item.sVerbType == "Motion" && item.fSpeed>0)
            {
                //m_MessageText.text = ""+ item.fTargetX; // 

                // Moves the object to target position
                float speed = item.fSpeed;
                float step = speed * fireRate; // calculate distance to move
                Vector3 target = new Vector3(item.fTargetX, item.fTargetY, item.fTargetZ);
                //gameobject_tmp.transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);



                if (Vector3.Distance(gameobject_tmp.transform.position, target) > 0.1f)
                {
                    gameobject_tmp.transform.position = Vector3.MoveTowards(gameobject_tmp.transform.position, target, fireRate * speed);
                }


                //gameobject_tmp.transform.position = target;

                //gameobject_tmp.transform.position += new Vector3(1 , 0, 0);


            }


        }

    }











    void load_verb_if_time()
    {

        foreach (Item item in ic.items)
        {

            if (item.item_type == null)
            {
                continue;
            }

            if (item.item_type != "show_verb")
            {
                continue;
            }

            if (item.fTimeToShow < 0)
            {
                continue;
            }

            if (item.fTimeToShow > Time.time)
            {
                continue;
            }

            if (item.sVerb != null)
                m_MessageVerb.text = item.sVerb+":"+ item.sVerbType; // 

            if (item.sFrameInfo != null)
                m_MessageFrame.text = item.sFrameInfo; // 

            


        }

    }


    void load_item_if_time()
    {

        foreach (Item item in ic.items)
        {
            //            print(item.name);
            //            print(item.fScaleX);
            //            print(item.sType);
            //            print(item.fTimeToShow);





            if (item.fTimeToShow < 0)
            {
                continue;
            }

            if (item.fTimeToShow > Time.time)
            {
                continue;
            }


            if (item.sCanvasText != null)
            {
                m_MessageText.text = item.sCanvasText; // 
            }


            if (GameObject.Find(item.name) != null || item.name == null)
            {
                continue;
            }



            GameObject gameobject_tmp = null; 

            


            if (item.sType != null)
            {
                if (item.sType.Equals("Cube"))
                    gameobject_tmp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (item.sType.Equals("Sphere"))
                    gameobject_tmp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                if (item.sType.Equals("Cylinder"))
                    gameobject_tmp = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                if (item.sType.Equals("Capsule"))
                    gameobject_tmp = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                if (item.sType.Equals("Human"))
                    gameobject_tmp = Instantiate(Resources.Load("" + "Human")) as GameObject;
            }



            if (gameobject_tmp == null)
            {
                continue;
            }









            //TextMesh textMeshComponent = theText.GetComponent<TextMesh>();
            //textMeshComponent.fontSize = 10;


            gameobject_tmp.name = item.name;
            gameobject_tmp.transform.position = new Vector3(item.fPozX, item.fPozY, item.fPozZ);
            gameobject_tmp.transform.rotation = Quaternion.Euler(item.fRotX, item.fRotY, item.fRotZ);
            gameobject_tmp.AddComponent<Rigidbody>();
            Rigidbody rb = gameobject_tmp.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(item.fVelocityX, item.fVelocityY, item.fVelocityZ);
            rb.AddForce(new Vector3(item.fForceX, item.fForceY, item.fForceZ));
            rb.mass = item.fMass; //  0.1F

            gameobject_tmp.transform.localScale = new Vector3(item.fScaleX, item.fScaleY, item.fScaleZ);

            Color cObjectColor = new Color(Random.value, Random.value, Random.value);

            gameobject_tmp.GetComponent<Renderer>().material.color = cObjectColor;// .renderer.material.color = new Color(0.5f, 1, 1);




            GameObject theText = new GameObject();
            var textMesh = theText.AddComponent<TextMesh>();
            textMesh.color = cObjectColor; // new Color(100, 0, 0);
            ////textMesh.alignment = TextAlignment.Center;
            //textMesh.fontSize = 5;
            MeshRenderer meshRenderer = theText.AddComponent<MeshRenderer>();
            textMesh.text = item.name;
            theText.transform.parent = gameobject_tmp.transform;

            theText.transform.position = new Vector3(gameobject_tmp.transform.position.x, gameobject_tmp.transform.position.y, gameobject_tmp.transform.position.z);

            //aaa = theText.transform.position.z;


        }



    }
}
