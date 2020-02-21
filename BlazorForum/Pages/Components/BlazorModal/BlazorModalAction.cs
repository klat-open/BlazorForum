using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorForum.Pages.Components.BlazorModal
{
    public class BlazorModalAction
    {
        public string DisplayName { get; private set; }
        public Action OnClick { get; private set; }
        public static BlazorModalAction Get(string displayName, Action onClick) => new BlazorModalAction(displayName, onClick);
        public static BlazorModalAction GetClose() => new BlazorModalAction("Close", null);

        private BlazorModalAction(string displayName, Action onClick)
        {
            DisplayName = displayName;
            OnClick = onClick;
        }
    }
}
