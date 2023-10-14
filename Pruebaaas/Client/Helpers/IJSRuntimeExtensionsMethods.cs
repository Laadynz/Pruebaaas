using Microsoft.JSInterop;

namespace Pruebaaas.Client.Helpers
{
    public static class IJSRuntimeExtensionsMethods
    {
        public static ValueTask<object> GuardarEnLocalStorage(this IJSRuntime js, string llave, string contenido)
        {
            return js.InvokeAsync<object>("localStorage.SetItem", llave, contenido);
        }
        public static ValueTask<object> ObtenerDelLocalStorage(this IJSRuntime js, string llave)
        {
            return js.InvokeAsync<object>("localStorage.GetItem", llave);
        }

        public static ValueTask<object> RemoverDelLocalStorage(this IJSRuntime js, string llave)
        {
            return js.InvokeAsync<object>("localStorage.RemoveItem", llave);
        }

    }
}
