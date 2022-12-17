using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Diagnostics.Windows.Configs;

namespace Console;

// 試運転モード
//[DryJob]
// 短縮実行モード
[ShortRunJob]
// 最小時間/最大時間の列を追加
[MinColumn, MaxColumn]
// メモリ計測追加
[MemoryDiagnoser]
// Native Memery Profiler 
[NativeMemoryProfiler]
// Export の追加
//[MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
[JsonExporterAttribute.Full]
[JsonExporterAttribute.FullCompressed]
public class Md5VsSha256
{
	private const int N = 10000;
	private readonly byte[] data;

	private readonly SHA256 sha256 = SHA256.Create();
	private readonly MD5 md5 = MD5.Create();

	public Md5VsSha256()
	{
		data = new byte[N];
		new Random(42).NextBytes(data);
	}

	[Benchmark]
	public byte[] Sha256() => sha256.ComputeHash(data);

	[Benchmark]
	public byte[] Md5() => md5.ComputeHash(data);
}
