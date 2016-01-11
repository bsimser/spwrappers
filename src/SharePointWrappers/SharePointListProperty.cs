using System.Collections;

namespace SharePointWrappers
{
	/// <summary>
	/// Summary description for SharePointListProperty.
	/// </summary>
	/// TODO: rename this class to SharePointListField
	public class SharePointListProperty
	{
		private Hashtable properties = new Hashtable();

		/// <summary>
		/// Creates a new <see cref="SharePointListProperty"/> instance.
		/// </summary>
		public SharePointListProperty()
		{
		}

		/// <summary>
		/// Gets the properties.
		/// </summary>
		/// <value></value>
		public Hashtable Properties
		{
			get { return properties; }
		}

		/// <summary>
		/// Adds the property.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="val">Val.</param>
		public void AddProperty(string key, string val)
		{
			properties.Add(key, val);
		}
	}
}
