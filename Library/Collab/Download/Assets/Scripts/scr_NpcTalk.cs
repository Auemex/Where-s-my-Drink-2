using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_NpcTalk : MonoBehaviour
{
    [SerializeField]
    GameObject npc;
    RaycastHit  hit;
    float distance = 6f;
    public Text dialogText;
    public Text blobfishCaughtText;
    public GameObject uiCanvasItems;
    public GameObject dialogCanvas;
    public Button ok_Button;

    public int dialogtransition;

    public int blobFishCaught;


    // Start is called before the first frame update
    void Start()
    {
        SetCountText(0);
        //SetDialogText();
        dialogtransition = 1;
        uiCanvasItems.SetActive(false);
        blobFishCaught = 0;
        Button okButton = ok_Button.GetComponent<Button>();
        okButton.onClick.AddListener(OkButton);
        dialogCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, LayerMask.GetMask("Npc")))
            {
            //Debug.Log("you have talked to npc");
            //scr_NpcInteract shop = hit.collider.GetComponent<scr_NpcInteract>();
            dialogCanvas.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            Debug.Log(Cursor.lockState);
            Debug.Log (Time.timeScale);
            }
        }
        /*if (blobFishCaught >= 4 && dialogtransition == 1)
            {
                dialogtransition = 2;
            }
        if (blobFishCaught >= 4 && dialogtransition == 2)
        {
            dialogtransition = 3;
        }
        */
    }

    public void SetCountText(int anumber)
    {
        blobFishCaught = blobFishCaught + anumber;
        blobfishCaughtText.text = "Blobfish Caught: " + blobFishCaught.ToString();
        //dialogtransition = dialogtransition + 1;
    }

        void OkButton()
    {
        if (dialogtransition == 1)
        {
            dialogText.text = "Benji boy, how are ya? Can you do me a favor? I need you to catch me five Blobfish and bring them to me. If you do I'll give you these 3 cool items for your house.";
            dialogtransition = dialogtransition +1;
        }
        if (dialogtransition == 2)
        {
            dialogText.text = "That's great, bring me back those jellyfish";
            if (blobFishCaught >= 4)
            {
                dialogtransition = dialogtransition + 1;
            }
        }
        if (dialogtransition == 3)
        {
            dialogText.text = "Oh you got them? Thank you! here is the 3 items like you wanted.";
            dialogtransition = dialogtransition +1;
        }
        if (dialogtransition == 4)
        {
            dialogText.text = "Your house looks great now.";
            UnityEngine.SceneManagement.SceneManager.LoadScene("S_Win");
        }
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        dialogCanvas.SetActive(false);
        Debug.Log("You have clicked the ok Button");
        //dialogtransition = dialogtransition +1;
        //SetDialogText();
        
    }
}
