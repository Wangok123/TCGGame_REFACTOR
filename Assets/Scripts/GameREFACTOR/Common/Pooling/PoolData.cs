using System.Collections.Generic;
using UnityEngine;

namespace GameREFACTOR.Common.Pooling
{
	public class PoolData
	{
		public GameObject prefab;
		public int maxCount;
		public Queue<Poolable> pool;
	}
}