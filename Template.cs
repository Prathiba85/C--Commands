namespace SeleniumLearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method execution");
        }

        [Test]
        public void launchurl()
        {
            TestContext.Progress.WriteLine("This is from test 1");
            Assert.Pass();
        }

        
        [TearDown] public void TearDown() 
        {
            TestContext.Progress.WriteLine("This is from Tear down ");
        }

    }
}