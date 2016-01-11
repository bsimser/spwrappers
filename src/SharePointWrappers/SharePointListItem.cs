using System;

namespace SharePointWrappers
{
	/// <summary>
	/// Summary description for SharePointListItem.
	/// </summary>
	public class SharePointListItem : SharePointObject
	{
		private SharePointList list; 
		private Guid guid;
		private long id;

		/// <summary>
		/// Creates a new <see cref="SharePointListItem"/> instance.
		/// </summary>
		/// <param name="containingList">Containing list.</param>
		/// <param name="id">Id.</param>
		/// <param name="guid">Guid.</param>
		public SharePointListItem(SharePointList containingList, long id, Guid guid) : base(containingList.SiteURL)
		{
			this.id = id;
			this.guid = guid;
			list = containingList;
		}

		/// <summary>
		/// Gets the i d.
		/// </summary>
		/// <value></value>
		public long ID 
		{
			get { return id; }
		}

		/// <summary>
		/// Gets the g u i d.
		/// </summary>
		/// <value></value>
		public Guid GUID
		{
			get { return guid; }
		}

		/// <summary>
		/// ADDs the attachment.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="fileContent">File content.</param>
		/// <returns></returns>
		public string AddAttachment(string fileName, byte[] fileContent)
		{
			ListsWS.Lists lws = NewListsWebService();
			return lws.AddAttachment(list.Name, id.ToString(), fileName, fileContent);
		}
	}
}
