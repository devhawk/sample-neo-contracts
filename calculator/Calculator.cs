using Neo.SmartContract.Framework;
using System;
using System.Numerics;
using System.Reflection;

[assembly: AssemblyDescription("Sample Smart Contract")]
[assembly: AssemblyMetadata("ContractAuthor", "Harry Pierson")]
[assembly: AssemblyMetadata("ContractEmail", "harrypierson@hotmail.com")]

namespace DevHawk.Neo.Experiments
{
    public class Calculator : SmartContract
    {
        public static object Main(string operation, object[] args)
        {
            switch (operation)
            {
                case "Add":
                    return Add((BigInteger)args[0], (BigInteger)args[1]);
                case "Subtract":
                    return Subtract((BigInteger)args[0], (BigInteger)args[1]);
                default:
                    return false;
            }
        }

        public static BigInteger Add(BigInteger lhs, BigInteger rhs)
        {
            return lhs + rhs;
        }

        public static BigInteger Subtract(BigInteger lhs, BigInteger rhs)
        {
            return lhs - rhs;
        }
    }
}
