using UnityEngine;

namespace GameREFACTOR.Views.UI.ToolTips
{
    public interface ITooltipContent
    {
        string GetDescriptionText();
        string GetActionText(MonoBehaviour context = null);
    }
}