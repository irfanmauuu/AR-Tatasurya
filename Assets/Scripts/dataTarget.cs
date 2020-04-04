using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class dataTarget : MonoBehaviour
    {

        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform ButtonAction;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
		//add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

//Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                TextTargetName.GetComponent<Text>().text = name;
                ButtonAction.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);


//If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the zombie

                if(name == "bumi"){
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/bumi"); });
                    TextDescription.GetComponent<Text>().text = "Planet ketiga adalah Bumi yang sering disebut sebagai Planet Biru, bumi merupakan planet dimana kita tinggal. Sebagian besar Bumi ditutupi oleh lautan, sehingga nampak biru. Bumi diselimuti oleh udara tebal yang disebut atmosfer. Fungsi dari atmosfer untuk menyaring panas dari Matahari sehingga tidak terbakar.";
                }



//If the target name was “unitychan” then add listener to ButtonAction with location of the unitychan sound (locate in Resources/sounds folder) and set text on TextDescription a description of the unitychan / robot

                if (name == "venus")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/venus"); });
                    TextDescription.GetComponent<Text>().text = "Planet kedua yaitu venus, Venus merupakan planet terdekat dari Bumi. Venus lebih panas dibanding Merkurius yang lebih dekat dengan Matahari. Hal ini terjadi karena Planet Venus memiliki lapisan atmosfer tebal yang dilapisi awan. Venus melakukan rotasi dengan arah yang berlawanan dengan rotasi planet-planet lainnya. Venus berotasi searah dengan jarum jam. Satu hari di Venus sama dengan 243 hari di Bumi.";
                }

                if (name == "merkurius")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/merkurius"); });
                    TextDescription.GetComponent<Text>().text = "Planet pertama adalah Merkurius, merkurius merupakan planet terdekat dari matahari yang  berjarak 58jt km, Merkurius sulit terlihat di langit pada malam hari jika dilihat dari Bumi. Markurius baru terlihat setelah Matahari terbenam, atau sebelum Matahari terbit. Keunikan dari Merkurius adalah melesat cepat mengelilingi Matahari, tetapi berotasi sangat lambat. Satu hari di Merkurius sama dengan 30 hari di Bumi.";
                }

                if (name == "mars")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/mars"); });
                    TextDescription.GetComponent<Text>().text = "Planet ke empat  adalah Mars. Mars dijuluki sebagai Planet Merah.  Planet ini disebut paling menyerupai Bumi. Satu hari di Mars sama dengan 24,6 jam di Bumi.  Ia juga memiliki kutub yang diselimuti es.  Suhu udara di Mars lebih dingin daripada suhu di Bumi, yaitu sekitar   - 63 derajat Celsius,  karena letak Mars yang lebih jauh dari Matahari dibanding Bumi.  Mars juga memiliki lapisan atmosfer, namun lebih tipis dibanding Bumi.";
                }

                if (name == "jupiter")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/jupiter"); });
                    TextDescription.GetComponent<Text>().text = "Planet kelima adalah planet Jupiter. Jupiter adalah planet terbesar di dalam tata surya. Suhu di planet ini pun sangat rendah, mencapai kurang lebih - 100 derajat Celsius. Planet Jupiter merupakan planet yang sebagian besar terdiri atas gas. Letak inti planetnya pun jauh di tengah. Planet ini memiliki bintik merah yang ternyata merupakan badai raksasa.";
                }

                if (name == "saturnus")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/saturnus"); });
                    TextDescription.GetComponent<Text>().text = "Planet keenam dalam sistem tata surya adalah planet Saturnus. Saturnus terlihat memiliki cincin yang melingkari tubuhnya. Cincin tersebut terdiri atas lingkaran bebatuan, debu, dan es yang terperangkap dalam orbit mengelilingi planet tersebut.";
                }

                if (name == "uranus")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/uranus"); });
                    TextDescription.GetComponent<Text>().text = "Planet Uranus merupakan planet ketujuh dalam sistem tata surya. Planet Uranus berputar miring karena porosnya yang hampir sejajar dengan orbitnya.  Suhu planet ini sangat dingin, yaitu sekitar minus 212 derajat Celsius.";
                }

                if (name == "neptunus")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/neptunus"); });
                    TextDescription.GetComponent<Text>().text = "Planet yang berada di urutan paling jauh dari Matahari adalah planet Neptunus. Planet ini tampak berwarna biru gelap dari kejauhan dan tidak memiliki permukaan yang nyata. Sama halnya dengan Jupiter, Saturnus, dan Uranus, planet ini juga terdiri atas gumpalan gas.";
                }

                if (name == "matahari")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/matahari"); });
                    TextDescription.GetComponent<Text>().text = "Matahari adalah sebuah bintang raksasa yang sangat panas seperti bola pijar. Matahari merupakan pusat tata surya  yang dikelilingi benda langit lainnya. Suhu di permukaannya hampir 6000 derajat Celsius. Suhu inti Matahari mencapai 15.000.000 derajat Celsius. Percikan panasnya dapat membakar segala sesuatu hingga 97 kilometer.  Namun, Matahari hanya tergolong bintang sedang. Masih banyak bintang besar yang jauh lebih besar dan lebih panas dari matahari.";
                }
            }
        }

//function to play sound
        void playSound(string ss){
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }
    }
}
