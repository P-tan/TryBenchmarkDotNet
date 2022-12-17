using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<Console.Md5VsSha256>();
