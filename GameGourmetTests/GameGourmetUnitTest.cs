using GameGourmetCore;

namespace GameGourmetTests
{
    public class GameGourmetUnitTest
    {
        [Fact]
        public void Game_Initialization_Should_Set_CurrentNode_To_Root()
        {
            // Arrange
            var game = new Game();

            // Act
            var currentNode = game.CurrentNode;

            // Assert
            Assert.NotNull(currentNode);
            Assert.Equal("pasta", currentNode.Question);
        }

        [Fact]
        public void MoveToYesNode_Should_Update_CurrentNode_To_YesNode()
        {
            // Arrange
            var game = new Game();

            // Act
            game.MoveToYesNode();
            var currentNode = game.CurrentNode;

            // Assert
            Assert.NotNull(currentNode);
            Assert.Equal("lasagna", currentNode.Question);
        }

        [Fact]
        public void MoveToNoNode_Should_Update_CurrentNode_To_NoNode()
        {
            // Arrange
            var game = new Game();

            // Act
            game.MoveToNoNode();
            var currentNode = game.CurrentNode;

            // Assert
            Assert.NotNull(currentNode);
            Assert.Equal("chocolate cake", currentNode.Question);
        }

        [Fact]
        public void IsTerminalNode_Should_Return_True_For_Terminal_Node()
        {
            // Arrange
            var game = new Game();
            game.MoveToYesNode(); // Move to "lasanha"

            // Act
            var isTerminal = Game.IsTerminalNode(game.CurrentNode);

            // Assert
            Assert.True(isTerminal);
        }

        [Fact]
        public void IsTerminalNode_Should_Return_False_For_NonTerminal_Node()
        {
            // Arrange
            var game = new Game();
            game.MoveToNoNode(); // Move to "bolo de chocolate"

            // Act
            var isTerminal = Game.IsTerminalNode(game.CurrentNode);

            // Assert
            Assert.True(isTerminal);
        }

        [Fact]
        public void UpdateGameTree_Should_Update_CurrentNode_And_Add_New_Question()
        {
            // Arrange
            var game = new Game();
            var currentNode = game.CurrentNode; // Node "massa"
            var newDish = "pizza";
            var newQuestion = "Is it an Italian dish?";

            // Act
            Game.UpdateGameTree(currentNode, newDish, newQuestion);

            // Assert
            Assert.Equal(newQuestion, currentNode.Question);
            Assert.Equal(newDish, currentNode.YesNode.Question);
            Assert.Equal("pasta", currentNode.NoNode.Question);
        }

        [Fact]
        public void Reset_Should_Set_CurrentNode_Back_To_Root()
        {
            // Arrange
            var game = new Game();
            game.MoveToYesNode(); // Move to "lasanha"

            // Act
            game.Reset();
            var currentNode = game.CurrentNode;

            // Assert
            Assert.NotNull(currentNode);
            Assert.Equal("pasta", currentNode.Question);
        }
    }
}