using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IBlocksRepository
    {
        bool BlockExists(int id);
        Task<Block> GetBlock(int id);
        Task<IEnumerable<Block>> GetBlocks();
        Task UpdateBlock(Block block);
        Task AddBlock(Block block);
        Task DeleteBlock(Block block);
    }
}