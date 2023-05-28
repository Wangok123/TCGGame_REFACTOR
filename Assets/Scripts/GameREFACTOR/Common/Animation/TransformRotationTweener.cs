namespace GameREFACTOR.Common.Animation
{
	public class TransformRotationTweener : QuaternionTweener 
	{
		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			transform.rotation = currentTweenValue;
		}
	}
}