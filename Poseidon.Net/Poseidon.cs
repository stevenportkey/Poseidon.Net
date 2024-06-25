using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Poseidon.Net
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }

    public unsafe class Poseidon : PoseidonBase
    {
        static readonly Lazy<poseidon_hash> poseidon_hash
            = PoseidonBase.LazyDelegate<poseidon_hash>(nameof(poseidon_hash));

        public string Hash(IList<string> input)
        {
            if (input.Any(string.IsNullOrEmpty))
            {
                throw new InvalidInputException("input must not contain empty strings");
            }

            if (!input.All(IsValidNumber))
            {
                throw new InvalidInputException("input must be a list of numbers");
            }

            var buffer = new byte[100];
            var inputString = input.ToJsonString();
            Span<byte> inputInBytes = Encoding.ASCII.GetBytes(inputString);
            Span<byte> output = buffer;
            var returnedBytes = 0;

            fixed (byte* inputPtr = &MemoryMarshal.GetReference(inputInBytes),
                   buffPtr = &MemoryMarshal.GetReference(output))
            {
                returnedBytes = poseidon_hash.Value(inputPtr, buffPtr, buffer.Length);
            }

            if (returnedBytes < 0) throw new Exception($"failed with code {returnedBytes}");

            var charArray = Encoding.UTF8.GetChars(buffer.TakeWhile(v => v != 0).ToArray());
            return new string(charArray);
        }

        private static bool IsValidNumber(string number)
        {
            return number.All(char.IsDigit);
        }
    }
}