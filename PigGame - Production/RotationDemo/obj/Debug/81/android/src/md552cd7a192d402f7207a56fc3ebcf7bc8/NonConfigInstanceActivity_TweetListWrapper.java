package md552cd7a192d402f7207a56fc3ebcf7bc8;


public class NonConfigInstanceActivity_TweetListWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RotationDemo.NonConfigInstanceActivity+TweetListWrapper, RotationDemo", NonConfigInstanceActivity_TweetListWrapper.class, __md_methods);
	}


	public NonConfigInstanceActivity_TweetListWrapper ()
	{
		super ();
		if (getClass () == NonConfigInstanceActivity_TweetListWrapper.class)
			mono.android.TypeManager.Activate ("RotationDemo.NonConfigInstanceActivity+TweetListWrapper, RotationDemo", "", this, new java.lang.Object[] {  });
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
