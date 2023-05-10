using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileChunker
{
    public interface IByteChunker
    {
        IEnumerable<byte[]> GetChunkedBytes(byte[] inputBytes,int sizeOfEachChunk); 
    }
}
