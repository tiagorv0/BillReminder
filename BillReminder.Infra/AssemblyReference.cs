using System.Reflection;

namespace BillReminder.Infra;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
