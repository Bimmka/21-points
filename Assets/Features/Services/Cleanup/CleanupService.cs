using System.Collections.Generic;

namespace Features.Services.Cleanup
{
  public class CleanupService : ICleanupService
  {
    private readonly List<ICleanup> cleanups;

    public CleanupService()
    {
      cleanups = new List<ICleanup>(10);
    }

    public void Register(ICleanup cleanup) => 
      cleanups.Add(cleanup);

    public void Unregister(ICleanup cleanup) => 
      cleanups.Remove(cleanup);

    public void Cleanup()
    {
      for (int i = 0; i < cleanups.Count; i++)
      {
        cleanups[i].Cleanup();
      }
    }

    public void Clear() => 
      cleanups.Clear();
  }
}