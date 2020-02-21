using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorForum.Pages.Components.BlazorModal
{
    public class BlazorModalParameter
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        private BlazorModalParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public static BlazorModalParameter Get(string name, object value)
        {
            return new BlazorModalParameter(name, value);
        }
    }
}
