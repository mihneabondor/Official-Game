using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    // Start is called before the first frame update

    public npc n_other;
    int index_a = 0;
    int index_p = 0;

    public Text dialogue_Text;
    bool player_talks = false;

    // Update is called once per frame
    void Update() {
        Movement(0.1f);
        nextLine();
    }

    void nextLine() {
        if(Input.GetKeyDown(KeyCode.E)) {
            switch(player_talks) {
                case false:
                    AI_Talk();
                    index_a++;
                    player_talks = true;
                break;

                case true:
                    Player_Talk();
                    index_p++;
                    player_talks = false;
                break;
            }

        }
    }

    void Movement(float speedMultiplier) {
        float v_input = Input.GetAxis("Vertical");
        float h_input = Input.GetAxis("Horizontal");

        Vector3 v_move = Vector3.up * v_input;
        Vector3 h_move = Vector3.right * h_input;

        this.transform.position += Vector3.ClampMagnitude((v_move + h_move) , 1) * speedMultiplier;
    }

    void Player_Talk() {
        if(n_other != null) {
            
            if(n_other.playerDialogue.Length > index_p) {
                Debug.Log(n_other.playerName +": " + n_other.playerDialogue[index_p]);
                dialogue_Text.text = n_other.playerName +": " + n_other.playerDialogue[index_p];
            }
        }
    }

    void AI_Talk() {
        if(n_other != null) {
            if(n_other.dialogue.Length > index_a) {
                Debug.Log(n_other.aiName +": " + n_other.dialogue[index_a]);
                dialogue_Text.text = n_other.aiName + ": " + n_other.dialogue[index_a];
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "ai") {
            n_other = col.GetComponent<npc>();
        }
        index_a = 0;
        index_p = 0;
    }

    void OnTriggerExit2D(Collider2D col) {
        if(col.tag == "ai") {
            n_other = null;
        }
        index_a = 0;
        index_p = 0;
    }
}
