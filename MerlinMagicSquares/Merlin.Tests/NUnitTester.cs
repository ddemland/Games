
using Merlin.Engine;
using NUnit.Framework;

namespace Merlin.Tests
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    [TestFixture]
    public class NUnitTester
	{
        /// <summary>
		/// The main entry point for the application.
		/// </summary>

        [Test]
        public void TestSquare()
        {
            var squareObj = new Square();

            Assert.AreEqual(-1, squareObj.GetState());

            squareObj.SetState(2);
            Assert.AreEqual(2, squareObj.GetState());
        }

        [Test]
        public void TestToggle()
        {
            var toggleObj = new ToggleItem();
            var numSquares = 0;
            var numListPtr = new int[1];

            Assert.AreEqual(-1, toggleObj.GetNumSquares());

            toggleObj.SetNumSquares(3);
            Assert.AreEqual(3, toggleObj.GetNumSquares());

            toggleObj = new ToggleItem();
            toggleObj.GetList(ref numSquares, ref numListPtr);
            Assert.AreEqual(-1, numSquares);
        }

        [Test]
        public void TestToggleSetList()
        {
            int numSquares = 0, cnt;
            var numListPtr = new int[1];
            int[] testList = { 1, 2, 3 };
            var toggleObj = new ToggleItem();

            toggleObj.SetList(0, ref numListPtr);
            toggleObj.GetList(ref numSquares, ref numListPtr);
            Assert.AreEqual(0, numSquares);

            toggleObj.SetList(3, ref testList);
            toggleObj.GetList(ref numSquares, ref numListPtr);
            Assert.AreEqual(3, numSquares);

            for (cnt = 0; cnt < 3; cnt++)
            {
                Assert.AreEqual(numListPtr[cnt], testList[cnt]);
            }
        }

        [Test]
        public void TestGridInit()
        {
            var gridObj = new Grid();

            gridObj.InitGrid();
            Assert.AreEqual(Grid.MaxStates, gridObj.GetMaxStates());
        }

        [Test]
        public void TestGridReady()
        {
            var gridObj = new Grid();

            Assert.IsFalse(gridObj.GridValid());

            gridObj.InitGrid();
            Assert.IsTrue(gridObj.GridValid());
        }

        [Test]
        public void TestGetMaxStates()
        {
            var gridObj = new Grid();

            Assert.AreEqual(-1, gridObj.GetMaxStates());
        }

        [Test]
        public void TestSetMaxStates()
        {
            var gridObj = new Grid();

            gridObj.SetMaxStates(3);
            Assert.AreEqual(3, gridObj.GetMaxStates());
        }

        [Test]
        public void TestGetWinPattern()
        {
            int cnt;
            var gridObj = new Grid();

            int[] winPtr = gridObj.GetWinPattern();
            for (cnt = 0; cnt < Grid.MaxSquares; cnt++)
            {
                Assert.AreEqual(1, winPtr[cnt]);
            }
        }

        [Test]
        public void TestSetWinPattern()
        {
            int cnt;
            int[] testPattern = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var gridObj = new Grid();

            gridObj.SetWinPattern(testPattern);
            int[] winPtr = gridObj.GetWinPattern();

            for (cnt = 0; cnt < Grid.MaxSquares; cnt++)
            {
                Assert.AreEqual(winPtr[cnt], testPattern[cnt]);
            }
        }

        [Test]
        public void TestGameWon()
        {
            var testWinPattern = new int[Grid.MaxSquares];
            int cnt;
            var gridObj = new Grid();

            Square[] currGridPtr = gridObj.GetGrid();
            for (cnt = 0; cnt < Grid.MaxSquares; cnt++)
            {
                testWinPattern[cnt] = currGridPtr[cnt].GetState();
            }

            gridObj.SetWinPattern(testWinPattern);
            Assert.IsTrue(gridObj.GameWon());

            testWinPattern[2] = 4;
            gridObj.SetWinPattern(testWinPattern);
            Assert.IsFalse(gridObj.GameWon());
        }

        [Test]
        public void TestInitSetWinPattern()
        {
            int cnt;
            int[] testPattern = { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var gridObj = new Grid();

            int[] winPtr = gridObj.GetWinPattern();

            for (cnt = 0; cnt < Grid.MaxSquares; cnt++)
            {
                Assert.AreEqual(winPtr[cnt], testPattern[cnt]);
            }
        }

        [Test]
        public void TestToggleGrid()
        {
            RunToggleTest(0);
            RunToggleTest(1);
            RunToggleTest(3);
            RunToggleTest(4);
        }

        [Test]
        public void TestStartingWin()
        {
            int cnt;
            var gridObj = new Grid();

            gridObj.InitGrid();
            Square[] currGrid = gridObj.GetGrid();

            for (cnt = 0; cnt < Grid.MaxSquares; cnt++)
            {
                currGrid[cnt].SetState(1);
            }

            Assert.IsTrue(gridObj.GameWon());
        }

        private static void RunToggleTest(int P_idx)
        {
            var expectedTogglePattern = new int[Grid.MaxSquares];
            int cnt, toggleTotalCnt = 0;
            var afterToggledPattern = new int[Grid.MaxSquares];
            var toggleItemPtr = new int[1];
            var gridObj = new Grid();

            gridObj.InitGrid();
            gridObj.RandomizeStartingGrid();
            Square[] currGridPtr = gridObj.GetGrid();
            for (cnt = 0; cnt < Grid.MaxSquares; cnt++)
            {
                expectedTogglePattern[cnt] = currGridPtr[cnt].GetState();
            }

            //
            //  We will toggle the changed suqares so that the
            //      comparision will be easy.
            //

            ToggleItem toggleListPtr = gridObj.GetToggleList(P_idx);
            toggleListPtr.GetList(ref toggleTotalCnt, ref toggleItemPtr);
            for (cnt = 0; cnt < toggleTotalCnt; cnt++)
            {
                int currIdx = toggleItemPtr[cnt];
                expectedTogglePattern[currIdx] ^= 1;
            }

            gridObj.ToggleGrid(P_idx);

            currGridPtr = gridObj.GetGrid();
            for (cnt = 0; cnt < Grid.MaxSquares; cnt++)
            {
                afterToggledPattern[cnt] = currGridPtr[cnt].GetState();
            }

            for (cnt = 0; cnt < Grid.MaxSquares; cnt++)
            {
                Assert.AreEqual(afterToggledPattern[cnt], expectedTogglePattern[cnt]);
            }
        }
    }
}
