using System.Collections.Generic;
using UnityEngine;

public class AtomicElementManager : MonoBehaviour
{
    public GameObject elementPrefab;          // Prefab for the element UI (created in the scene)
    public Transform gridContainer;           // The parent object to hold the matrix cells
    private List<AtomicElement> allElements = new List<AtomicElement>()
    {
        new AtomicElement { name = "H", atomicNumber = 1, atomicMass = 1.008f},
        new AtomicElement { name = "He", atomicNumber = 2, atomicMass = 4.0026f},
        new AtomicElement { name = "Li", atomicNumber = 3, atomicMass = 6.94f },
        new AtomicElement { name = "Be", atomicNumber = 4, atomicMass = 9.0122f },
        new AtomicElement { name = "B", atomicNumber = 5, atomicMass = 10.81f},
        new AtomicElement { name = "C", atomicNumber = 6, atomicMass = 12.011f},
        new AtomicElement { name = "N", atomicNumber = 7, atomicMass = 14.007f},
        new AtomicElement { name = "O", atomicNumber = 8, atomicMass = 15.999f},
        new AtomicElement { name = "F", atomicNumber = 9, atomicMass = 18.998f},
        new AtomicElement { name = "Ne", atomicNumber = 10, atomicMass = 20.180f},
    };
    public int maxElement;
    public GameObject elementInfoPanel;      // Panel to show element information when hovered

    public int gridSizeX = 5; // Number of columns
    public int gridSizeY = 5; // Number of rows

    void Start()
    {
        //PopulateGrid();
    }

    public void PopulateGrid()
    {
        this.allElements = new List<AtomicElement>(){
            new AtomicElement { name = "H", atomicNumber = 1, atomicMass = 1.008f },
            new AtomicElement { name = "He", atomicNumber = 2, atomicMass = 4.0026f },
            new AtomicElement { name = "Li", atomicNumber = 3, atomicMass = 6.94f },
            new AtomicElement { name = "Be", atomicNumber = 4, atomicMass = 9.0122f },
            new AtomicElement { name = "B", atomicNumber = 5, atomicMass = 10.81f },
            new AtomicElement { name = "C", atomicNumber = 6, atomicMass = 12.011f },
            new AtomicElement { name = "N", atomicNumber = 7, atomicMass = 14.007f },
            new AtomicElement { name = "O", atomicNumber = 8, atomicMass = 15.999f },
            new AtomicElement { name = "F", atomicNumber = 9, atomicMass = 18.998f },
            new AtomicElement { name = "Ne", atomicNumber = 10, atomicMass = 20.180f },
        };
        Debug.Log(gridSizeX * gridSizeY);
        // Randomly populate the grid with elements from the periodic table
        for (int i = 0; i < gridSizeX * gridSizeY-5; i++)
        {
            int randomIndex = Random.Range(0, maxElement); // Pick a random element
            Debug.Log(randomIndex + " " + allElements.Count);
            AtomicElement newElement = Instantiate(elementPrefab, gridContainer).GetComponent<AtomicElement>();
            newElement.elementName = allElements[randomIndex].elementName;
            newElement.atomicNumber = allElements[randomIndex].atomicNumber;
            newElement.atomicMass = allElements[randomIndex].atomicMass;
            //newElement.elementSprite = allElements[randomIndex].elementSprite;
            newElement.elementInfoPanel = elementInfoPanel;
        }
    }
}
