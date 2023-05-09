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
        IEnumerable<byte[]> ChunkeBytes(byte[] inputBytes,int sizeOfEachChunk); 
    }
}
