using NUnit.Framework;

namespace SharePointWrappers.UnitTest
{
	/// <summary>
	/// Summary description for ServerTests.
	/// </summary>
	[TestFixture]
	public class ServerTests
	{
		[Test]
		public void TestServerConnect()
		{
			SharePointServer server = new SharePointServer("http://localhost");
			Assert.AreEqual(server.Url, "http://local");
		}
	}
}
