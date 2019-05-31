using Neo.SmartContract.Framework;
using System.Reflection;

[assembly: AssemblyDescription("Sample Smart Contract")]
[assembly: AssemblyMetadata("ContractAuthor", "Harry Pierson")]
[assembly: AssemblyMetadata("ContractEmail", "harrypierson@hotmail.com")]

namespace NegatorContract
{
    public class Negator : SmartContract
    {
        public static bool Main(bool value)
        {
            return !value;
        }
    }
}