package crc64a9a76da59ea5a68f;


public class MaterialContextThemeWrapper
	extends android.view.ContextThemeWrapper
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.Material.MaterialContextThemeWrapper, Xamarin.Forms.Platform.Android", MaterialContextThemeWrapper.class, __md_methods);
	}


	public MaterialContextThemeWrapper (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == MaterialContextThemeWrapper.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.Material.MaterialContextThemeWrapper, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
