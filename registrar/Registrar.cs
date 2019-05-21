﻿using Neo.SmartContract.Framework;
using System;
using System.Numerics;
using System.Reflection;
using Neo.SmartContract.Framework.Services.Neo;

[assembly: AssemblyDescription("Sample Smart Contract")]
[assembly: AssemblyMetadata("ContractAuthor", "Harry Pierson")]
[assembly: AssemblyMetadata("ContractEmail", "harrypierson@hotmail.com")]
[assembly: AssemblyMetadata("ContractHasStorage", "true")]

namespace Neo.SmartContract.Framework
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class ContractParameterTypeAttribute : Attribute
    {
        public ContractParameterTypeAttribute(string name)
        {
        }
    }
}

namespace DevHawk.Neo.Experiments
{
    public class Registrar : SmartContract
    {
        public static object Main(string operation, params object[] args)
        {
            switch (operation)
            {
                case "query":
                    return Query((string)args[0]);
                case "register":
                    return Register((string)args[0], (byte[])args[1]);
                case "transfer":
                    return Transfer((string)args[0], (byte[])args[1]);
                case "delete":
                    return Delete((string)args[0]);
                default:
                    return false;
            }
        }

        [return: ContractParameterType("__Hash160")]
        public static byte[] Query(string domain)
        {
            return Storage.Get(Storage.CurrentContext, domain);
        }

        public static bool Register(string domain, [ContractParameterType("__Hash160")] byte[] owner)
        {
            if (!Runtime.CheckWitness(owner)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, domain);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, domain, owner);
            return true;
        }

        public static bool Transfer(string domain, [ContractParameterType("__Hash160")] byte[] to)
        {
            if (!Runtime.CheckWitness(to)) return false;
            byte[] from = Storage.Get(Storage.CurrentContext, domain);
            if (from == null) return false;
            if (!Runtime.CheckWitness(from)) return false;
            Storage.Put(Storage.CurrentContext, domain, to);
            return true;
        }

        public static bool Delete(string domain)
        {
            byte[] owner = Storage.Get(Storage.CurrentContext, domain);
            if (owner == null) return false;
            if (!Runtime.CheckWitness(owner)) return false;
            Storage.Delete(Storage.CurrentContext, domain);
            return true;
        }
    }
}