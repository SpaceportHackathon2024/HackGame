using UnityEngine;

[CreateAssetMenu(fileName = "CodexEntry", menuName = "Codex/Entry")]
public class CodexEntry : ScriptableObject
{
    public string Title;       // Title of the entry
    [TextArea(5, 10)]
    public string Content;    // Main text or lore
    public Sprite ChapterImage;  // Image representing the chapter
    public bool IsUnlocked;   // Tracks if the entry is unlocked
}
