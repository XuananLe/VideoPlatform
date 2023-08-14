using VideoPlatform.API.Models;

namespace VideoPlatform.API;

// This is a singleton
public class TrickyStore
{
    private readonly List<Trick> _tricks = new List<Trick>();

    public TrickyStore()
    {
        
    }
    public TrickyStore(List<Trick> tricks)
    {
        _tricks = tricks;
    }
    
    public IEnumerable<Trick> All => _tricks;

    public void AddTrick(Trick trick)
    {
        trick.Id = _tricks.Count + 1;
        _tricks.Add(trick);
    }
    
}