using UnityEngine;

public static class UnityUtil {

	//Grabbed directly from Carlos' PixelEngine. Helps with debugging when something goes wrong in the Scene --
	//you can print out exactly the path to the GameObject in question. You're welcome! =)
	public static string GetAbsolutePath(Transform target) {
		Transform current = target;
		string absolutePath = "";
		while (current != null) {
			absolutePath = current.name + "/" + absolutePath;
			current = current.parent;
		}
		return absolutePath;
	}
}