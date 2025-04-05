using UnityEngine;

public class TabManager : MonoBehaviour
{
    public Animator[] panels;
    private Animator currentPanel;

    public void SwitchTo(int index)
    {
        if(currentPanel == null)
        {
            currentPanel =  panels[index];
            currentPanel.SetTrigger("Open");
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
            }
        }
    }
}
