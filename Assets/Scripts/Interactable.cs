/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Base class for defining interactable objects in the game world. Provides a default interaction text.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [TextArea]
    public string interactionText = "Press E to interact"; // Default interaction text
}
