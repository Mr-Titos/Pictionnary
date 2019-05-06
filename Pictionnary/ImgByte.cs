using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Pictionnary
{
    public static class ImgByte
    {
        public static byte[] ToByteArray(this Image imageIn)
        {
            var myArray = (byte[])new ImageConverter().ConvertTo(imageIn, typeof(byte[]));
            return myArray;
        }

        public static Image ToImage(this byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
