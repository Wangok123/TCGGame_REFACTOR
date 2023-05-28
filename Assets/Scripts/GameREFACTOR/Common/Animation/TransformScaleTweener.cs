﻿namespace GameREFACTOR.Common.Animation
{
	public class TransformScaleTweener : Vector3Tweener 
	{
		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			transform.localScale = currentTweenValue;
		}
	}
}