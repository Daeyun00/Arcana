using UnityEngine;
using TMPro;        // TextMeshPro a szövegekhez
using UnityEngine.UI; // Image komponens a portrékhoz
using System.Collections;
using System.Collections.Generic;

public class DialogueController : MonoBehaviour {
    [Header("UI Referenciák")]
    public TextMeshProUGUI nameText;       // A beszélő neve (pl. Valentin)
    public TextMeshProUGUI speechText;     // A beszéd szövege
    public Image characterPortrait;        // A karakter feje/portréja
    public GameObject dialoguePanel;       // A teljes UI panel

    RoomController cameraChange;

    public bool finish = false;
    public bool utolso;

    [System.Serializable]
    public class DialogueLine {
        public string characterName;       // Ki beszél?
        public Sprite portrait;            // A karakter képe
        [TextArea(3, 10)]
        public string text;                // Mit mond?
    }

    [Header("Párbeszéd listája")]
    public List<DialogueLine> dialogueLines;

    private int currentIndex = 0;          // Hol tartunk a listában
    private bool isTyping = false;         // Éppen fut-e a gépelés effekt
    private string currentFullText = "";    // Az aktuális teljes mondat tárolása

    void OnEnable() {
        cameraChange = GetComponent<RoomController>();
        // A játék indításakor (vagy amikor a vevő odaér) elindítjuk
        if (dialogueLines.Count > 0) {
            StartDialogue();
        }
    }

    void Update() {
        // Space billentyű figyelése
        if (Input.GetKeyUp(KeyCode.Space)) {
            if (isTyping) {
                // 1. Ha még gépel a gép, a Space-re azonnal írja ki az egészet
                CompleteTextImmediately();
            }
            else {
                // 2. Ha már kész a szöveg, a Space-re jöhet a következő sor
                DisplayNextLine();
            }
        }
    }

    public void StartDialogue() {
        dialoguePanel.SetActive(true);
        currentIndex = 0;
        DisplayNextLine();
    }

    void DisplayNextLine() {
        // Megnézzük, van-e még sor a listában
        if (currentIndex < dialogueLines.Count) {
            DialogueLine line = dialogueLines[currentIndex];

            // Név és Portré beállítása
            nameText.text = line.characterName;

            if (line.portrait != null) {
                characterPortrait.sprite = line.portrait;
                characterPortrait.gameObject.SetActive(true);
            }
            else {
                characterPortrait.gameObject.SetActive(false); // Ha nincs kép, eltüntetjük a keretet
            }

            // Szöveg kiírása (gépeléssel)
            currentFullText = line.text;
            StopAllCoroutines();
            StartCoroutine(TypeText(currentFullText));

            currentIndex++;
        }
        else {
            // Ha elfogytak a sorok
            EndDialogue();


        }
    }

    IEnumerator TypeText(string line) {
        isTyping = true;
        speechText.text = "";

        foreach (char c in line.ToCharArray()) {
            speechText.text += c;
            yield return new WaitForSeconds(0.03f); // Gépelés sebessége
        }

        isTyping = false;
    }

    void CompleteTextImmediately() {
        StopAllCoroutines();
        speechText.text = currentFullText;
        isTyping = false;
    }

    void EndDialogue() {
        dialoguePanel.SetActive(false);
        Debug.Log("Párbeszéd vége! Kezdődhet a munka.");
        this.enabled = false;
        if (!utolso) {
            cameraChange.Camera_to_Prep_room();
        }
        finish = true;
        
    }
}