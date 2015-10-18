using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{
	public static T GetOther<T>(this T obj) where T : MonoBehaviour
	{
		GameObject other = obj.GetComponent<Otherizer>().other;
		if(other == null) {
			throw new UnityException("This object does not have a counterpart");
		}
		return other.GetComponent<T>();
	}
}