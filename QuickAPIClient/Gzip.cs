using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Ctrip.Flight.TradeCommon.Utility
{
    public static class Gzip
    {
        public static MemoryStream Compress(Stream input)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream stream = new GZipStream(ms, CompressionMode.Compress);
            input.CopyTo(stream);
            stream.Close();

            return ms;
        }

        public static MemoryStream Compress(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream stream = new GZipStream(ms, CompressionMode.Compress);
            stream.Write(data, 0, data.Length);
            stream.Close();

            return ms;
        }

        public static MemoryStream Decompress(Stream input)
        {
            int length = 65536;
            
            if (input.CanSeek)
            {
                //流可定位 取出压缩流长度 Gzip最后4位
                input.Position = input.Length - 4;
                byte[] bytes = new byte[4];
                input.Read(bytes, 0, 4);
                length = BitConverter.ToInt32(bytes, 0);
                input.Position = 0;
            }
            else
            {
                //如果输入流有Length 长度为Length * 30 因为压缩率为3%
                try { length = (int)input.Length * 20; }
                catch { length = 65536; }
            }


            using (GZipStream compressedzipStream = new GZipStream(input, CompressionMode.Decompress))
            {
                MemoryStream ms = new MemoryStream(length);
                byte[] block = new byte[65536];

                int byteRead = 0;
                do
                {
                    byteRead = compressedzipStream.Read(block, 0, block.Length);
                    ms.Write(block, 0, byteRead);
                }
                while (byteRead == block.Length);

                ms.Position = 0;
                return ms;
            }

            //int bytesRead = compressedzipStream.Read(block, 0, block.Length);
            //if (bytesRead > 0)
            //    ms.Write(block, 0, bytesRead);

            //while (true)
            //{
            //    bytesRead = compressedzipStream.Read(block, 0, block.Length);
            //    if (bytesRead <= 0)
            //        break;
            //    else
            //        ms.Write(block, 0, bytesRead);
            //}
            //compressedzipStream.Close();

        }

        public static MemoryStream Decompress(byte[] buffer)
        {
            MemoryStream input = new MemoryStream(buffer);

            return Decompress(input);
        }
    }
}
