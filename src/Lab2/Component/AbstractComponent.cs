using System;
using System.Security.Cryptography;
using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public abstract class AbstractComponent : ISellable
{
    public string GetConfig()
    {
        return Convert.ToHexString(SHA256.HashData(Encoding.ASCII.GetBytes(CountConfig())));
    }

    public abstract string CountConfig();
}