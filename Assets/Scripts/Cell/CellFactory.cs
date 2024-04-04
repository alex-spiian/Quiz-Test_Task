using VContainer;
using VContainer.Unity;

namespace Cell
{
    public class CellFactory
    {
        private readonly IObjectResolver _resolver;

        public CellFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public Cell CreateCell(Cell cellPrefab)
        {
            var cell = _resolver.Instantiate(cellPrefab);
            return cell;
        }
    }
}