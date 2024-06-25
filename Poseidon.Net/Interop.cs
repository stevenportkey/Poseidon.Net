using System;
using System.Runtime.InteropServices;

namespace Poseidon.Net
{
    public unsafe delegate int poseidon_hash(byte* input, byte* buf, int max_len);

    /// <summary>
    /// Type for error and illegal callback functions,
    /// </summary>
    /// <param name="message">message: error message.</param>
    /// <param name="data">data: callback marker, it is set by user together with callback.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void ErrorCallbackDelegate(string message, void* data);
}