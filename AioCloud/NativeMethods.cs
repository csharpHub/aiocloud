using System.Runtime.InteropServices;

namespace AioCloud
{
    public static class NativeMethods
    {
        public enum NameList : int
        {
            TYPE_TCPHost,
            TYPE_TCPPort,
            TYPE_TCPPass,
            TYPE_TCPMeth,

            TYPE_UDPHost,
            TYPE_UDPPort,
            TYPE_UDPPass,
            TYPE_UDPMeth
        }

        [DllImport("Redirector.bin", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool aio_init();

        [DllImport("Redirector.bin", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool aio_dial(
            NameList name,
            [MarshalAs(UnmanagedType.LPStr)] string value
        );

        [DllImport("Redirector.bin", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool aio_load();

        [DllImport("Redirector.bin", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool aio_free();
    }
}
