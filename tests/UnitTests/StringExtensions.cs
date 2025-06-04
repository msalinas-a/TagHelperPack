#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System;
#pragma warning restore IDE0130 // Namespace does not match folder structure

internal static class StringExtensions
{
	public static string NormalizeLineEndings(this string text, string newLine = "\n")
	{
		return text.Replace("\r\n", newLine).Replace("\n", newLine);
	}
}
