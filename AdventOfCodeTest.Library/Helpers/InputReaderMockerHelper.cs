using AdventOfCodeClient.interfaces;
using FakeItEasy;

namespace AdventOfCodeTest.Library.Helpers
{
    public static class InputReaderMockerHelper
    {
        public static IProblemInputReader CreateMock(int day, string input)
        {
            var problemInputReaderMock = A.Fake<IProblemInputReader>();
            A.CallTo(() => problemInputReaderMock.ReadInputFromUrlAsync(day)).Returns(input);
            return problemInputReaderMock;
        }
    }
}
