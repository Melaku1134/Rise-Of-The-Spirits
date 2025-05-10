using UnityEngine;
using TMPro;

public class DialogueManagerLevels : MonoBehaviour
{
    // strings -> matches level/scene name
    // string == SceneManager.GetActiveScene().name;
    
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public int currentLevel = 1; // Set in Inspector or dynamically

    private int dialogueIndex = 0;
    private string[] currentDialogue;
    private bool isDialogueActive = true;

    private string[][] levelDialogues = new string[4][];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Friend")
        {
            dialoguePanel.SetActive(true);
            isDialogueActive=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Friend")
        {
            dialoguePanel.SetActive(false);
            isDialogueActive=false;
        }
    }

    void Start()
    {
        SetupDialogues();
        currentDialogue = levelDialogues[currentLevel - 1];
        dialoguePanel.SetActive(false);
        DisplayNextLine();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive)
        {
            DisplayNextLine();
        }
    }

    void DisplayNextLine()
    {
        if (dialogueIndex < currentDialogue.Length)
        {
            dialogueText.text = currentDialogue[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        Debug.Log("Dialogue finished for Level " + currentLevel);
        // Trigger gameplay events here (enable controls, start enemies, etc.)
    }

    void SetupDialogues()
    {
        levelDialogues[0] = new string[]
        {
            // LEVEL 1: Introduction
            "Yumi: ¿Dónde estoy...? Esto no es mi mundo. // Where am I...? This isn’t my world.",
            "Kiro: Despierta, Yumi. Los espíritus te han elegido. // Wake up, Yumi. The spirits have chosen you.",
            "Kiro: El equilibrio entre los mundos está roto. Debes restaurarlo. // The balance between worlds is broken. You must restore it.",
            "[Tutorial] Usa las teclas de movimiento para avanzar. // Use movement keys to move forward.",
            "[Tutorial] Salta con 'Espacio'. // Jump with 'Space'."
        };

        levelDialogues[1] = new string[]
        {
            // LEVEL 2: Combat Intro
            "Yumi: Esos... ¿son sombras? ¡Están vivas! // Those... shadows? They’re alive!",
            "Kiro: Son almas corrompidas por Lilith. No mostrarán piedad. // They’re souls corrupted by Lilith. They’ll show no mercy.",
            "[Tutorial] Pulsa 'X' para disparar tu arma espiritual. // Press 'X' to shoot your spirit weapon.",
            "[Tutorial] Mantén la distancia y elimina las sombras. // Keep your distance and eliminate the shadows.",
            "Kiro: Bien hecho. Eres más fuerte de lo que crees. // Well done. You're stronger than you think."
        };

        levelDialogues[2] = new string[]
        {
            // LEVEL 3: Platforming & Puzzle Intro
            "Kiro: Algunos caminos están rotos. Debes encontrar otra manera. // Some paths are broken. You must find another way.",
            "[Tutorial] Usa el doble salto para alcanzar áreas más altas. // Use double jump to reach higher areas.",
            "[Tutorial] Pulsa 'E' para hacer dash a través de huecos. // Press 'E' to dash across gaps.",
            "Kiro: Estas habilidades te servirán en todos los reinos. // These abilities will serve you in all realms.",
            "Yumi: Empiezo a entender lo que se necesita. // I’m starting to understand what it takes."
        };

        levelDialogues[3] = new string[]
        {
            // LEVEL 4: Midpoint – First Soul Shard
            "Yumi: Esta aldea... algo terrible ocurrió aquí. // This village... something terrible happened here.",
            "Kiro: Este fue un lugar sagrado. Ahora, es un portal entre mundos. // This was a sacred place. Now, it’s a portal between worlds.",
            "Kiro: Las Sombras se han hecho fuertes. Pero tú también puedes serlo. // The Shadows have grown strong. But so can you.",
            "[Tutorial] Prepárate para combatir mientras te mueves. // Prepare to fight while platforming.",
            "[Combat] Dispara mientras saltas y esquiva para sobrevivir. // Shoot while jumping and dodge to survive.",
            "Kiro: Hay una presencia poderosa aquí... un guardián corrompido. // A powerful presence is here... a corrupted guardian.",
            "[Boss Battle] Enfrenta al Espíritu Corrupto. No te detengas. // Face the Corrupted Spirit. Don’t hold back.",
            "Yumi: Ha terminado... pero fue solo el comienzo. // It’s over... but this was just the beginning.",
            "Kiro: Has ganado tu primer Fragmento del Alma: Fuego. // You've earned your first Soul Shard: Fire.",
            "[Unlock] Pulsa 'R' para lanzar una explosión ígnea. // Press 'R' to launch a fire blast.",
            "Kiro: El Reino del Fuego será tu próxima prueba. Prepárate. // The Fire Realm is your next trial. Prepare yourself."
        };
    }
}

