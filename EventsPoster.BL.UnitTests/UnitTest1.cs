using NUnit.Framework;

namespace EventsPoster.BL.UnitTests
{
    public class Tests
    {
        [TestFixture]
        public class TestBase
        {
            [SetUp]
            public void Setup()
            {
                //����� ������ ������
                //�������� ����������
                //������� ������
            }

            [TearDown]
            public void TearDown()
            {
                //����� ������� �����
                //�������� ����������
                //������� ������
            }

            [OneTimeSetUp]
            public void OneTimeSetup()
            {
                //���� ��� ����� �����
                //������������� ����������, ��������� ��������, �������� �������

            }

            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                //���� ��� ����� ���� ������
            }

            [Test]
            [TestCase(" 8 919 ")]
            [TestCase(null)]
            [TestCase("")]
            [Category("Integration")]
            public void TestPhoneValidation(string phone)
            {
                //������ �������
                //-- 
                // �����
                // ������������ �� ������ �����
                // +7 9..
                //assert - ��������
                Assert.Pass();
            }
        }
    }
}