using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

  public void GoToARCamera(){
      Application.LoadLevel("arcamera");
  }
  public void GoTomainmenu(){
      Application.LoadLevel("mainmenu");

}
}
