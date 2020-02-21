using System;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace BlazorForum.Pages.Components.BlazorModal
{
    public class BlazorModalService : IBlazorModal
    {
        public event Action<string, RenderFragment> OnShow;

        public event Action OnClose;

        public void Show<T>(string title, params BlazorModalParameter[] parameters) where T : ComponentBase
        {
            var content = new RenderFragment(x =>
            {
                var idx = 1;
                x.OpenComponent(idx++, typeof(T));
                if (parameters != null && parameters.Any())
                {
                    foreach (var param in parameters)
                    {
                        x.AddAttribute(idx++, param.Name, param.Value);
                    }
                }
                x.CloseComponent();
            });

            OnShow?.Invoke(title, content);
        }

        public void Close()
        {
            OnClose?.Invoke();
        }
    }
}
