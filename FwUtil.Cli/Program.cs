using System.Diagnostics;
using FwUtil.Core;
using FwUtil.Core.Classes;
using FwUtil.Core.Models;

namespace FwUtil.Cli;

public static class Program
{
    private static void Main(string[] args)
    {
        Debug.WriteLine("App started");
        Test();
    }

    private static void Test()
    {
        Console.WriteLine("Fetching rules...");
        var aa = new FirewallAction();


        foreach (var fwItem in aa.Items())
        {
            Console.WriteLine($"Rule: {fwItem.DisplayName}");
        }
    }
}