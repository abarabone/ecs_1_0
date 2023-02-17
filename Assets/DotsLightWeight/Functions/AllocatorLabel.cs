using System.Threading;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Collections;

#nullable enable

namespace DotsLite.Memory
{

	/// <summary>
	/// Allocator î•ñ‚ğŒ^‚É‚½‚¹‚é‚½‚ß‚Ég—p‚·‚éB
	/// </summary>
	public interface IAllocatorLabel
	{
		Allocator Label { get; }
	}
	public struct Persistent : IAllocatorLabel
	{
		public Allocator Label { get => Allocator.Persistent; }
	}
	public struct Temp : IAllocatorLabel
	{
		public Allocator Label { get => Allocator.Temp; }
	}
	public struct TempJob : IAllocatorLabel
	{
		public Allocator Label { get => Allocator.TempJob; }
	}

}
