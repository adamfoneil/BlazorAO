using Microsoft.AspNetCore.Components;

namespace BlazorAO.App.Extensions
{
    public static class Markup
    {
        public static MarkupString ToYesNo(bool? value, string yesValue = "Yes", string noValue = "No", string notSetValue = "Not Specified", string className = "")
        {
            string result = (value.HasValue) ?
                ((value.Value) ? yesValue : noValue) :
                notSetValue;

            return new MarkupString($"<span class=\"{className}\">{result}</span>");
        }

        public static MarkupString EvenOdd(int rowIndex, string evenText = "even", string oddText = "odd") => ((rowIndex % 2) == 0) ? 
            new MarkupString(evenText) : 
            new MarkupString(oddText);
    }
}
