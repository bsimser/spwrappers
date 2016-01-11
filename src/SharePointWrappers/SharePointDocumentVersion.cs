using System;

namespace SharePointWrappers
{
	/// <summary>
	/// Represents a version of an object in a <see cref="SharePointDocLib"/>
	/// </summary>
	public class SharePointDocumentVersion : SharePointObject
	{
		private string version;
		private DateTime created;
		private string createdBy;
		private int size;
		private string comments;
		private string versionUrl;

		/// <summary>
		/// Creates a new <see cref="SharePointDocumentVersion"/> instance.
		/// </summary>
		/// <param name="siteUrl">Site URL.</param>
		public SharePointDocumentVersion(string siteUrl) : base(siteUrl)
		{
		}

		#region Accessors

		/// <summary>
		/// Gets or sets the version.
		/// </summary>
		/// <value></value>
		public string Version
		{
			get { return version; }
			set { version = value; }
		}

		/// <summary>
		/// Gets the version URL.
		/// </summary>
		/// <value></value>
		public string VersionUrl
		{
			get { return versionUrl; }
			set { versionUrl = value; }
		}

		/// <summary>
		/// Gets or sets the created.
		/// </summary>
		/// <value></value>
		public DateTime Created
		{
			get { return created; }
			set { created = value; }
		}

		/// <summary>
		/// Gets or sets the created by.
		/// </summary>
		/// <value></value>
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value></value>
		public int Size
		{
			get { return size; }
			set { size = value; }
		}

		/// <summary>
		/// Gets or sets the comments.
		/// </summary>
		/// <value></value>
		public string Comments
		{
			get { return comments; }
			set { comments = value; }
		}

		#endregion
	}
}
