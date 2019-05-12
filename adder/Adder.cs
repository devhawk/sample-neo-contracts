using Neo.SmartContract.Framework;
using System;
using System.Numerics;
using System.Reflection;

[assembly: AssemblyDescription("Sample Smart Contract")]
[assembly: AssemblyMetadata("ContractAuthor", "Harry Pierson")]
[assembly: AssemblyMetadata("ContractEmail", "harrypierson@hotmail.com")]

namespace DevHawk.Neo.Experiments
{
    public class Adder : SmartContract
    {
        public static BigInteger Main(BigInteger lhs, BigInteger rhs)
        {
            return lhs + rhs;
        }
    }
}
