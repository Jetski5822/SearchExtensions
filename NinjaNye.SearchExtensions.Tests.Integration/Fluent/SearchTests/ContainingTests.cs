using System;
using System.Linq;
using Xunit;

namespace NinjaNye.SearchExtensions.Tests.Integration.Fluent.SearchTests
{
    [Collection("Database tests")]
    public class ContainingTests
    {
        private readonly TestContext _context;

        public ContainingTests(DatabaseIntegrationTests @base)
        {
            _context = @base._context;
        }

        [Fact]
        public void Containing_SearchWholeWordsOnly_ReturnsOnlyRecordsWithWholeWordMatches()
        {
            //Arrange

            //Act
            var result = _context.TestModels.Search(x => x.StringOne)
                .Matching(SearchType.WholeWords)
                .Containing("word");

            //Assert
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void Containing_SearchWholeWordsOnly_ReturnsRecordsWithWholeWordAtTheStart()
        {
            //Arrange

            //Act
            var result = _context.TestModels.Search(x => x.StringOne)
                .Matching(SearchType.WholeWords)
                .Containing("whole");

            //Assert
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void Containing_SearchWholeWordsOnly_ReturnsRecordsWithWholeWordAtTheEnd()
        {
            //Arrange

            //Act
            var result = _context.TestModels.Search(x => x.StringOne)
                .Matching(SearchType.WholeWords)
                .Containing("match");

            //Assert
            Assert.Equal(1, result.Count());
            Assert.True(result.Any(x => x.Id == new Guid("CADA7A13-931A-4CF0-B4F4-49160A743251")));
        }

        [Fact]
        public void Containing_SearchWholeWordsOnly_ReturnsRecordsWithSearchedWord()
        {
            //Arrange

            //Act
            var result = _context.TestModels.Search(x => x.StringOne)
                .Matching(SearchType.WholeWords)
                .Containing("wholewordmatch");

            //Assert
            Assert.Equal(1, result.Count());
            Assert.True(result.Any(x => x.Id == new Guid("A8AD8A4F-853B-417A-9C0C-0A2802560B8C")));
        }        
    }
}