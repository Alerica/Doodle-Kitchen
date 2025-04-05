using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    [Header("References")]
    public Animator[] panels;
    public Animator tab;
    public Animator iventory;

    private bool tabOpen = false;
    private bool iventoryOpen = false;
    private Animator currentPanel;

    public void SwitchTo(int index)
    {
        if(currentPanel == null)
        {
            currentPanel =  panels[index];
            currentPanel.SetTrigger("Open");
            if(tabOpen) ToggleTab();
        }
        else
        {
            if(currentPanel == panels[index])
            {
                currentPanel.SetTrigger("Close");
                currentPanel = null;
            }
            else
            {
                currentPanel.SetTrigger("Close");
                currentPanel = panels[index];
                currentPanel.SetTrigger("Open");
                if(tabOpen) ToggleTab();
            }
        }
    }

    public void ToggleIventory()
    {
        if(iventoryOpen)
            iventory.SetTrigger("Close");
        else
            iventory.SetTrigger("Open");
        iventoryOpen = !iventoryOpen;
    }

    public void ToggleTab()
    {
        if(tabOpen)
            tab.SetTrigger("Close");
        else
            tab.SetTrigger("Open");
        tabOpen = !tabOpen;
    }
}
