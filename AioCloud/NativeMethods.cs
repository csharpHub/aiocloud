using System.Runtime.InteropServices;

namespace AioCloud
{
    public static class NativeMethods
    {
        public enum NameList : int
        {
            TYPE_TCPHOST,
            TYPE_TCPPORT,
            TYPE_TCPPASS,
            TYPE_TCPCIPH,

            TYPE_UDPHOST,
            TYPE_UDPPORT,
            TYPE_UDPPASS,
            TYPE_UDPCIPH,

            TYPE_ADDNAME,
            TYPE_CLRNAME
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
