``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.685 (2004/?/20H1)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=3.1.302
  [Host]     : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT
  DefaultJob : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT


```
|       Method |       Mean |     Error |    StdDev |
|------------- |-----------:|----------:|----------:|
|   StaticCall |  0.0213 ns | 0.0046 ns | 0.0043 ns |
| InstanceCall |  0.0058 ns | 0.0045 ns | 0.0042 ns |
|  VirtualCall |  1.6600 ns | 0.0186 ns | 0.0164 ns |
|  GenericCall |  0.0251 ns | 0.0034 ns | 0.0030 ns |
|  DynamicCall | 13.7383 ns | 0.2725 ns | 0.5051 ns |
