using Microsoft.JSInterop;
using System.Text.Json;
namespace Web.Helpers
{
    public class LocalStorageHelpers
    {
        private readonly IJSRuntime _jSRuntime;
        private readonly string _jSStorage = "pelisYaLocalStorage.";

        public LocalStorageHelpers(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;            
        }

        public async Task<string> GetValue(string localVar)
        {
            var result = "";

            result = await _jSRuntime.InvokeAsync<string>($"{_jSStorage}getItem", localVar).ConfigureAwait(false);

            return result;
        }

        public async Task SetValue(string localVar, string localValue) 
        {
            
            await _jSRuntime.InvokeAsync<string>(
                $"{_jSStorage}setItem",
                 localVar,
                 JsonSerializer.Serialize(localValue)
                ).ConfigureAwait(false);
        }

        public async Task ClearAll()
        {
            await _jSRuntime.InvokeVoidAsync($"{_jSStorage}clear").ConfigureAwait(false);
        }
    }
}
