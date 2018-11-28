package md552cd7a192d402f7207a56fc3ebcf7bc8;


public class NonConfigInstanceActivity
	extends android.app.ListActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onRetainNonConfigurationInstance:()Ljava/lang/Object;:GetOnRetainNonConfigurationInstanceHandler\n" +
			"";
		mono.android.Runtime.register ("RotationDemo.NonConfigInstanceActivity, RotationDemo", NonConfigInstanceActivity.class, __md_methods);
	}


	public NonConfigInstanceActivity ()
	{
		super ();
		if (getClass () == NonConfigInstanceActivity.class)
			mono.android.TypeManager.Activate ("RotationDemo.NonConfigInstanceActivity, RotationDemo", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public java.lang.Object onRetainNonConfigurationInstance ()
	{
		return n_onRetainNonConfigurationInstance ();
	}

	private native java.lang.Object n_onRetainNonConfigurationInstance ();

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
