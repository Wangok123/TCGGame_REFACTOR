﻿using System;

namespace GameREFACTOR.Common.Animation
{
	public class Tweener : EasingControl
	{
		#region Properties
		public static float DefaultDuration = 1f;
		public static Func<float, float, float, float> DefaultEquation = EasingEquations.EaseInOutQuad;
		public bool destroyOnComplete = true;
		#endregion

		#region Event Handlers
		protected override void OnComplete ()
		{
			base.OnComplete ();
			if (destroyOnComplete)
				Destroy(this);
		}
		#endregion
	}
}