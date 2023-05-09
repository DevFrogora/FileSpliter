using System;
using System.Collections.Generic;
using System.Linq;

namespace FileChunker
{
    public class ByteChunker : IByteChunker
    {
        public IEnumerable<byte[]> ChunkeBytes(byte[] inputBytes, int sizeOfEachChunk)
        {
            return inputBytes.Chunk(sizeOfEachChunk);
        }
    }
}
