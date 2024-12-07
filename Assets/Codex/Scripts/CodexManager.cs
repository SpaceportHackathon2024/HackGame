using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

public class CodexManager : MonoBehaviour
{
    public Transform chapterListParent;  // Parent for the chapter buttons in the ScrollView
    public GameObject chapterButtonPrefab;  // Prefab for the chapter buttons
    public Image chapterImage;           // Image for the selected chapter
    public Text chapterDescription;      // Description for the selected chapter

    public List<CodexEntry> allChapters;    // List of all chapters in the Codex

    public GameObject codexMenu;  // Reference to the Codex menu (the panel)

    void Start()
    {
        PopulateChapterList();  // Populate the list of chapters on start
        DeactivateCodexMenu();
    }

    public void OpenPanel(Animator? anim)
    {
        /*if (m_Open == anim)
            return;

        anim.gameObject.SetActive(true);
        var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;

        anim.transform.SetAsLastSibling();

        CloseCurrent();

        m_PreviouslySelected = newPreviouslySelected;

        m_Open = anim;
        m_Open.SetBool(m_OpenParameterId, true);

        GameObject go = FindFirstEnabledSelectable(anim.gameObject);*/

        SetSelected(codexMenu);
    }
    public void PopulateChapterList()
    {
        // Clear any existing buttons
        foreach (Transform child in chapterListParent)
        {
            Destroy(child.gameObject);
        }

        // Create a button for each unlocked chapter
        foreach (var chapter in allChapters)
        {
            if (chapter.IsUnlocked)
            {
                GameObject newButton = Instantiate(chapterButtonPrefab, chapterListParent);
                var text = newButton.GetComponentInChildren<TextMeshProUGUI>();
                if (text != null)
                {
                    text.text = chapter.Title;
                }

                // Add a listener to handle chapter selection
                newButton.GetComponent<Button>().onClick.AddListener(() => DisplayChapter(chapter));
            }
        }
    }

    public void DisplayChapter(CodexEntry chapter)
    {
        // Update the detail area with the selected chapter's info
        chapterImage.sprite = chapter.ChapterImage;
        chapterImage.gameObject.SetActive(chapter.ChapterImage != null);  // Hide if no image
        chapterDescription.text = chapter.Content;
    }

    public void UnlockChapter(CodexEntry chapter)
    {
        chapter.IsUnlocked = true;
        PopulateChapterList();  // Refresh the list when a chapter is unlocked
    }

    // Method to toggle the Codex menu
    public void ToggleCodexMenu()
    {
        PopulateChapterList();
        // Check if the Codex menu is currently active and toggle it
        bool isActive = codexMenu.activeSelf;
        codexMenu.SetActive(!isActive);  // If active, deactivate; if inactive, activate
    }
    public void DeactivateCodexMenu()
    {
        codexMenu.SetActive(false);
    }

    private void SetSelected(GameObject go)
    {
        EventSystem.current.SetSelectedGameObject(go);
    }
}
